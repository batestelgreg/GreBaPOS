namespace EnterprisePOS.WinForms
{
    partial class ProductEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSku;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblStockQty;
        private System.Windows.Forms.Label lblReorderLevel;
        private System.Windows.Forms.Label lblStatus;

        private System.Windows.Forms.TextBox txtSku;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.TextBox txtStockQty;
        private System.Windows.Forms.TextBox txtReorderLevel;

        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private System.Windows.Forms.PictureBox picProductImage;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Button btnRemoveImage;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSku = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblStockQty = new System.Windows.Forms.Label();
            this.lblReorderLevel = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();

            this.txtSku = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.txtStockQty = new System.Windows.Forms.TextBox();
            this.txtReorderLevel = new System.Windows.Forms.TextBox();

            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.picProductImage = new System.Windows.Forms.PictureBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.btnRemoveImage = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picProductImage)).BeginInit();

            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(760, 760);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product Editor";
            this.Load += new System.EventHandler(this.ProductEditorForm_Load);

            // Title
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblTitle.Location = new System.Drawing.Point(28, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(190, 32);
            this.lblTitle.Text = "Product Editor";

            // SKU
            this.lblSku.AutoSize = true;
            this.lblSku.Location = new System.Drawing.Point(32, 88);
            this.lblSku.Name = "lblSku";
            this.lblSku.Text = "SKU *";

            this.txtSku.Location = new System.Drawing.Point(35, 113);
            this.txtSku.Name = "txtSku";
            this.txtSku.Size = new System.Drawing.Size(320, 25);
            this.txtSku.MaxLength = 30;
            this.txtSku.TabIndex = 0;

            // Barcode
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(395, 88);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Text = "Barcode";

            this.txtBarcode.Location = new System.Drawing.Point(398, 113);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(320, 25);
            this.txtBarcode.MaxLength = 50;
            this.txtBarcode.TabIndex = 1;

            // Product Name
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(32, 157);
            this.lblName.Name = "lblName";
            this.lblName.Text = "Product Name *";

            this.txtName.Location = new System.Drawing.Point(35, 182);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(683, 25);
            this.txtName.MaxLength = 150;
            this.txtName.TabIndex = 2;

            // Category
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(32, 226);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Text = "Category *";

            this.cmbCategory.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(35, 251);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(683, 25);
            this.cmbCategory.TabIndex = 3;

            // Price
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(32, 295);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Text = "Selling Price *";

            this.txtPrice.Location = new System.Drawing.Point(35, 320);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(320, 25);
            this.txtPrice.TabIndex = 4;

            // Cost
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(395, 295);
            this.lblCost.Name = "lblCost";
            this.lblCost.Text = "Cost *";

            this.txtCost.Location = new System.Drawing.Point(398, 320);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(320, 25);
            this.txtCost.TabIndex = 5;

            // Stock Quantity
            this.lblStockQty.AutoSize = true;
            this.lblStockQty.Location = new System.Drawing.Point(32, 364);
            this.lblStockQty.Name = "lblStockQty";
            this.lblStockQty.Text = "Stock Quantity *";

            this.txtStockQty.Location = new System.Drawing.Point(35, 389);
            this.txtStockQty.Name = "txtStockQty";
            this.txtStockQty.Size = new System.Drawing.Size(320, 25);
            this.txtStockQty.TabIndex = 6;

            // Reorder Level
            this.lblReorderLevel.AutoSize = true;
            this.lblReorderLevel.Location = new System.Drawing.Point(395, 364);
            this.lblReorderLevel.Name = "lblReorderLevel";
            this.lblReorderLevel.Text = "Reorder Level *";

            this.txtReorderLevel.Location = new System.Drawing.Point(398, 389);
            this.txtReorderLevel.Name = "txtReorderLevel";
            this.txtReorderLevel.Size = new System.Drawing.Size(320, 25);
            this.txtReorderLevel.TabIndex = 7;

            // Active checkbox
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState =
                System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(35, 440);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(130, 23);
            this.chkIsActive.TabIndex = 8;
            this.chkIsActive.Text = "Active Product";
            this.chkIsActive.UseVisualStyleBackColor = true;

            // Status
            this.lblStatus.AutoSize = false;
            this.lblStatus.ForeColor =
                System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblStatus.Location = new System.Drawing.Point(35, 477);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(683, 40);
            this.lblStatus.Text = "Fields marked with * are required.";
            this.lblStatus.TabIndex = 9;

            // Product Image Preview
            this.picProductImage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picProductImage.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProductImage.Location = new System.Drawing.Point(35, 535);
            this.picProductImage.Name = "picProductImage";
            this.picProductImage.Size = new System.Drawing.Size(260, 170);
            this.picProductImage.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProductImage.TabIndex = 10;
            this.picProductImage.TabStop = false;

            // Browse Image
            this.btnBrowseImage.Location = new System.Drawing.Point(320, 555);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(160, 42);
            this.btnBrowseImage.TabIndex = 11;
            this.btnBrowseImage.Text = "Browse Image";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click +=
                new System.EventHandler(this.btnBrowseImage_Click);

            // Remove Image
            this.btnRemoveImage.Location = new System.Drawing.Point(320, 610);
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Size = new System.Drawing.Size(160, 42);
            this.btnRemoveImage.TabIndex = 12;
            this.btnRemoveImage.Text = "Remove Image";
            this.btnRemoveImage.UseVisualStyleBackColor = true;
            this.btnRemoveImage.Click +=
                new System.EventHandler(this.btnRemoveImage_Click);

            // Save button
            this.btnSave.BackColor =
                System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(428, 690);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 38);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save Product";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click +=
                new System.EventHandler(this.btnSave_Click);

            // Cancel button
            this.btnCancel.DialogResult =
                System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(578, 690);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 38);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click +=
                new System.EventHandler(this.btnCancel_Click);

            // Add controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSku);
            this.Controls.Add(this.txtSku);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.lblStockQty);
            this.Controls.Add(this.txtStockQty);
            this.Controls.Add(this.lblReorderLevel);
            this.Controls.Add(this.txtReorderLevel);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.picProductImage);
            this.Controls.Add(this.btnBrowseImage);
            this.Controls.Add(this.btnRemoveImage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;

            ((System.ComponentModel.ISupportInitialize)(this.picProductImage)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}