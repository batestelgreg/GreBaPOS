namespace EnterprisePOS.WinForms
{
    partial class AnalyticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TableLayoutPanel pnlSummary;
        private System.Windows.Forms.Panel pnlOrdersCard;
        private System.Windows.Forms.Panel pnlGrossCard;
        private System.Windows.Forms.Panel pnlNetCard;
        private System.Windows.Forms.Panel pnlTaxCard;
        private System.Windows.Forms.Panel pnlDiscountCard;
        private System.Windows.Forms.Label lblOrdersCaption;
        private System.Windows.Forms.Label lblGrossCaption;
        private System.Windows.Forms.Label lblNetCaption;
        private System.Windows.Forms.Label lblTaxCaption;
        private System.Windows.Forms.Label lblDiscountCaption;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label lblTotalGross;
        private System.Windows.Forms.Label lblTotalNet;
        private System.Windows.Forms.Label lblTotalTax;
        private System.Windows.Forms.Label lblTotalDiscount;
        private System.Windows.Forms.TabControl tabReports;
        private System.Windows.Forms.TabPage tabDaily;
        private System.Windows.Forms.TabPage tabTopProducts;
        private System.Windows.Forms.TabPage tabCashiers;
        private System.Windows.Forms.TabPage tabCategories;
        private System.Windows.Forms.TabPage tabInventory;
        private System.Windows.Forms.DataGridView dgvDailySales;
        private System.Windows.Forms.DataGridView dgvTopProducts;
        private System.Windows.Forms.DataGridView dgvCashierSales;
        private System.Windows.Forms.DataGridView dgvCategorySales;
        private System.Windows.Forms.DataGridView dgvInventoryValuation;
        private System.Windows.Forms.Label lblReportHint;


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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();

            this.pnlFilters = new System.Windows.Forms.Panel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();

            this.pnlSummary = new System.Windows.Forms.TableLayoutPanel();
            this.pnlOrdersCard = new System.Windows.Forms.Panel();
            this.pnlGrossCard = new System.Windows.Forms.Panel();
            this.pnlNetCard = new System.Windows.Forms.Panel();
            this.pnlTaxCard = new System.Windows.Forms.Panel();
            this.pnlDiscountCard = new System.Windows.Forms.Panel();

            this.lblOrdersCaption = new System.Windows.Forms.Label();
            this.lblGrossCaption = new System.Windows.Forms.Label();
            this.lblNetCaption = new System.Windows.Forms.Label();
            this.lblTaxCaption = new System.Windows.Forms.Label();
            this.lblDiscountCaption = new System.Windows.Forms.Label();

            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.lblTotalGross = new System.Windows.Forms.Label();
            this.lblTotalNet = new System.Windows.Forms.Label();
            this.lblTotalTax = new System.Windows.Forms.Label();
            this.lblTotalDiscount = new System.Windows.Forms.Label();

            this.tabReports = new System.Windows.Forms.TabControl();
            this.tabDaily = new System.Windows.Forms.TabPage();
            this.tabTopProducts = new System.Windows.Forms.TabPage();
            this.tabCashiers = new System.Windows.Forms.TabPage();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.tabInventory = new System.Windows.Forms.TabPage();

            this.dgvDailySales = new System.Windows.Forms.DataGridView();
            this.dgvTopProducts = new System.Windows.Forms.DataGridView();
            this.dgvCashierSales = new System.Windows.Forms.DataGridView();
            this.dgvCategorySales = new System.Windows.Forms.DataGridView();
            this.dgvInventoryValuation = new System.Windows.Forms.DataGridView();

            this.lblReportHint = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.tabReports.SuspendLayout();

            this.tabDaily.SuspendLayout();
            this.tabTopProducts.SuspendLayout();
            this.tabCashiers.SuspendLayout();
            this.tabCategories.SuspendLayout();
            this.tabInventory.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDailySales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashierSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorySales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryValuation)).BeginInit();

            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(1180, 760);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "AnalyticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Analytics";

            // Header
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 88;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(22, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Sales Analytics";

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.lblSubtitle.Location = new System.Drawing.Point(26, 55);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "Review sales performance, products, cashiers and inventory.";

            // Filters
            this.pnlFilters.BackColor = System.Drawing.Color.White;
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Height = 68;
            this.pnlFilters.Controls.Add(this.lblFrom);
            this.pnlFilters.Controls.Add(this.dtpFrom);
            this.pnlFilters.Controls.Add(this.lblTo);
            this.pnlFilters.Controls.Add(this.dtpTo);
            this.pnlFilters.Controls.Add(this.btnRefresh);
            this.pnlFilters.Controls.Add(this.btnExport);
            this.pnlFilters.Controls.Add(this.btnPrint);

            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(20, 25);
            this.lblFrom.Text = "From:";

            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(75, 20);
            this.dtpFrom.Size = new System.Drawing.Size(125, 26);

            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(215, 25);
            this.lblTo.Text = "To:";

            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(250, 20);
            this.dtpTo.Size = new System.Drawing.Size(125, 26);

            this.btnRefresh.Location = new System.Drawing.Point(395, 17);
            this.btnRefresh.Size = new System.Drawing.Size(100, 32);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.btnExport.Location = new System.Drawing.Point(505, 17);
            this.btnExport.Size = new System.Drawing.Size(115, 32);
            this.btnExport.Text = "Export CSV";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            this.btnPrint.Location = new System.Drawing.Point(630, 17);
            this.btnPrint.Size = new System.Drawing.Size(100, 32);
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            // Summary cards
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Height = 125;
            this.pnlSummary.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlSummary.ColumnCount = 5;
            this.pnlSummary.RowCount = 1;
            this.pnlSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this.pnlSummary.Controls.Add(this.pnlOrdersCard, 0, 0);
            this.pnlSummary.Controls.Add(this.pnlGrossCard, 1, 0);
            this.pnlSummary.Controls.Add(this.pnlNetCard, 2, 0);
            this.pnlSummary.Controls.Add(this.pnlTaxCard, 3, 0);
            this.pnlSummary.Controls.Add(this.pnlDiscountCard, 4, 0);

            this.pnlOrdersCard.Name = "pnlOrdersCard";
            this.pnlGrossCard.Name = "pnlGrossCard";
            this.pnlNetCard.Name = "pnlNetCard";
            this.pnlTaxCard.Name = "pnlTaxCard";
            this.pnlDiscountCard.Name = "pnlDiscountCard";

            // Captions and values are initialized here.
            // Orders card
            this.pnlOrdersCard.BackColor = System.Drawing.Color.White;
            this.pnlOrdersCard.Margin = new System.Windows.Forms.Padding(5);
            this.pnlOrdersCard.Padding = new System.Windows.Forms.Padding(10);
            this.pnlOrdersCard.Dock = System.Windows.Forms.DockStyle.Fill;

            this.lblOrdersCaption.AutoSize = true;
            this.lblOrdersCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrdersCaption.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblOrdersCaption.Location = new System.Drawing.Point(10, 10);
            this.lblOrdersCaption.Text = "Completed Orders";

            this.lblTotalOrders.AutoSize = true;
            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrders.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblTotalOrders.Location = new System.Drawing.Point(10, 38);
            this.lblTotalOrders.Text = "0";

            this.pnlOrdersCard.Controls.Add(this.lblOrdersCaption);
            this.pnlOrdersCard.Controls.Add(this.lblTotalOrders);


            // Gross Sales card
            this.pnlGrossCard.BackColor = System.Drawing.Color.White;
            this.pnlGrossCard.Margin = new System.Windows.Forms.Padding(5);
            this.pnlGrossCard.Padding = new System.Windows.Forms.Padding(10);
            this.pnlGrossCard.Dock = System.Windows.Forms.DockStyle.Fill;

            this.lblGrossCaption.AutoSize = true;
            this.lblGrossCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGrossCaption.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblGrossCaption.Location = new System.Drawing.Point(10, 10);
            this.lblGrossCaption.Text = "Gross Sales";

            this.lblTotalGross.AutoSize = true;
            this.lblTotalGross.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTotalGross.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblTotalGross.Location = new System.Drawing.Point(10, 38);
            this.lblTotalGross.Text = "₱0.00";

            this.pnlGrossCard.Controls.Add(this.lblGrossCaption);
            this.pnlGrossCard.Controls.Add(this.lblTotalGross);


            // Net Sales card
            this.pnlNetCard.BackColor = System.Drawing.Color.White;
            this.pnlNetCard.Margin = new System.Windows.Forms.Padding(5);
            this.pnlNetCard.Padding = new System.Windows.Forms.Padding(10);
            this.pnlNetCard.Dock = System.Windows.Forms.DockStyle.Fill;

            this.lblNetCaption.AutoSize = true;
            this.lblNetCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNetCaption.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblNetCaption.Location = new System.Drawing.Point(10, 10);
            this.lblNetCaption.Text = "Net Sales";

            this.lblTotalNet.AutoSize = true;
            this.lblTotalNet.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTotalNet.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblTotalNet.Location = new System.Drawing.Point(10, 38);
            this.lblTotalNet.Text = "₱0.00";

            this.pnlNetCard.Controls.Add(this.lblNetCaption);
            this.pnlNetCard.Controls.Add(this.lblTotalNet);


            // Tax card
            this.pnlTaxCard.BackColor = System.Drawing.Color.White;
            this.pnlTaxCard.Margin = new System.Windows.Forms.Padding(5);
            this.pnlTaxCard.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTaxCard.Dock = System.Windows.Forms.DockStyle.Fill;

            this.lblTaxCaption.AutoSize = true;
            this.lblTaxCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTaxCaption.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblTaxCaption.Location = new System.Drawing.Point(10, 10);
            this.lblTaxCaption.Text = "Tax";

            this.lblTotalTax.AutoSize = true;
            this.lblTotalTax.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTotalTax.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblTotalTax.Location = new System.Drawing.Point(10, 38);
            this.lblTotalTax.Text = "₱0.00";

            this.pnlTaxCard.Controls.Add(this.lblTaxCaption);
            this.pnlTaxCard.Controls.Add(this.lblTotalTax);


            // Discounts card
            this.pnlDiscountCard.BackColor = System.Drawing.Color.White;
            this.pnlDiscountCard.Margin = new System.Windows.Forms.Padding(5);
            this.pnlDiscountCard.Padding = new System.Windows.Forms.Padding(10);
            this.pnlDiscountCard.Dock = System.Windows.Forms.DockStyle.Fill;

            this.lblDiscountCaption.AutoSize = true;
            this.lblDiscountCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiscountCaption.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblDiscountCaption.Location = new System.Drawing.Point(10, 10);
            this.lblDiscountCaption.Text = "Discounts";

            this.lblTotalDiscount.AutoSize = true;
            this.lblTotalDiscount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTotalDiscount.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblTotalDiscount.Location = new System.Drawing.Point(10, 38);
            this.lblTotalDiscount.Text = "₱0.00";

            this.pnlDiscountCard.Controls.Add(this.lblDiscountCaption);
            this.pnlDiscountCard.Controls.Add(this.lblTotalDiscount);

            // Report tabs
            this.tabReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabReports.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabReports.Controls.Add(this.tabDaily);
            this.tabReports.Controls.Add(this.tabTopProducts);
            this.tabReports.Controls.Add(this.tabCashiers);
            this.tabReports.Controls.Add(this.tabCategories);
            this.tabReports.Controls.Add(this.tabInventory);

            // Daily Sales grid
            this.dgvDailySales.Name = "dgvDailySales";
            this.dgvDailySales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDailySales.AllowUserToAddRows = false;
            this.dgvDailySales.AllowUserToDeleteRows = false;
            this.dgvDailySales.ReadOnly = true;
            this.dgvDailySales.RowHeadersVisible = false;
            this.dgvDailySales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDailySales.BackgroundColor = System.Drawing.Color.White;
            this.dgvDailySales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDailySales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDailySales.AutoGenerateColumns = true;
            this.tabDaily.Controls.Add(this.dgvDailySales);

            // Top Products grid
            this.dgvTopProducts.Name = "dgvTopProducts";
            this.dgvTopProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopProducts.AllowUserToAddRows = false;
            this.dgvTopProducts.AllowUserToDeleteRows = false;
            this.dgvTopProducts.ReadOnly = true;
            this.dgvTopProducts.RowHeadersVisible = false;
            this.dgvTopProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTopProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopProducts.AutoGenerateColumns = true;
            this.tabTopProducts.Controls.Add(this.dgvTopProducts);

            // Cashier Sales grid
            this.dgvCashierSales.Name = "dgvCashierSales";
            this.dgvCashierSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCashierSales.AllowUserToAddRows = false;
            this.dgvCashierSales.AllowUserToDeleteRows = false;
            this.dgvCashierSales.ReadOnly = true;
            this.dgvCashierSales.RowHeadersVisible = false;
            this.dgvCashierSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCashierSales.BackgroundColor = System.Drawing.Color.White;
            this.dgvCashierSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCashierSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashierSales.AutoGenerateColumns = true;
            this.tabCashiers.Controls.Add(this.dgvCashierSales);

            // Category Sales grid
            this.dgvCategorySales.Name = "dgvCategorySales";
            this.dgvCategorySales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategorySales.AllowUserToAddRows = false;
            this.dgvCategorySales.AllowUserToDeleteRows = false;
            this.dgvCategorySales.ReadOnly = true;
            this.dgvCategorySales.RowHeadersVisible = false;
            this.dgvCategorySales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategorySales.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategorySales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCategorySales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategorySales.AutoGenerateColumns = true;
            this.tabCategories.Controls.Add(this.dgvCategorySales);

            // Inventory Valuation grid
            this.dgvInventoryValuation.Name = "dgvInventoryValuation";
            this.dgvInventoryValuation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventoryValuation.AllowUserToAddRows = false;
            this.dgvInventoryValuation.AllowUserToDeleteRows = false;
            this.dgvInventoryValuation.ReadOnly = true;
            this.dgvInventoryValuation.RowHeadersVisible = false;
            this.dgvInventoryValuation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventoryValuation.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventoryValuation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventoryValuation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventoryValuation.AutoGenerateColumns = true;
            this.tabInventory.Controls.Add(this.dgvInventoryValuation);

            this.tabDaily.Text = "Daily Sales";
            this.tabTopProducts.Text = "Top Products";
            this.tabCashiers.Text = "Sales by Cashier";
            this.tabCategories.Text = "Sales by Category";
            this.tabInventory.Text = "Inventory Valuation";

            // Footer hint
            this.lblReportHint.AutoSize = false;
            this.lblReportHint.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblReportHint.Height = 34;
            this.lblReportHint.Padding = new System.Windows.Forms.Padding(12, 7, 0, 7);
            this.lblReportHint.Text = "Reports include completed sales only. Inventory valuation shows current stock.";

            // Add docked controls in reverse order so they stack correctly.
            this.Controls.Add(this.tabReports);
            this.Controls.Add(this.lblReportHint);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pnlSummary.ResumeLayout(false);

            this.tabReports.ResumeLayout(false);
            this.tabDaily.ResumeLayout(false);
            this.tabTopProducts.ResumeLayout(false);
            this.tabCashiers.ResumeLayout(false);
            this.tabCategories.ResumeLayout(false);
            this.tabInventory.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)(this.dgvDailySales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashierSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorySales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryValuation)).EndInit();

            this.ResumeLayout(false);
        }


        #endregion
    }
}