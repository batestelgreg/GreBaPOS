namespace EnterprisePOS.WinForms
{
    partial class SalesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.NumericUpDown nudQty;
        private System.Windows.Forms.Button btnAdd;

        private System.Windows.Forms.Panel pnlProducts;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvProducts;

        private System.Windows.Forms.Panel pnlCart;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Button btnQtyMinus;
        private System.Windows.Forms.Button btnQtyPlus;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnClearCart;

        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Button btnAddCustomer;

        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.NumericUpDown nudDiscount;

        private System.Windows.Forms.Panel pnlTotals;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblSubtotalValue;
        private System.Windows.Forms.Label lblDiscountAmount;
        private System.Windows.Forms.Label lblDiscountValue;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblTaxValue;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalValue;

        private System.Windows.Forms.Button btnCheckout;

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

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.nudQty = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();

            this.pnlProducts = new System.Windows.Forms.Panel();
            this.lblProducts = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();

            this.pnlCart = new System.Windows.Forms.Panel();
            this.lblCart = new System.Windows.Forms.Label();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.btnQtyMinus = new System.Windows.Forms.Button();
            this.btnQtyPlus = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnClearCart = new System.Windows.Forms.Button();

            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.btnAddCustomer = new System.Windows.Forms.Button();

            this.lblDiscount = new System.Windows.Forms.Label();
            this.nudDiscount = new System.Windows.Forms.NumericUpDown();

            this.pnlTotals = new System.Windows.Forms.Panel();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblSubtotalValue = new System.Windows.Forms.Label();
            this.lblDiscountAmount = new System.Windows.Forms.Label();
            this.lblDiscountValue = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblTaxValue = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();

            this.btnCheckout = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();

            this.pnlHeader.SuspendLayout();
            this.pnlProducts.SuspendLayout();
            this.pnlCart.SuspendLayout();
            this.pnlTotals.SuspendLayout();
            this.SuspendLayout();

            // FORM
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 760);
            this.MinimumSize = new System.Drawing.Size(1000, 680);
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(38, 50, 70);
            this.Text = "EnterprisePOS - Sales Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyPreview = true;

            // HEADER
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(25, 48, 86);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 125;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblBarcode);
            this.pnlHeader.Controls.Add(this.txtBarcode);
            this.pnlHeader.Controls.Add(this.lblQty);
            this.pnlHeader.Controls.Add(this.nudQty);
            this.pnlHeader.Controls.Add(this.btnAdd);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Text = "SALES MANAGEMENT";

            this.lblBarcode.AutoSize = true;
            this.lblBarcode.ForeColor = System.Drawing.Color.White;
            this.lblBarcode.Location = new System.Drawing.Point(22, 76);
            this.lblBarcode.Text = "Barcode / SKU";

            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtBarcode.Location = new System.Drawing.Point(125, 70);
            this.txtBarcode.Size = new System.Drawing.Size(310, 27);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.TabIndex = 0;

            this.lblQty.AutoSize = true;
            this.lblQty.ForeColor = System.Drawing.Color.White;
            this.lblQty.Location = new System.Drawing.Point(455, 76);
            this.lblQty.Text = "Qty";

            this.nudQty.Location = new System.Drawing.Point(490, 72);
            this.nudQty.Minimum = 1;
            this.nudQty.Maximum = 999;
            this.nudQty.Value = 1;
            this.nudQty.Size = new System.Drawing.Size(65, 23);
            this.nudQty.Name = "nudQty";
            this.nudQty.TabIndex = 1;

            this.btnAdd.Location = new System.Drawing.Point(570, 68);
            this.btnAdd.Size = new System.Drawing.Size(110, 34);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Text = "ADD ITEM";
            this.btnAdd.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(45, 105, 190);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.TabIndex = 2;

            // PRODUCTS PANEL
            this.pnlProducts.Location = new System.Drawing.Point(20, 145);
            this.pnlProducts.Size = new System.Drawing.Size(570, 590);
            this.pnlProducts.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            this.pnlProducts.BackColor = System.Drawing.Color.White;
            this.pnlProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProducts.Controls.Add(this.lblProducts);
            this.pnlProducts.Controls.Add(this.txtSearch);
            this.pnlProducts.Controls.Add(this.btnSearch);
            this.pnlProducts.Controls.Add(this.dgvProducts);

            this.lblProducts.AutoSize = true;
            this.lblProducts.Font = new System.Drawing.Font(
                "Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProducts.Location = new System.Drawing.Point(15, 15);
            this.lblProducts.Text = "PRODUCT LIST";

            this.txtSearch.Location = new System.Drawing.Point(18, 52);
            this.txtSearch.Size = new System.Drawing.Size(390, 25);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.TabIndex = 3;

            this.btnSearch.Location = new System.Drawing.Point(418, 49);
            this.btnSearch.Size = new System.Drawing.Size(130, 31);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Text = "Search";
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(45, 105, 190);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.TabIndex = 4;

            this.dgvProducts.Location = new System.Drawing.Point(15, 95);
            this.dgvProducts.Size = new System.Drawing.Size(536, 475);
            this.dgvProducts.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProducts.GridColor = System.Drawing.Color.FromArgb(225, 231, 239);
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.TabIndex = 5;

            // CART PANEL
            this.pnlCart.Location = new System.Drawing.Point(605, 145);
            this.pnlCart.Size = new System.Drawing.Size(625, 590);
            this.pnlCart.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.pnlCart.BackColor = System.Drawing.Color.White;
            this.pnlCart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.pnlCart.Controls.Add(this.lblCart);
            this.pnlCart.Controls.Add(this.dgvCart);
            this.pnlCart.Controls.Add(this.btnQtyMinus);
            this.pnlCart.Controls.Add(this.btnQtyPlus);
            this.pnlCart.Controls.Add(this.btnRemoveItem);
            this.pnlCart.Controls.Add(this.btnClearCart);
            this.pnlCart.Controls.Add(this.lblCustomer);
            this.pnlCart.Controls.Add(this.cmbCustomer);
            this.pnlCart.Controls.Add(this.btnAddCustomer);
            this.pnlCart.Controls.Add(this.lblDiscount);
            this.pnlCart.Controls.Add(this.nudDiscount);
            this.pnlCart.Controls.Add(this.pnlTotals);
            this.pnlCart.Controls.Add(this.btnCheckout);

            this.lblCart.AutoSize = true;
            this.lblCart.Font = new System.Drawing.Font(
                "Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCart.Location = new System.Drawing.Point(15, 15);
            this.lblCart.Text = "CHECKOUT CART";

            this.dgvCart.Location = new System.Drawing.Point(15, 50);
            this.dgvCart.Size = new System.Drawing.Size(591, 250);
            this.dgvCart.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCart.GridColor = System.Drawing.Color.FromArgb(225, 231, 239);
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.ReadOnly = false;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.MultiSelect = false;
            this.dgvCart.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.TabIndex = 6;

            // CART ACTION BUTTONS
            this.btnQtyMinus.Location = new System.Drawing.Point(15, 310);
            this.btnQtyMinus.Size = new System.Drawing.Size(38, 30);
            this.btnQtyMinus.Name = "btnQtyMinus";
            this.btnQtyMinus.Text = "-";
            this.btnQtyMinus.Font = new System.Drawing.Font(
                "Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQtyMinus.UseVisualStyleBackColor = true;
            this.btnQtyMinus.TabIndex = 7;

            this.btnQtyPlus.Location = new System.Drawing.Point(58, 310);
            this.btnQtyPlus.Size = new System.Drawing.Size(38, 30);
            this.btnQtyPlus.Name = "btnQtyPlus";
            this.btnQtyPlus.Text = "+";
            this.btnQtyPlus.Font = new System.Drawing.Font(
                "Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQtyPlus.UseVisualStyleBackColor = true;
            this.btnQtyPlus.TabIndex = 8;

            this.btnRemoveItem.Location = new System.Drawing.Point(110, 310);
            this.btnRemoveItem.Size = new System.Drawing.Size(115, 30);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.BackColor = System.Drawing.Color.FromArgb(190, 55, 65);
            this.btnRemoveItem.ForeColor = System.Drawing.Color.White;
            this.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItem.FlatAppearance.BorderSize = 0;
            this.btnRemoveItem.UseVisualStyleBackColor = false;
            this.btnRemoveItem.TabIndex = 9;

            this.btnClearCart.Location = new System.Drawing.Point(235, 310);
            this.btnClearCart.Size = new System.Drawing.Size(100, 30);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Text = "Clear Cart";
            this.btnClearCart.UseVisualStyleBackColor = true;
            this.btnClearCart.TabIndex = 10;

            // CUSTOMER
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(15, 357);
            this.lblCustomer.Text = "Customer";

            this.cmbCustomer.Location = new System.Drawing.Point(100, 353);
            this.cmbCustomer.Size = new System.Drawing.Size(390, 25);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.TabIndex = 11;

            this.btnAddCustomer.Location = new System.Drawing.Point(500, 350);
            this.btnAddCustomer.Size = new System.Drawing.Size(106, 30);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Text = "+ Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.TabIndex = 12;

            // DISCOUNT
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(15, 394);
            this.lblDiscount.Text = "Discount (%)";

            this.nudDiscount.Location = new System.Drawing.Point(100, 390);
            this.nudDiscount.Size = new System.Drawing.Size(100, 23);
            this.nudDiscount.Name = "nudDiscount";
            this.nudDiscount.DecimalPlaces = 2;
            this.nudDiscount.Minimum = 0;
            this.nudDiscount.Maximum = 100;
            this.nudDiscount.TabIndex = 13;

            // TOTALS PANEL
            this.pnlTotals.Location = new System.Drawing.Point(15, 425);
            this.pnlTotals.Size = new System.Drawing.Size(591, 112);
            this.pnlTotals.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.pnlTotals.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.pnlTotals.Controls.Add(this.lblSubtotal);
            this.pnlTotals.Controls.Add(this.lblSubtotalValue);
            this.pnlTotals.Controls.Add(this.lblDiscountAmount);
            this.pnlTotals.Controls.Add(this.lblDiscountValue);
            this.pnlTotals.Controls.Add(this.lblTax);
            this.pnlTotals.Controls.Add(this.lblTaxValue);
            this.pnlTotals.Controls.Add(this.lblTotal);
            this.pnlTotals.Controls.Add(this.lblTotalValue);

            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(12, 9);
            this.lblSubtotal.Text = "Subtotal";

            this.lblSubtotalValue.AutoSize = false;
            this.lblSubtotalValue.Location = new System.Drawing.Point(350, 9);
            this.lblSubtotalValue.Size = new System.Drawing.Size(225, 20);
            this.lblSubtotalValue.Text = "₱0.00";
            this.lblSubtotalValue.TextAlign =
                System.Drawing.ContentAlignment.MiddleRight;

            this.lblDiscountAmount.AutoSize = true;
            this.lblDiscountAmount.Location = new System.Drawing.Point(12, 33);
            this.lblDiscountAmount.Text = "Discount";

            this.lblDiscountValue.AutoSize = false;
            this.lblDiscountValue.Location = new System.Drawing.Point(350, 33);
            this.lblDiscountValue.Size = new System.Drawing.Size(225, 20);
            this.lblDiscountValue.Text = "₱0.00";
            this.lblDiscountValue.TextAlign =
                System.Drawing.ContentAlignment.MiddleRight;

            this.lblTax.AutoSize = true;
            this.lblTax.Location = new System.Drawing.Point(12, 57);
            this.lblTax.Text = "Tax (8%)";

            this.lblTaxValue.AutoSize = false;
            this.lblTaxValue.Location = new System.Drawing.Point(350, 57);
            this.lblTaxValue.Size = new System.Drawing.Size(225, 20);
            this.lblTaxValue.Text = "₱0.00";
            this.lblTaxValue.TextAlign =
                System.Drawing.ContentAlignment.MiddleRight;

            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font(
                "Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(12, 81);
            this.lblTotal.Text = "TOTAL";

            this.lblTotalValue.AutoSize = false;
            this.lblTotalValue.Font = new System.Drawing.Font(
                "Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.FromArgb(37, 99, 190);
            this.lblTotalValue.Location = new System.Drawing.Point(300, 76);
            this.lblTotalValue.Size = new System.Drawing.Size(275, 30);
            this.lblTotalValue.Text = "₱0.00";
            this.lblTotalValue.TextAlign =
                System.Drawing.ContentAlignment.MiddleRight;

            // CHECKOUT BUTTON
            this.btnCheckout.Location = new System.Drawing.Point(15, 545);
            this.btnCheckout.Size = new System.Drawing.Size(591, 36);
            this.btnCheckout.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Text = "CHECKOUT  (F9)";
            this.btnCheckout.Font = new System.Drawing.Font(
                "Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(22, 130, 82);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.TabIndex = 14;

            // ADD TO FORM
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlProducts);
            this.Controls.Add(this.pnlCart);

            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).EndInit();

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlProducts.ResumeLayout(false);
            this.pnlProducts.PerformLayout();
            this.pnlCart.ResumeLayout(false);
            this.pnlCart.PerformLayout();
            this.pnlTotals.ResumeLayout(false);
            this.pnlTotals.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}