
using EnterprisePOS.Data.Repositories;
using EnterprisePOS.Domain.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EnterprisePOS.Services.Service;

namespace EnterprisePOS.WinForms
{
    public partial class ProductForm : Form
    {
        private readonly DatabaseRepository _database;
        private readonly UserSession _user;

        private readonly UserAdministrationService _authorizationService =
            new UserAdministrationService();

        private readonly List<Image> _productThumbnails =
            new List<Image>();

        private bool _isLoadingProducts;
        private bool _viewPermissionWarningShown;
        private bool _authorizationErrorShown;

        public event EventHandler RequestClose;

        public ProductForm() : this(null)
        {
        }

        public ProductForm(UserSession user)
        {
            InitializeComponent();

            _database = new DatabaseRepository();
            _user = user;

            cmbProductFilter.Items.Clear();
            cmbProductFilter.Items.Add("All");
            cmbProductFilter.Items.Add("Active Only");
            cmbProductFilter.Items.Add("Inactive Only");
            cmbProductFilter.Items.Add("Low Stock Only");
            cmbProductFilter.Items.Add("Out of Stock Only");
            cmbProductFilter.SelectedIndex = 0;

            cmbProductFilter.SelectedIndexChanged -=
                cmbProductFilter_SelectedIndexChanged;

            cmbProductFilter.SelectedIndexChanged +=
                cmbProductFilter_SelectedIndexChanged;

            dgvProducts.RowPrePaint -= dgvProducts_RowPrePaint;
            dgvProducts.RowPrePaint += dgvProducts_RowPrePaint;
        }

        private bool HasPermission(string permissionCode)
        {
            if (_user == null || _user.UserId <= 0)
                return false;

            try
            {
                return _authorizationService.HasPermission(
                    _user.UserId,
                    permissionCode);
            }
            catch (Exception ex)
            {
                if (!_authorizationErrorShown)
                {
                    _authorizationErrorShown = true;

                    MessageBox.Show(
                        "Unable to verify your permission.\n\n" +
                        ex.Message,
                        "Authorization Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                return false;
            }
        }

        private bool CanViewProducts()
        {
            if (HasPermission("Products.View"))
                return true;

            if (!_viewPermissionWarningShown)
            {
                _viewPermissionWarningShown = true;

                MessageBox.Show(
                    "You do not have permission to view products.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            return false;
        }

        private bool CanEditProducts()
        {
            if (HasPermission("Products.Edit"))
                return true;

            MessageBox.Show(
                "You do not have permission to add, edit, or deactivate products.",
                "Access Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return false;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            RefreshProducts();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (Visible && IsHandleCreated && !_isLoadingProducts)
            {
                RefreshProducts();
            }
        }

        private void cmbProductFilter_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (!_isLoadingProducts && IsHandleCreated)
            {
                LoadProducts(txtSearch.Text.Trim());
            }
        }

        private void RefreshProducts()
        {
            if (!IsDisposed && IsHandleCreated)
            {
                LoadProducts(txtSearch.Text.Trim());
            }
        }

        private void LoadProducts(string searchText = "")
        {
            if (_isLoadingProducts || IsDisposed)
                return;

            if (!CanViewProducts())
            {
                dgvProducts.DataSource = null;
                Hide();
                return;
            }

            _isLoadingProducts = true;

            try
            {
                using (var db = _database.CreateContext())
                {
                    var query = db.Products.AsQueryable();

                    if (!string.IsNullOrWhiteSpace(searchText))
                    {
                        string search = searchText.Trim();

                        query = query.Where(p =>
                            p.Sku.Contains(search) ||
                            p.Name.Contains(search) ||
                            (p.Barcode != null &&
                             p.Barcode.Contains(search)));
                    }

                    string filter = Convert.ToString(
                        cmbProductFilter.SelectedItem);

                    switch (filter)
                    {
                        case "Active Only":
                            query = query.Where(p =>
                                p.IsActive &&
                                p.StockQty > p.ReorderLevel);
                            break;

                        case "Inactive Only":
                            query = query.Where(p => !p.IsActive);
                            break;

                        case "Low Stock Only":
                            query = query.Where(p =>
                                p.IsActive &&
                                p.StockQty > 0 &&
                                p.StockQty <= p.ReorderLevel);
                            break;

                        case "Out of Stock Only":
                            query = query.Where(p =>
                                p.IsActive &&
                                p.StockQty == 0);
                            break;

                        case "All":
                        default:
                            break;
                    }

                    var products = query
                        .OrderBy(p => p.Name)
                        .Select(p => new
                        {
                            p.ProductId,
                            p.Sku,
                            p.Barcode,
                            ProductName = p.Name,
                            p.CategoryId,
                            p.Price,
                            p.Cost,
                            p.StockQty,
                            p.ReorderLevel,
                            p.ImagePath,

                            Status = !p.IsActive
                                ? "INACTIVE"
                                : p.StockQty == 0
                                    ? "OUT OF STOCK"
                                    : p.StockQty <= p.ReorderLevel
                                        ? "LOW STOCK"
                                        : "ACTIVE",

                            p.IsActive
                        })
                        .ToList();

                    dgvProducts.DataSource = null;
                    DisposeProductThumbnails();

                    dgvProducts.DataSource = products;

                    if (!dgvProducts.Columns.Contains("ProductImage"))
                    {
                        var imageColumn = new DataGridViewImageColumn
                        {
                            Name = "ProductImage",
                            HeaderText = "Image",
                            ImageLayout = DataGridViewImageCellLayout.Zoom,
                            ReadOnly = true,
                            FillWeight = 45,
                            MinimumWidth = 65,
                            SortMode = DataGridViewColumnSortMode.NotSortable,
                            DefaultCellStyle = new DataGridViewCellStyle
                            {
                                NullValue = null,
                                Alignment =
                                    DataGridViewContentAlignment.MiddleCenter
                            }
                        };

                        dgvProducts.Columns.Insert(0, imageColumn);
                    }

                    dgvProducts.Columns["ProductImage"].ValueType =
                        typeof(Image);

                    dgvProducts.Columns["ProductImage"]
                        .DefaultCellStyle.NullValue = null;

                    dgvProducts.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;

                    dgvProducts.RowTemplate.Height = 65;
                    dgvProducts.AllowUserToAddRows = false;
                    dgvProducts.AllowUserToDeleteRows = false;
                    dgvProducts.ReadOnly = true;
                    dgvProducts.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;
                    dgvProducts.MultiSelect = false;

                    SetColumnHeader("ProductId", "ID");
                    SetColumnHeader("ProductName", "Product Name");
                    SetColumnHeader("StockQty", "Stock");
                    SetColumnHeader("ReorderLevel", "Reorder Level");
                    SetColumnHeader("Status", "Status");

                    SetColumnFillWeight("Sku", 75);
                    SetColumnFillWeight("ProductName", 150);
                    SetColumnFillWeight("Barcode", 100);
                    SetColumnFillWeight("Price", 75);
                    SetColumnFillWeight("Cost", 75);
                    SetColumnFillWeight("StockQty", 60);
                    SetColumnFillWeight("ReorderLevel", 80);

                    SetColumnVisible("ImagePath", false);
                    SetColumnVisible("IsActive", false);
                    SetColumnVisible("CategoryId", false);

                    foreach (DataGridViewRow row in dgvProducts.Rows)
                    {
                        if (row.IsNewRow)
                            continue;

                        string relativePath = Convert.ToString(
                            row.Cells["ImagePath"].Value);

                        row.Cells["ProductImage"].Value =
                            LoadProductThumbnail(relativePath);
                    }

                    ApplyProductRowColors();

                    lblStatus.Text =
                        products.Count + " product(s) found.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load products.\n\n" + ex.Message,
                    "Product Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _isLoadingProducts = false;
            }
        }

        private void SetColumnFillWeight(
            string columnName, float weight)
        {
            if (dgvProducts.Columns.Contains(columnName))
            {
                dgvProducts.Columns[columnName].FillWeight = weight;
            }
        }

        private void SetColumnHeader(
            string columnName, string headerText)
        {
            if (dgvProducts.Columns.Contains(columnName))
            {
                dgvProducts.Columns[columnName].HeaderText = headerText;
            }
        }

        private void SetColumnVisible(
            string columnName, bool visible)
        {
            if (dgvProducts.Columns.Contains(columnName))
            {
                dgvProducts.Columns[columnName].Visible = visible;
            }
        }

        private Image LoadProductThumbnail(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return null;

            try
            {
                string normalizedPath = relativePath.Replace('\\', '/');
                const string prefix = "ProductImages/";

                if (!normalizedPath.StartsWith(
                    prefix, StringComparison.OrdinalIgnoreCase))
                {
                    return null;
                }

                string fileName = normalizedPath.Substring(prefix.Length);

                if (string.IsNullOrWhiteSpace(fileName) ||
                    fileName != Path.GetFileName(fileName))
                {
                    return null;
                }

                string imageFolder = Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData),
                    "EnterprisePOSPictures",
                    "ProductImages");

                string fullPath = Path.Combine(imageFolder, fileName);

                if (!File.Exists(fullPath))
                    return null;

                using (var stream = new FileStream(
                    fullPath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.ReadWrite))
                using (var source = Image.FromStream(stream))
                {
                    Image thumbnail = new Bitmap(source);
                    _productThumbnails.Add(thumbnail);

                    return thumbnail;
                }
            }
            catch
            {
                return null;
            }
        }

        private void DisposeProductThumbnails()
        {
            foreach (Image thumbnail in _productThumbnails)
            {
                thumbnail.Dispose();
            }

            _productThumbnails.Clear();
        }

        private void ApplyProductRowColors()
        {
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (!row.IsNewRow)
                {
                    ApplyProductRowColor(row);
                }
            }
        }

        private void ApplyProductRowColor(DataGridViewRow row)
        {
            if (!dgvProducts.Columns.Contains("IsActive") ||
                !dgvProducts.Columns.Contains("StockQty") ||
                !dgvProducts.Columns.Contains("ReorderLevel"))
            {
                return;
            }

            if (row.Cells["IsActive"].Value == null ||
                row.Cells["IsActive"].Value == DBNull.Value ||
                row.Cells["StockQty"].Value == null ||
                row.Cells["StockQty"].Value == DBNull.Value ||
                row.Cells["ReorderLevel"].Value == null ||
                row.Cells["ReorderLevel"].Value == DBNull.Value)
            {
                return;
            }

            bool isActive = Convert.ToBoolean(
                row.Cells["IsActive"].Value);

            int stockQty = Convert.ToInt32(
                row.Cells["StockQty"].Value);

            int reorderLevel = Convert.ToInt32(
                row.Cells["ReorderLevel"].Value);

            if (!isActive)
            {
                row.DefaultCellStyle.BackColor = Color.LightGray;
                row.DefaultCellStyle.ForeColor = Color.DimGray;
                row.DefaultCellStyle.SelectionBackColor = Color.Gray;
                row.DefaultCellStyle.SelectionForeColor = Color.White;
            }
            else if (stockQty == 0)
            {
                row.DefaultCellStyle.BackColor =
                    Color.FromArgb(254, 202, 202);
                row.DefaultCellStyle.ForeColor =
                    Color.FromArgb(127, 29, 29);
                row.DefaultCellStyle.SelectionBackColor = Color.Red;
                row.DefaultCellStyle.SelectionForeColor = Color.White;
            }
            else if (stockQty <= reorderLevel)
            {
                row.DefaultCellStyle.BackColor = Color.LightCoral;
                row.DefaultCellStyle.ForeColor = Color.DarkRed;
                row.DefaultCellStyle.SelectionBackColor = Color.Red;
                row.DefaultCellStyle.SelectionForeColor = Color.White;
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.DefaultCellStyle.SelectionBackColor =
                    Color.DodgerBlue;
                row.DefaultCellStyle.SelectionForeColor = Color.White;
            }
        }

        private int? GetSelectedProductId()
        {
            if (dgvProducts.CurrentRow == null ||
                dgvProducts.CurrentRow.IsNewRow ||
                !dgvProducts.Columns.Contains("ProductId"))
            {
                return null;
            }

            object value =
                dgvProducts.CurrentRow.Cells["ProductId"].Value;

            if (value == null || value == DBNull.Value)
                return null;

            int productId;

            if (!int.TryParse(Convert.ToString(value), out productId) ||
                productId <= 0)
            {
                return null;
            }

            return productId;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadProducts(txtSearch.Text);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!CanEditProducts())
                return;

            int? productId = GetSelectedProductId();

            if (!productId.HasValue)
            {
                MessageBox.Show(
                    "Please select a product first.",
                    "Delete Product",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string productName = Convert.ToString(
                dgvProducts.CurrentRow.Cells["ProductName"].Value);

            DialogResult confirm = MessageBox.Show(
                "Permanently delete this product?\n\n" +
                "Product: " + productName + "\n\n" +
                "This action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (var db = _database.CreateContext())
                {
                    bool hasOrderHistory = db.OrderDetails.Any(
                        d => d.ProductId == productId.Value);

                    bool hasInventoryHistory = db.InventoryLogs.Any(
                        i => i.ProductId == productId.Value);

                    if (hasOrderHistory || hasInventoryHistory)
                    {
                        MessageBox.Show(
                            "This product has sales or inventory history.\n\n" +
                            "Permanent deletion is not allowed. " +
                            "Use Deactivate instead to preserve historical records.",
                            "Cannot Delete Product",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    var product = db.Products.FirstOrDefault(
                        p => p.ProductId == productId.Value);

                    if (product == null)
                    {
                        MessageBox.Show(
                            "The product was not found.",
                            "Delete Product",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    db.Products.DeleteOnSubmit(product);
                    db.SubmitChanges();
                }

                MessageBox.Show(
                    "Product deleted successfully.",
                    "Product Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                RefreshProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to delete the product.\n\n" + ex.Message,
                    "Delete Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbProductFilter.SelectedIndex = 0;
            RefreshProducts();
        }

        private void dgvProducts_CellDoubleClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                OpenEditProduct();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CanEditProducts())
                return;

            if (_user == null || _user.UserId <= 0)
            {
                MessageBox.Show(
                    "A valid logged-in user is required to add a product.",
                    "Product Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (var editor = new ProductEditorForm(_user))
            {
                if (editor.ShowDialog() == DialogResult.OK && editor.Saved)
                {
                    RefreshProducts();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenEditProduct();
        }

        private void OpenEditProduct()
        {
            if (!CanEditProducts())
                return;

            int? productId = GetSelectedProductId();

            if (!productId.HasValue)
            {
                MessageBox.Show(
                    "Please select a product first.",
                    "Product Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (_user == null || _user.UserId <= 0)
            {
                MessageBox.Show(
                    "A valid logged-in user is required to edit a product.",
                    "Product Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (var editor =
                new ProductEditorForm(_user, productId.Value))
            {
                if (editor.ShowDialog() == DialogResult.OK && editor.Saved)
                {
                    RefreshProducts();
                }
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (!CanEditProducts())
                return;

            int? productId = GetSelectedProductId();

            if (!productId.HasValue)
            {
                MessageBox.Show(
                    "Please select a product first.",
                    "Product Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to deactivate this product?\n\n" +
                "The product will no longer appear in the active product list.",
                "Confirm Deactivation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (var db = _database.CreateContext())
                {
                    db.usp_Product_Delete(productId, _user.UserId);
                }

                MessageBox.Show(
                    "Product deactivated successfully.",
                    "Product Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                RefreshProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to deactivate the product.\n\n" + ex.Message,
                    "Product Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (RequestClose != null)
            {
                RequestClose(this, EventArgs.Empty);
            }
            else
            {
                Hide();
            }
        }

        private void dgvProducts_RowPrePaint(
            object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.RowIndex >= dgvProducts.Rows.Count)
            {
                return;
            }

            DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

            if (!row.IsNewRow)
            {
                ApplyProductRowColor(row);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            DisposeProductThumbnails();
            base.OnFormClosed(e);
        }
    }
}