using EnterprisePOS.Data;
using EnterprisePOS.Data.Repositories;
using EnterprisePOS.Domain.Class;
using EnterprisePOS.Services.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnterprisePOS.WinForms
{
    public partial class ProductEditorForm : Form
    {
        private readonly DatabaseRepository _database;
        private readonly UserSession _user;
        private readonly int? _productId;

        private string _selectedImagePath;
        private bool _removeExistingImage;
        private const long MaxImageSizeBytes = 5 * 1024 * 1024;
        private const int MaxImageDimension = 4000;

        private readonly UserAdministrationService _authorizationService =
    new UserAdministrationService();

        public bool Saved { get; private set; }

        public ProductEditorForm(UserSession user)
        {
            InitializeComponent();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _database = new DatabaseRepository();
            _user = user;
            _productId = null;

            lblTitle.Text = "Add New Product";
            btnSave.Text = "Save Product";
        }

        public ProductEditorForm(UserSession user, int productId)
            : this(user)
        {
            if (productId <= 0)
                throw new ArgumentOutOfRangeException(nameof(productId));

            _productId = productId;

            lblTitle.Text = "Edit Product";
            btnSave.Text = "Update Product";

            txtStockQty.ReadOnly = true;
            txtStockQty.BackColor = Color.FromArgb(241, 245, 249);
        }

        private void ProductEditorForm_Load(object sender, EventArgs e)
        {
            if (!RequireProductEditPermission())
            {
                btnSave.Enabled = false;
                btnBrowseImage.Enabled = false;
                btnRemoveImage.Enabled = false;

                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            LoadCategories();

            if (_productId.HasValue)
            {
                LoadProductForEditing(_productId.Value);
            }
            else
            {
                txtStockQty.Text = "0";
                txtReorderLevel.Text = "5";
                txtPrice.Text = "0.00";
                txtCost.Text = "0.00";
                chkIsActive.Checked = true;
                ShowImagePlaceholder();
            }
        }

        private void LoadCategories()
        {
            try
            {
                using (var db = _database.CreateContext())
                {
                    var categories = db.Categories
                        .OrderBy(c => c.Name)
                        .Select(c => new
                        {
                            c.CategoryId,
                            c.Name
                        })
                        .ToList();

                    cmbCategory.DataSource = categories;
                    cmbCategory.DisplayMember = "Name";
                    cmbCategory.ValueMember = "CategoryId";
                    cmbCategory.SelectedIndex = -1;
                }

                if (cmbCategory.Items.Count == 0)
                {
                    lblStatus.Text =
                        "No categories found. Add a category before saving.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load categories.\n\n" + ex.Message,
                    "Category Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadProductForEditing(int productId)
        {
            try
            {
                using (var db = _database.CreateContext())
                {
                    var product = db.Products
                        .FirstOrDefault(p => p.ProductId == productId);

                    if (product == null)
                    {
                        MessageBox.Show(
                            "The selected product was not found.",
                            "Product Not Found",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        DialogResult = DialogResult.Cancel;
                        Close();
                        return;
                    }

                    txtSku.Text = product.Sku;
                    txtBarcode.Text = product.Barcode ?? "";
                    txtName.Text = product.Name;
                    txtPrice.Text = product.Price.ToString(
                        "0.00", CultureInfo.CurrentCulture);
                    txtCost.Text = product.Cost.ToString(
                        "0.00", CultureInfo.CurrentCulture);
                    txtStockQty.Text = product.StockQty.ToString();
                    txtReorderLevel.Text = product.ReorderLevel.ToString();

                    chkIsActive.Checked = product.IsActive;
                    cmbCategory.SelectedValue = product.CategoryId;

                    LoadProductImage(product.ImagePath);

                    lblStatus.Text =
                        "Stock quantity is read-only in edit mode. " +
                        "Use Inventory Management to adjust stock.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load the selected product.\n\n" +
                    ex.Message,
                    "Product Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadProductImage(string relativePath)
        {
            _selectedImagePath = null;
            _removeExistingImage = false;

            if (string.IsNullOrWhiteSpace(relativePath))
            {
                ShowImagePlaceholder();
                return;
            }

            try
            {
                string fullPath = GetSafeImageFullPath(relativePath);

                if (!File.Exists(fullPath))
                {
                    ShowImagePlaceholder();
                    lblStatus.Text =
                        "The saved image file is missing. You can select another image.";
                    return;
                }

                using (var stream = new FileStream(
                    fullPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (var tempImage = Image.FromStream(stream))
                {
                    picProductImage.Image = new Bitmap(tempImage);
                }
            }
            catch
            {
                ShowImagePlaceholder();
                lblStatus.Text =
                    "The saved image could not be loaded. You can select another image.";
            }
        }

        private void ShowImagePlaceholder()
        {
            if (picProductImage.Image != null)
            {
                Image oldImage = picProductImage.Image;
                picProductImage.Image = null;
                oldImage.Dispose();
            }

            picProductImage.BackColor = Color.WhiteSmoke;
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select Product Image";
                dialog.Filter =
                    "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                dialog.Multiselect = false;
                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;

                if (dialog.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    // Check the actual file size before loading the image.
                    FileInfo fileInfo = new FileInfo(dialog.FileName);

                    if (!fileInfo.Exists)
                    {
                        MessageBox.Show(
                            "The selected image file does not exist.",
                            "Invalid Image",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    if (fileInfo.Length == 0)
                    {
                        MessageBox.Show(
                            "The selected image file is empty.",
                            "Invalid Image Size",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    if (fileInfo.Length > MaxImageSizeBytes)
                    {
                        MessageBox.Show(
                            "The image exceeds the 5 MB limit.\n\n" +
                            "Selected file size: " +
                            (fileInfo.Length / (1024.0 * 1024.0))
                                .ToString("0.00") + " MB\n" +
                            "Please select a smaller image.",
                            "Image Too Large",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    // Check extension before decoding the image.
                    string extension =
                        Path.GetExtension(dialog.FileName).ToLowerInvariant();

                    if (extension != ".jpg" &&
                        extension != ".jpeg" &&
                        extension != ".png")
                    {
                        MessageBox.Show(
                            "Only JPG, JPEG, and PNG files are allowed.",
                            "Invalid Image Type",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    // Validate that the file contains a readable image
                    // and that its dimensions are within the allowed limit.
                    using (var stream = new FileStream(
                        dialog.FileName,
                        FileMode.Open,
                        FileAccess.Read,
                        FileShare.Read))
                    using (var image = Image.FromStream(stream, false, true))
                    {
                        if (image.Width <= 0 || image.Height <= 0 ||
                            image.Width > MaxImageDimension ||
                            image.Height > MaxImageDimension)
                        {
                            MessageBox.Show(
                                "Image dimensions must not exceed " +
                                "4000 × 4000 pixels.",
                                "Invalid Image Dimensions",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        using (var bitmap = new Bitmap(image))
                        {
                            SetPreviewImage(new Bitmap(bitmap));
                        }
                    }

                    // Update the selected image only after validation succeeds.
                    _selectedImagePath = dialog.FileName;
                    _removeExistingImage = false;

                    lblStatus.Text =
                        "Image selected. Save the product to apply the change.";
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show(
                        "The selected file is not a valid or supported image.",
                        "Invalid Image",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Unable to validate or load the selected image.\n\n" +
                        ex.Message,
                        "Image Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        private void SetPreviewImage(Image image)
        {
            Image oldImage = picProductImage.Image;
            picProductImage.Image = image;

            if (oldImage != null)
                oldImage.Dispose();

            picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
            picProductImage.BackColor = Color.WhiteSmoke;
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            _selectedImagePath = null;
            _removeExistingImage = true;
            ShowImagePlaceholder();

            lblStatus.Text =
                "Image removal selected. Save the product to apply the change.";
        }

        private string SaveImageToManagedFolder(string sourcePath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath) ||
                !File.Exists(sourcePath))
            {
                throw new FileNotFoundException(
                    "The selected image file could not be found.",
                    sourcePath);
            }

            string extension = Path.GetExtension(sourcePath).ToLowerInvariant();

            if (extension != ".jpg" &&
                extension != ".jpeg" &&
                extension != ".png")
            {
                throw new InvalidOperationException(
                    "Only JPG, JPEG, and PNG images are allowed.");
            }

            string imageFolder = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "EnterprisePOSPictures",
                "ProductImages");

            Directory.CreateDirectory(imageFolder);

            string safeFileName = Guid.NewGuid().ToString("N") + extension;
            string destinationPath = Path.Combine(imageFolder, safeFileName);

            File.Copy(sourcePath, destinationPath, false);

            // Store the filename relative to the permanent image folder.
            return "ProductImages/" + safeFileName;
        }

        private string GetSafeImageFullPath(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                throw new InvalidOperationException("Image path is empty.");

            string normalized = relativePath.Replace('\\', '/');

            if (Path.IsPathRooted(normalized))
                throw new InvalidOperationException("Rooted image paths are not allowed.");

            string prefix = "ProductImages/";
            if (!normalized.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("Image path is outside the ProductImages folder.");

            string fileName = Path.GetFileName(normalized);

            // Gamiton ang parehong LocalApplicationData folder kung asa gi save
            string imageFolder = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "EnterprisePOSPictures",
                "ProductImages");

            string fullPath = Path.Combine(imageFolder, fileName);

            return fullPath;
        }

        private bool ValidateInputs(
            out decimal price,
            out decimal cost,
            out int stockQty,
            out int reorderLevel)
        {
            price = 0m;
            cost = 0m;
            stockQty = 0;
            reorderLevel = 0;

            if (string.IsNullOrWhiteSpace(txtSku.Text))
            {
                ShowValidationError("SKU is required.", txtSku);
                return false;
            }

            if (txtSku.Text.Trim().Length > 30)
            {
                ShowValidationError("SKU cannot exceed 30 characters.", txtSku);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                ShowValidationError("Product name is required.", txtName);
                return false;
            }

            if (txtName.Text.Trim().Length > 150)
            {
                ShowValidationError(
                    "Product name cannot exceed 150 characters.", txtName);
                return false;
            }

            if (txtBarcode.Text.Trim().Length > 50)
            {
                ShowValidationError(
                    "Barcode cannot exceed 50 characters.", txtBarcode);
                return false;
            }

            if (cmbCategory.SelectedValue == null ||
                cmbCategory.SelectedIndex < 0)
            {
                ShowValidationError("Please select a category.", cmbCategory);
                return false;
            }

            if (!decimal.TryParse(
                txtPrice.Text.Trim(), NumberStyles.Number,
                CultureInfo.CurrentCulture, out price))
            {
                ShowValidationError(
                    "Enter a valid decimal price, such as 99.50.", txtPrice);
                return false;
            }

            if (price < 0 || decimal.Round(price, 2) != price)
            {
                ShowValidationError(
                    "Price must be non-negative and have at most two decimal places.",
                    txtPrice);
                return false;
            }

            if (!decimal.TryParse(
                txtCost.Text.Trim(), NumberStyles.Number,
                CultureInfo.CurrentCulture, out cost))
            {
                ShowValidationError(
                    "Enter a valid decimal cost, such as 50.00.", txtCost);
                return false;
            }

            if (cost < 0 || decimal.Round(cost, 2) != cost)
            {
                ShowValidationError(
                    "Cost must be non-negative and have at most two decimal places.",
                    txtCost);
                return false;
            }

            if (!int.TryParse(
                txtStockQty.Text.Trim(), NumberStyles.Integer,
                CultureInfo.CurrentCulture, out stockQty) || stockQty < 0)
            {
                ShowValidationError(
                    "Stock quantity must be a non-negative whole number.",
                    txtStockQty);
                return false;
            }

            if (!int.TryParse(
                txtReorderLevel.Text.Trim(), NumberStyles.Integer,
                CultureInfo.CurrentCulture, out reorderLevel) ||
                reorderLevel < 0)
            {
                ShowValidationError(
                    "Reorder level must be a non-negative whole number.",
                    txtReorderLevel);
                return false;
            }

            return true;
        }

        private void ShowValidationError(string message, Control control)
        {
            MessageBox.Show(
                message, "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            control.Focus();

            if (control is TextBox textBox)
                textBox.SelectAll();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!RequireProductEditPermission())
                return;

            decimal price;
            decimal cost;
            int stockQty;
            int reorderLevel;

            if (!ValidateInputs(out price, out cost, out stockQty, out reorderLevel))
                return;

            int categoryId;

            try
            {
                categoryId = Convert.ToInt32(cmbCategory.SelectedValue);
            }
            catch
            {
                ShowValidationError("Please select a valid category.", cmbCategory);
                return;
            }

            string sku = txtSku.Text.Trim();
            string barcode = string.IsNullOrWhiteSpace(txtBarcode.Text)
                ? null
                : txtBarcode.Text.Trim();
            string productName = txtName.Text.Trim();

            btnSave.Enabled = false;
            string newlySavedImagePath = null;

            try
            {
                using (var db = _database.CreateContext())
                {
                    var product = _productId.HasValue
                        ? db.Products.FirstOrDefault(
                            p => p.ProductId == _productId.Value)
                        : null;

                    if (_productId.HasValue && product == null)
                    {
                        throw new InvalidOperationException(
                            "The product to update could not be found.");
                    }

                    bool duplicateSku;

                    if (_productId.HasValue)
                    {
                        int currentProductId = _productId.Value;

                        duplicateSku = db.Products.Any(p =>
                            p.Sku == sku &&
                            p.ProductId != currentProductId);
                    }
                    else
                    {
                        duplicateSku = db.Products.Any(p =>
                            p.Sku == sku);
                    }

                    if (duplicateSku)
                    {
                        ShowValidationError(
                            "This SKU already exists. Please use a unique SKU.",
                            txtSku);
                        return;
                    }

                    string newImagePath = null;

                    if (_selectedImagePath != null)
                    {
                        newImagePath =
                            SaveImageToManagedFolder(_selectedImagePath);

                        newlySavedImagePath = newImagePath;
                    }

                    if (_productId.HasValue)
                    {
                        bool changeImage =
                            _selectedImagePath != null || _removeExistingImage;

                        string imagePath = _removeExistingImage
                            ? null
                            : newImagePath;

                        // Update all product fields, including the image when changed,
                        // through the stored procedure only.
                        db.usp_Product_Update(
    _productId,
    sku,
    barcode,
    productName,
    categoryId,
    price,
    cost,
    reorderLevel,
    chkIsActive.Checked,
    imagePath,
    changeImage,
    _user.UserId
);
                    }
                    else
                    {
                        db.usp_Product_Insert(
                            sku,
                            barcode,
                            productName,
                            categoryId,
                            price,
                            cost,
                            stockQty,
                            reorderLevel,
                            newImagePath,
                            _user.UserId);
                    }
                }

                Saved = true;
                DialogResult = DialogResult.OK;

                MessageBox.Show(
                    _productId.HasValue
                        ? "Product updated successfully."
                        : "Product added successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    MessageBox.Show(
                        "The SKU or barcode already exists. Please use unique values.\n\n" +
                        ex.Message,
                        "Duplicate Product Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "SQL Server could not save the product.\n\n" + ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                DeleteUnusedSavedImage(newlySavedImagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Full Save Error Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                DeleteUnusedSavedImage(newlySavedImagePath);
            }
            finally
            {
                if (!IsDisposed)
                    btnSave.Enabled = true;
            }
        }


        private void DeleteUnusedSavedImage(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return;

            try
            {
                string fullPath = GetSafeImageFullPath(relativePath);

                if (File.Exists(fullPath))
                    File.Delete(fullPath);
            }
            catch
            {
                // Do not hide the original save error.
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (picProductImage.Image != null)
            {
                Image oldImage = picProductImage.Image;
                picProductImage.Image = null;
                oldImage.Dispose();
            }

            base.OnFormClosed(e);
        }

        private bool HasProductEditPermission()
        {
            if (_user == null || _user.UserId <= 0)
                return false;

            try
            {
                return _authorizationService.HasPermission(
                    _user.UserId,
                    "Products.Edit");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to verify your permission. The operation was cancelled.\n\n" +
                    ex.Message,
                    "Permission Verification Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        private bool RequireProductEditPermission()
        {
            if (HasProductEditPermission())
                return true;

            MessageBox.Show(
                "Access Denied. You do not have permission to add or edit products.",
                "Permission Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return false;
        }
    }
}