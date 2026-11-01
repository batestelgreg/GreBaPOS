using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterprisePOS.Domain.Class
{
    public sealed class Product
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int StockQuantity { get; set; }
        public int ReorderLevel { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }
    }

    public sealed class CartLine : INotifyPropertyChanged
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; }
        public string Sku { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

        private int _quantity = 1;

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 1)
                    value = 1;

                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                    OnPropertyChanged(nameof(LineTotal));
                }
            }
        }

        public decimal LineTotal
        {
            get { return Quantity * UnitPrice; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }

    public sealed class UserSession
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string RoleName { get; set; }
    }

    public sealed class DashboardSummary
    {
        public decimal TodaySales { get; set; }
        public int TodayOrders { get; set; }
        public int LowStockCount { get; set; }
        public int ActiveProducts { get; set; }
    }

    public sealed class OrderRequest
    {
        public int UserId { get; set; }
        public int? CustomerId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal AmountPaid { get; set; }

     
        public List<CartLine> Items { get; set; }
            = new List<CartLine>();
    }
}