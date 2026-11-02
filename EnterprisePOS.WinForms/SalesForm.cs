using EnterprisePOS.Data;
using EnterprisePOS.Data.Repositories;
using EnterprisePOS.Domain;
using EnterprisePOS.Domain.Class;
using EnterprisePOS.WinForms.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnterprisePOS.Services.Service;

namespace EnterprisePOS.WinForms
{
    public partial class SalesForm : Form
    {

        public UserSession CurrentUser { get; set; }

        private readonly UserSession _currentUser;
        private const decimal TaxRate = 0.08m;

        private readonly BindingList<CartLine> _cart =
            new BindingList<CartLine>();

        private readonly SalesService _salesService =
    new SalesService();

        private readonly DatabaseRepository _databaseRepository =
    new DatabaseRepository();

        private decimal _subtotal;
        private decimal _discountAmount;
        private decimal _taxAmount;
        private decimal _total;

        private sealed class ProductGridRow
        {
            public int ProductId { get; set; }
            public string Barcode { get; set; }
            public string Sku { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int StockQty { get; set; }
        }

        public SalesForm(UserSession user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _currentUser = user;
            CurrentUser = user;

            InitializeComponent();

            ConfigureProductGrid();
            ConfigureCartGrid();

            dgvCart.DataSource = _cart;

            txtBarcode.KeyDown += txtBarcode_KeyDown;
            btnAdd.Click += btnAdd_Click;
            btnRemoveItem.Click += btnRemoveItem_Click;
            btnClearCart.Click += btnClearCart_Click;
            btnCheckout.Click += btnCheckout_Click;

            dgvProducts.CellDoubleClick +=
                dgvProducts_CellDoubleClick;

            dgvCart.CellEndEdit += dgvCart_CellEndEdit;
            dgvCart.DataError += dgvCart_DataError;

            nudDiscount.ValueChanged +=
                nudDiscount_ValueChanged;

            btnQtyPlus.Click += btnQtyPlus_Click;
            btnQtyMinus.Click += btnQtyMinus_Click;

            LoadCustomers();
            LoadProducts();
            UpdateTotals();

            txtBarcode.Focus();
        }
        private void ConfigureProductGrid()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.ReadOnly = true;
            dgvProducts.MultiSelect = false;
            dgvProducts.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductId",
                    DataPropertyName = "ProductId",
                    Visible = false
                });

            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Barcode",
                    HeaderText = "Barcode",
                    DataPropertyName = "Barcode",
                    FillWeight = 100
                });

            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Sku",
                    HeaderText = "SKU",
                    DataPropertyName = "Sku",
                    FillWeight = 80
                });

            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Name",
                    HeaderText = "Product",
                    DataPropertyName = "Name",
                    FillWeight = 150
                });

            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Price",
                    HeaderText = "Price",
                    DataPropertyName = "Price",
                    DefaultCellStyle =
                        new DataGridViewCellStyle
                        {
                            Format = "N2"
                        },
                    FillWeight = 70
                });

            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "StockQty",
                    HeaderText = "Stock",
                    DataPropertyName = "StockQty",
                    FillWeight = 55
                });

            // Start with no product selected.
            dgvProducts.ClearSelection();
            dgvProducts.CurrentCell = null;
        }

        private void ConfigureCartGrid()
        {
            StyleGrid(dgvCart);

            dgvCart.AutoGenerateColumns = false;
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.MultiSelect = false;
            dgvCart.ReadOnly = false;
            dgvCart.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvCart.RowHeadersVisible = false;
            dgvCart.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvCart.Columns.Clear();

            dgvCart.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductId",
                    DataPropertyName = "ProductId",
                    Visible = false
                });

            dgvCart.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductName",
                    HeaderText = "Product",
                    DataPropertyName = "ProductName",
                    ReadOnly = true,
                    FillWeight = 150
                });

            dgvCart.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Sku",
                    HeaderText = "SKU",
                    DataPropertyName = "Sku",
                    ReadOnly = true,
                    FillWeight = 85
                });

            var unitPrice = new DataGridViewTextBoxColumn
            {
                Name = "UnitPrice",
                HeaderText = "Price",
                DataPropertyName = "UnitPrice",
                ReadOnly = true,
                DefaultCellStyle =
                    new DataGridViewCellStyle { Format = "N2" },
                FillWeight = 75
            };

            dgvCart.Columns.Add(unitPrice);
            RightAlign(unitPrice);

            var qty = new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Qty",
                DataPropertyName = "Quantity",
                ReadOnly = false,
                FillWeight = 50
            };

            dgvCart.Columns.Add(qty);
            RightAlign(qty);

            var amount = new DataGridViewTextBoxColumn
            {
                Name = "LineTotal",
                HeaderText = "Amount",
                DataPropertyName = "LineTotal",
                ReadOnly = true,
                DefaultCellStyle =
                    new DataGridViewCellStyle { Format = "N2" },
                FillWeight = 85
            };

            dgvCart.Columns.Add(amount);
            RightAlign(amount);
        }

        private void StyleGrid(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(35, 47, 62);
            grid.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);
            grid.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(220, 235, 250);
            grid.DefaultCellStyle.SelectionForeColor =
                Color.Black;
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.FixedSingle;
        }

        private void RightAlign(DataGridViewColumn column)
        {
            column.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
        }

        private void LoadProducts()
        {
            try
            {
                using (var db = _databaseRepository.CreateContext())
                {
                    var products = db.Products
                        .Where(p => p.IsActive)
                        .OrderBy(p => p.Name)
                        .Select(p => new ProductGridRow
                        {
                            ProductId = p.ProductId,
                            Barcode = p.Barcode,
                            Sku = p.Sku,
                            Name = p.Name,
                            Price = p.Price,
                            StockQty = p.StockQty
                        })
                        .ToList();

                    dgvProducts.DataSource = products;

                    // Binding the data may select the first row automatically.
                    // Clear that selection so scanning a SKU/barcode is independent
                    // from whichever product is shown in the grid.
                    dgvProducts.ClearSelection();
                    dgvProducts.CurrentCell = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load products.\n\n" + ex.Message,
                    "Product Loading Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadCustomers()
        {
            cmbCustomer.Items.Clear();
            cmbCustomer.Items.Add("Walk-in Customer");
            cmbCustomer.SelectedIndex = 0;
        }

        private void txtBarcode_KeyDown(
            object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;

            string barcode = txtBarcode.Text.Trim();

            if (!string.IsNullOrWhiteSpace(barcode))
                AddProductByBarcode(barcode);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Add Item always uses the barcode/SKU typed or scanned in the textbox,
            // never the currently selected row in the product grid.
            string code = txtBarcode.Text.Trim();

            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show(
                    "Please scan or enter a barcode or SKU first.",
                    "Barcode / SKU Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtBarcode.Focus();
                return;
            }

            AddProductByBarcode(code);
        }

        private void dgvProducts_CellDoubleClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Double-click adds the exact row that was double-clicked.
            var product = dgvProducts.Rows[e.RowIndex]
                .DataBoundItem as ProductGridRow;

            if (product != null)
                AddProductToCart(product, (int)nudQty.Value);

            txtBarcode.Focus();
        }

        private void AddProductByBarcode(string barcode)
        {
            try
            {
                using (var db = _databaseRepository.CreateContext())
                {
                    var product = db.Products.FirstOrDefault(p =>
                        p.IsActive &&
                        (p.Barcode == barcode || p.Sku == barcode));

                    if (product == null)
                    {
                        MessageBox.Show(
                            "No active product found for: " + barcode,
                            "Product Not Found",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }

                    var row = new ProductGridRow
                    {
                        ProductId = product.ProductId,
                        Barcode = product.Barcode,
                        Sku = product.Sku,
                        Name = product.Name,
                        Price = product.Price,
                        StockQty = product.StockQty
                    };

                    AddProductToCart(row, (int)nudQty.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to search for the product.\n\n" + ex.Message,
                    "Barcode Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                txtBarcode.Clear();
                txtBarcode.Focus();
            }
        }

        private void AddProductToCart(
            ProductGridRow product, int quantity)
        {
            if (quantity < 1)
                quantity = 1;

            if (product.StockQty <= 0)
            {
                MessageBox.Show(
                    "This product is out of stock.",
                    "Out of Stock",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var existing = _cart.FirstOrDefault(
                x => x.ProductId == product.ProductId);

            int requestedQuantity =
                quantity + (existing == null ? 0 : existing.Quantity);

            if (requestedQuantity > product.StockQty)
            {
                MessageBox.Show(
                    "Not enough stock available.\nAvailable stock: "
                    + product.StockQty,
                    "Insufficient Stock",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (existing != null)
            {
                existing.Quantity = requestedQuantity;
            }
            else
            {
                _cart.Add(new CartLine
                {
                    ProductId = product.ProductId,
                    Barcode = product.Barcode,
                    Sku = product.Sku,
                    ProductName = product.Name,
                    Quantity = quantity,
                    UnitPrice = product.Price
                });
            }

            RefreshCart();
        }

        private CartLine GetSelectedCartItem()
        {
            if (dgvCart.CurrentRow == null)
                return null;

            return dgvCart.CurrentRow.DataBoundItem as CartLine;
        }

        private void btnQtyPlus_Click(object sender, EventArgs e)
        {
            CartLine item = GetSelectedCartItem();

            if (item == null)
            {
                MessageBox.Show(
                    "Select an item in the cart first.",
                    "No Item Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (var db = _databaseRepository.CreateContext())
                {
                    var product = db.Products.FirstOrDefault(
                        p => p.ProductId == item.ProductId && p.IsActive);

                    if (product == null)
                    {
                        MessageBox.Show("This product is no longer available.");
                        return;
                    }

                    if (item.Quantity >= product.StockQty)
                    {
                        MessageBox.Show(
                            "You have reached the available stock limit.",
                            "Stock Limit",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                }

                item.Quantity++;
                RefreshCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to check stock.\n\n" + ex.Message,
                    "Quantity Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnQtyMinus_Click(object sender, EventArgs e)
        {
            CartLine item = GetSelectedCartItem();

            if (item == null)
            {
                MessageBox.Show(
                    "Select an item in the cart first.",
                    "No Item Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (item.Quantity > 1)
            {
                item.Quantity--;
                RefreshCart();
            }
            else
            {
                MessageBox.Show(
                    "Quantity cannot be less than 1. Use Remove Item "
                    + "if you want to remove this product.",
                    "Minimum Quantity",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            CartLine item = GetSelectedCartItem();

            if (item != null)
            {
                _cart.Remove(item);
                UpdateTotals();
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
                return;

            if (MessageBox.Show(
                "Remove all items from the cart?",
                "Clear Cart",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _cart.Clear();
                UpdateTotals();
            }
        }

        private void dgvCart_CellEndEdit(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvCart.Columns[e.ColumnIndex].Name != "Quantity")
                return;

            CartLine item =
                dgvCart.Rows[e.RowIndex].DataBoundItem as CartLine;

            if (item == null)
                return;

            if (item.Quantity < 1)
                item.Quantity = 1;

            try
            {
                using (var db = _databaseRepository.CreateContext())
                {
                    var product = db.Products.FirstOrDefault(
                        p => p.ProductId == item.ProductId && p.IsActive);

                    if (product == null)
                    {
                        _cart.Remove(item);
                        MessageBox.Show("This product is no longer available.");
                        UpdateTotals();
                        return;
                    }

                    if (item.Quantity > product.StockQty)
                    {
                        item.Quantity = Math.Max(1, product.StockQty);

                        MessageBox.Show(
                            "Quantity adjusted to available stock: "
                            + product.StockQty,
                            "Stock Limit",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to validate quantity.\n\n" + ex.Message,
                    "Quantity Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            RefreshCart();
        }

        private void dgvCart_DataError(
            object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            MessageBox.Show(
                "Please enter a valid whole number for quantity.",
                "Invalid Quantity",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void nudDiscount_ValueChanged(
            object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void RefreshCart()
        {
            dgvCart.Refresh();
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            _subtotal = _cart.Sum(x => x.LineTotal);

            decimal discountPercent = nudDiscount.Value;

            _discountAmount = Math.Round(
                _subtotal * discountPercent / 100m, 2);

            decimal taxableAmount = Math.Max(
                0m, _subtotal - _discountAmount);

            _taxAmount = Math.Round(
                taxableAmount * TaxRate, 2);

            _total = taxableAmount + _taxAmount;

            // Left-side labels
            lblSubtotal.Text = "Subtotal:";
            lblDiscountAmount.Text = "Discount:";
            lblTax.Text = "Tax:";
            lblTotal.Text = "Total:";

            // Right-side blue value labels
            lblSubtotalValue.Text = _subtotal.ToString("N2");
            lblDiscountValue.Text = _discountAmount.ToString("N2");
            lblTaxValue.Text = _taxAmount.ToString("N2");
            lblTotalValue.Text = _total.ToString("N2");

            btnCheckout.Enabled = true;

            dgvCart.Refresh();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show(
                    "The cart is empty. Please add a product before checkout.",
                    "Empty Cart",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Check permission before opening the payment dialog.
            try
            {
                if (!_salesService.HasPermission(
                    _currentUser.UserId, "Orders.Create"))
                {
                    MessageBox.Show(
                        "You do not have permission to create orders.",
                        "Access Denied",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to verify checkout permission.\n\n" + ex.Message,
                    "Permission Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            using (var payment = new PaymentDialog(_total))
            {
                if (payment.ShowDialog(this) != DialogResult.OK)
                    return;

                btnCheckout.Enabled = false;

                try
                {
                    var request = new OrderRequest
                    {
                        UserId = _currentUser.UserId,
                        CustomerId = null,
                        PaymentMethod = payment.PaymentMethod,
                        DiscountAmount = _discountAmount,
                        TaxRate = TaxRate,
                        AmountPaid = payment.AmountPaid,
                        Items = _cart.Select(item => new CartLine
                        {
                            ProductId = item.ProductId,
                            Barcode = item.Barcode,
                            Sku = item.Sku,
                            ProductName = item.ProductName,
                            UnitPrice = item.UnitPrice,
                            Quantity = item.Quantity
                        }).ToList()
                    };

                    // Save the sale. SalesService checks permission again.
                    int orderId = _salesService.SaveSale(request);

                    string savedOrderNumber;
                    DateTime savedOrderDate;

                    using (var db = _databaseRepository.CreateContext())
                    {
                        var savedOrder = db.Orders.FirstOrDefault(
                            o => o.OrderId == orderId);

                        if (savedOrder == null)
                        {
                            MessageBox.Show(
                                "The sale was saved, but the order details " +
                                "could not be loaded for the receipt. " +
                                "Please check the Orders table before retrying.",
                                "Receipt Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        savedOrderNumber = savedOrder.OrderNumber;
                        savedOrderDate = savedOrder.OrderDate;
                    }

                    decimal change = payment.AmountPaid - _total;

                    var receipt = new ReceiptData
                    {
                        BusinessName = "GREBA ENTERPRISE POS",
                        BusinessAddress = "123 Main Street, City",
                        BusinessPhone = "Tel: +1 555 0100",

                        OrderId = orderId,
                        OrderNumber = savedOrderNumber,
                        OrderDate = savedOrderDate,

                        CashierName = string.IsNullOrWhiteSpace(
                            _currentUser.FullName)
                            ? _currentUser.Username
                            : _currentUser.FullName,

                        Items = _cart.Select(item => new ReceiptItem
                        {
                            ProductName = item.ProductName,
                            Quantity = item.Quantity,
                            UnitPrice = item.UnitPrice,
                            LineTotal = item.LineTotal
                        }).ToList(),

                        Subtotal = _subtotal,
                        Discount = _discountAmount,
                        Tax = _taxAmount,
                        Total = _total,

                        PaymentMethod = payment.PaymentMethod,
                        AmountPaid = payment.AmountPaid,
                        ChangeDue = change,

                        ReturnPolicy =
                            "Please keep your receipt for returns or exchanges."
                    };

                    // Clear the cart only after the sale has been saved.
                    _cart.Clear();
                    nudDiscount.Value = 0;

                    LoadProducts();
                    UpdateTotals();

                    using (var receiptService = new ReceiptService(receipt))
                    {
                        receiptService.ShowPrintPreview(this);
                    }

                    txtBarcode.Focus();
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show(
                        "You do not have permission to create orders.",
                        "Access Denied",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "An error occurred during checkout or receipt processing.\n\n"
                        + ex.Message
                        + "\n\nIf the sale may already have been saved, "
                        + "check the Orders table before trying again.",
                        "Checkout Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    btnCheckout.Enabled = true;
                }
            }
        
    }
    }
}