
using System;
using System.Linq;
using System.Transactions;
using EnterprisePOS.Domain.Class;
using EnterprisePOS.Data.Runtime;

namespace EnterprisePOS.Data.Repositories
{
    public class SalesRepository
    {
        private readonly DatabaseRepository _databaseRepository;

        public SalesRepository()
        {
            _databaseRepository = new DatabaseRepository();
        }

        public int SaveSale(OrderRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Items == null || request.Items.Count == 0)
                throw new InvalidOperationException(
                    "Cannot save an order with an empty cart.");

            if (request.UserId <= 0)
                throw new InvalidOperationException(
                    "Invalid cashier account.");

            if (request.AmountPaid < 0)
                throw new InvalidOperationException(
                    "Amount paid cannot be negative.");

            if (request.Items.Any(x => x.Quantity < 1))
                throw new InvalidOperationException(
                    "All item quantities must be at least 1.");

            if (request.Items.GroupBy(x => x.ProductId)
                .Any(g => g.Count() > 1))
                throw new InvalidOperationException(
                    "Duplicate cart items are not allowed.");

            decimal subtotal = request.Items.Sum(
                x => x.UnitPrice * x.Quantity);

            decimal discount = request.DiscountAmount;

            if (discount < 0 || discount > subtotal)
                throw new InvalidOperationException(
                    "Invalid discount amount.");

            decimal taxableAmount = subtotal - discount;

            if (request.TaxRate < 0)
                throw new InvalidOperationException(
                    "Tax rate cannot be negative.");

            decimal tax = Math.Round(
                taxableAmount * request.TaxRate, 2);

            decimal total = taxableAmount + tax;

            if (request.AmountPaid < total)
                throw new InvalidOperationException(
                    "Amount paid is less than the total.");

            decimal change = request.AmountPaid - total;

            using (var scope = new TransactionScope())
            using (var db = _databaseRepository.CreateContext())
            {
                foreach (var item in request.Items)
                {
                    var product = db.Products.FirstOrDefault(
                        p => p.ProductId == item.ProductId
                             && p.IsActive);

                    if (product == null)
                        throw new InvalidOperationException(
                            "A product is no longer available.");

                    if (product.StockQty < item.Quantity)
                        throw new InvalidOperationException(
                            "Insufficient stock for "
                            + product.Name + ".");

                    if (product.Price != item.UnitPrice)
                        throw new InvalidOperationException(
                            "The price of " + product.Name
                            + " has changed. Please reload the cart.");

                    product.StockQty -= item.Quantity;
                    product.UpdatedAt = DateTime.Now;
                }

                var order = new EnterprisePOS.Data.Order
                {
                    OrderNumber = "ORD-" +
                        DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                    CustomerId = request.CustomerId,
                    UserId = request.UserId,
                    OrderDate = DateTime.Now,
                    Subtotal = subtotal,
                    TaxAmount = tax,
                    DiscountAmount = discount,
                    Total = total,
                    PaymentMethod = request.PaymentMethod,
                    AmountPaid = request.AmountPaid,
                    ChangeDue = change,
                    Status = "Completed"
                };

                db.Orders.InsertOnSubmit(order);
                db.SubmitChanges();

                foreach (var item in request.Items)
                {
                    var detail = new EnterprisePOS.Data.OrderDetail
                    {
                        OrderId = order.OrderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        LineTotal = item.UnitPrice * item.Quantity
                    };

                    db.OrderDetails.InsertOnSubmit(detail);

                    var inventoryLog = new EnterprisePOS.Data.InventoryLog
                    {
                        ProductId = item.ProductId,
                        UserId = request.UserId,
                        ChangeQty = -item.Quantity,
                        Reason = "Sale: " + order.OrderNumber,
                        CreatedAt = DateTime.Now
                    };

                    db.InventoryLogs.InsertOnSubmit(inventoryLog);
                }

                db.SubmitChanges();
                scope.Complete();

                return order.OrderId;
            }
        }

        public string VoidSale(int orderId, int userId)
        {
            if (orderId <= 0)
                throw new ArgumentException("Invalid order ID.");

            if (userId <= 0)
                throw new ArgumentException("Invalid user ID.");

            using (var db = _databaseRepository.CreateContext())
            {
                var result = db.usp_Order_Void(
                    orderId,
                    userId
                ).SingleOrDefault();

                if (result == null)
                {
                    return "The stored procedure did not return a result.";
                }

                return result.Message;
            }
        }
    }
}
