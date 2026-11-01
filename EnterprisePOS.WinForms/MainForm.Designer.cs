using System.Windows.Forms;

namespace EnterprisePOS.WinForms

{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlBrand;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.Panel pnlSalesCard;
        private System.Windows.Forms.Panel pnlOrdersCard;
        private System.Windows.Forms.Panel pnlStockCard;
        private System.Windows.Forms.Panel pnlProductsCard;
        private System.Windows.Forms.Panel pnlTransactions;
        private System.Windows.Forms.Panel pnlCashierCard;

        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblBrandSubtitle;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblDashboardSubtitle;
        private System.Windows.Forms.Label lblTodaySales;
        private System.Windows.Forms.Label lblTodayOrders;
        private System.Windows.Forms.Label lblLowStock;
        private System.Windows.Forms.Label lblActiveProducts;
        private System.Windows.Forms.Label lblActiveCashier;
        private System.Windows.Forms.Label lblTransactionsTitle;
        private System.Windows.Forms.Label lblSalesTitle;
        private System.Windows.Forms.Label lblOrdersTitle;
        private System.Windows.Forms.Label lblStockTitle;
        private System.Windows.Forms.Label lblProductsTitle;
        private System.Windows.Forms.Label lblActiveCashierCount;
        private System.Windows.Forms.Label lblCashierTitle;

        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnAdministration;
        private System.Windows.Forms.Button btnLogout;

        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCashier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayment;




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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAdministration = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pnlBrand = new System.Windows.Forms.Panel();
            this.lblBrandSubtitle = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblActiveCashier = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlTransactions = new System.Windows.Forms.Panel();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.colOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCashier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTransactionsTitle = new System.Windows.Forms.Label();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.pnlProductsCard = new System.Windows.Forms.Panel();
            this.lblActiveProducts = new System.Windows.Forms.Label();
            this.lblProductsTitle = new System.Windows.Forms.Label();
            this.pnlStockCard = new System.Windows.Forms.Panel();
            this.lblLowStock = new System.Windows.Forms.Label();
            this.lblStockTitle = new System.Windows.Forms.Label();
            this.pnlOrdersCard = new System.Windows.Forms.Panel();
            this.lblTodayOrders = new System.Windows.Forms.Label();
            this.lblOrdersTitle = new System.Windows.Forms.Label();
            this.pnlSalesCard = new System.Windows.Forms.Panel();
            this.lblTodaySales = new System.Windows.Forms.Label();
            this.lblSalesTitle = new System.Windows.Forms.Label();
            this.lblDashboardSubtitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlCashierCard = new System.Windows.Forms.Panel();
            this.lblActiveCashierCount = new System.Windows.Forms.Label();
            this.lblCashierTitle = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlBrand.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.pnlCards.SuspendLayout();
            this.pnlProductsCard.SuspendLayout();
            this.pnlStockCard.SuspendLayout();
            this.pnlOrdersCard.SuspendLayout();
            this.pnlSalesCard.SuspendLayout();
            this.pnlCashierCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(68)))));
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnAdministration);
            this.pnlSidebar.Controls.Add(this.btnReports);
            this.pnlSidebar.Controls.Add(this.btnSales);
            this.pnlSidebar.Controls.Add(this.btnInventory);
            this.pnlSidebar.Controls.Add(this.btnProducts);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.pnlBrand);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(230, 760);
            this.pnlSidebar.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(68)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnLogout.Location = new System.Drawing.Point(0, 712);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(230, 48);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // btnAdministration
            // 
            this.btnAdministration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdministration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(68)))));
            this.btnAdministration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdministration.FlatAppearance.BorderSize = 0;
            this.btnAdministration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministration.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAdministration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.btnAdministration.Location = new System.Drawing.Point(10, 370);
            this.btnAdministration.Name = "btnAdministration";
            this.btnAdministration.Size = new System.Drawing.Size(210, 44);
            this.btnAdministration.TabIndex = 7;
            this.btnAdministration.Text = "   Administration";
            this.btnAdministration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdministration.UseVisualStyleBackColor = false;
            this.btnAdministration.Click += new System.EventHandler(this.menuUsers_Click);
            // 
            // btnReports
            // 
            this.btnReports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(68)))));
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.btnReports.Location = new System.Drawing.Point(10, 320);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(220, 44);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "   Reports & Analytics";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.menuAnalytics_Click);
            // 
            // btnSales
            // 
            this.btnSales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(68)))));
            this.btnSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSales.FlatAppearance.BorderSize = 0;
            this.btnSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSales.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.btnSales.Location = new System.Drawing.Point(10, 270);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(210, 44);
            this.btnSales.TabIndex = 4;
            this.btnSales.Text = "   New Order / Sales";
            this.btnSales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSales.UseVisualStyleBackColor = false;
            this.btnSales.Click += new System.EventHandler(this.menuNewOrder_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(68)))));
            this.btnInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventory.FlatAppearance.BorderSize = 0;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnInventory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.btnInventory.Location = new System.Drawing.Point(10, 220);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(210, 44);
            this.btnInventory.TabIndex = 3;
            this.btnInventory.Text = "   Inventory";
            this.btnInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.UseVisualStyleBackColor = false;
            this.btnInventory.Click += new System.EventHandler(this.menuProductEditing_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(68)))));
            this.btnProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.btnProducts.Location = new System.Drawing.Point(10, 170);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(210, 44);
            this.btnProducts.TabIndex = 2;
            this.btnProducts.Text = "   Products";
            this.btnProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducts.UseVisualStyleBackColor = false;
            this.btnProducts.Click += new System.EventHandler(this.menuProducts_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.btnDashboard.Location = new System.Drawing.Point(10, 120);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(210, 44);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "   Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pnlBrand
            // 
            this.pnlBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(56)))));
            this.pnlBrand.Controls.Add(this.lblBrandSubtitle);
            this.pnlBrand.Controls.Add(this.lblBrand);
            this.pnlBrand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBrand.Location = new System.Drawing.Point(0, 0);
            this.pnlBrand.Name = "pnlBrand";
            this.pnlBrand.Size = new System.Drawing.Size(230, 105);
            this.pnlBrand.TabIndex = 0;
            // 
            // lblBrandSubtitle
            // 
            this.lblBrandSubtitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBrandSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(184)))), ((int)(((byte)(225)))));
            this.lblBrandSubtitle.Location = new System.Drawing.Point(20, 57);
            this.lblBrandSubtitle.Name = "lblBrandSubtitle";
            this.lblBrandSubtitle.Size = new System.Drawing.Size(190, 22);
            this.lblBrandSubtitle.TabIndex = 1;
            this.lblBrandSubtitle.Text = "POINT OF SALE SYSTEM";
            // 
            // lblBrand
            // 
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(18, 20);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(195, 35);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "ENTERPRISE POS";
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.Controls.Add(this.lblUserInfo);
            this.pnlTopBar.Controls.Add(this.lblPageTitle);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(230, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1020, 70);
            this.pnlTopBar.TabIndex = 1;
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(110)))));
            this.lblUserInfo.Location = new System.Drawing.Point(470, 8);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Padding = new System.Windows.Forms.Padding(0, 0, 28, 0);
            this.lblUserInfo.Size = new System.Drawing.Size(550, 30);
            this.lblUserInfo.TabIndex = 1;
            this.lblUserInfo.Text = "Signed in";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(48)))), ((int)(((byte)(82)))));
            this.lblPageTitle.Location = new System.Drawing.Point(28, 12);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(400, 45);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Dashboard";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblActiveCashier
            // 
            this.lblActiveCashier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActiveCashier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblActiveCashier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(110)))));
            this.lblActiveCashier.Location = new System.Drawing.Point(470, 38);
            this.lblActiveCashier.Name = "lblActiveCashier";
            this.lblActiveCashier.Padding = new System.Windows.Forms.Padding(0, 0, 28, 0);
            this.lblActiveCashier.Size = new System.Drawing.Size(550, 24);
            this.lblActiveCashier.TabIndex = 2;
            this.lblActiveCashier.Text = "Active Cashier";
            this.lblActiveCashier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblActiveCashier.Visible = false;
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Controls.Add(this.pnlTransactions);
            this.pnlContent.Controls.Add(this.pnlCards);
            this.pnlContent.Controls.Add(this.lblDashboardSubtitle);
            this.pnlContent.Controls.Add(this.lblWelcome);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(230, 70);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(28, 20, 28, 24);
            this.pnlContent.Size = new System.Drawing.Size(1020, 690);
            this.pnlContent.TabIndex = 0;
            // 
            // pnlTransactions
            // 
            this.pnlTransactions.BackColor = System.Drawing.Color.White;
            this.pnlTransactions.Controls.Add(this.dgvTransactions);
            this.pnlTransactions.Controls.Add(this.lblTransactionsTitle);
            this.pnlTransactions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTransactions.Location = new System.Drawing.Point(28, 300);
            this.pnlTransactions.Name = "pnlTransactions";
            this.pnlTransactions.Padding = new System.Windows.Forms.Padding(18);
            this.pnlTransactions.Size = new System.Drawing.Size(964, 320);
            this.pnlTransactions.TabIndex = 3;
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTransactions.ColumnHeadersHeight = 38;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderNo,
            this.colDate,
            this.colCashier,
            this.colTotal,
            this.colPayment});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(48)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransactions.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransactions.EnableHeadersVisualStyles = false;
            this.dgvTransactions.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(244)))));
            this.dgvTransactions.Location = new System.Drawing.Point(18, 63);
            this.dgvTransactions.MultiSelect = false;
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.RowHeadersWidth = 62;
            this.dgvTransactions.RowTemplate.Height = 35;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.Size = new System.Drawing.Size(928, 239);
            this.dgvTransactions.TabIndex = 1;
            // 
            // colOrderNo
            // 
            this.colOrderNo.HeaderText = "Order No.";
            this.colOrderNo.MinimumWidth = 8;
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.MinimumWidth = 8;
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colCashier
            // 
            this.colCashier.HeaderText = "Cashier";
            this.colCashier.MinimumWidth = 8;
            this.colCashier.Name = "colCashier";
            this.colCashier.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.MinimumWidth = 8;
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // colPayment
            // 
            this.colPayment.HeaderText = "Payment";
            this.colPayment.MinimumWidth = 8;
            this.colPayment.Name = "colPayment";
            this.colPayment.ReadOnly = true;
            // 
            // lblTransactionsTitle
            // 
            this.lblTransactionsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTransactionsTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTransactionsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(48)))), ((int)(((byte)(82)))));
            this.lblTransactionsTitle.Location = new System.Drawing.Point(18, 18);
            this.lblTransactionsTitle.Name = "lblTransactionsTitle";
            this.lblTransactionsTitle.Size = new System.Drawing.Size(928, 45);
            this.lblTransactionsTitle.TabIndex = 0;
            this.lblTransactionsTitle.Text = "Recent Transactions";
            this.lblTransactionsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCards
            // 
            this.pnlCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlCards.Controls.Add(this.pnlProductsCard);
            this.pnlCards.Controls.Add(this.pnlStockCard);
            this.pnlCards.Controls.Add(this.pnlOrdersCard);
            this.pnlCards.Controls.Add(this.pnlSalesCard);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(28, 115);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Padding = new System.Windows.Forms.Padding(0, 16, 0, 12);
            this.pnlCards.Size = new System.Drawing.Size(964, 185);
            this.pnlCards.TabIndex = 2;
            // 
            // pnlProductsCard
            // 
            this.pnlProductsCard.BackColor = System.Drawing.Color.White;
            this.pnlProductsCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProductsCard.Controls.Add(this.lblActiveProducts);
            this.pnlProductsCard.Controls.Add(this.lblProductsTitle);
            this.pnlProductsCard.Location = new System.Drawing.Point(576, 16);
            this.pnlProductsCard.Name = "pnlProductsCard";
            this.pnlProductsCard.Size = new System.Drawing.Size(175, 145);
            this.pnlProductsCard.TabIndex = 3;
            // 
            // lblActiveProducts
            // 
            this.lblActiveProducts.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblActiveProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(58)))), ((int)(((byte)(237)))));
            this.lblActiveProducts.Location = new System.Drawing.Point(10, 55);
            this.lblActiveProducts.Name = "lblActiveProducts";
            this.lblActiveProducts.Size = new System.Drawing.Size(153, 55);
            this.lblActiveProducts.TabIndex = 1;
            this.lblActiveProducts.Text = "0";
            this.lblActiveProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProductsTitle
            // 
            this.lblProductsTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProductsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(122)))), ((int)(((byte)(142)))));
            this.lblProductsTitle.Location = new System.Drawing.Point(10, 18);
            this.lblProductsTitle.Name = "lblProductsTitle";
            this.lblProductsTitle.Size = new System.Drawing.Size(153, 28);
            this.lblProductsTitle.TabIndex = 0;
            this.lblProductsTitle.Text = "ACTIVE PRODUCTS";
            this.lblProductsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlStockCard
            // 
            this.pnlStockCard.BackColor = System.Drawing.Color.White;
            this.pnlStockCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStockCard.Controls.Add(this.lblLowStock);
            this.pnlStockCard.Controls.Add(this.lblStockTitle);
            this.pnlStockCard.Location = new System.Drawing.Point(384, 16);
            this.pnlStockCard.Name = "pnlStockCard";
            this.pnlStockCard.Size = new System.Drawing.Size(175, 145);
            this.pnlStockCard.TabIndex = 2;
            // 
            // lblLowStock
            // 
            this.lblLowStock.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblLowStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblLowStock.Location = new System.Drawing.Point(10, 55);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(153, 55);
            this.lblLowStock.TabIndex = 1;
            this.lblLowStock.Text = "0";
            this.lblLowStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStockTitle
            // 
            this.lblStockTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStockTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(122)))), ((int)(((byte)(142)))));
            this.lblStockTitle.Location = new System.Drawing.Point(10, 18);
            this.lblStockTitle.Name = "lblStockTitle";
            this.lblStockTitle.Size = new System.Drawing.Size(153, 28);
            this.lblStockTitle.TabIndex = 0;
            this.lblStockTitle.Text = "LOW STOCK ITEMS";
            this.lblStockTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlOrdersCard
            // 
            this.pnlOrdersCard.BackColor = System.Drawing.Color.White;
            this.pnlOrdersCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOrdersCard.Controls.Add(this.lblTodayOrders);
            this.pnlOrdersCard.Controls.Add(this.lblOrdersTitle);
            this.pnlOrdersCard.Location = new System.Drawing.Point(192, 16);
            this.pnlOrdersCard.Name = "pnlOrdersCard";
            this.pnlOrdersCard.Size = new System.Drawing.Size(175, 145);
            this.pnlOrdersCard.TabIndex = 1;
            // 
            // lblTodayOrders
            // 
            this.lblTodayOrders.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTodayOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.lblTodayOrders.Location = new System.Drawing.Point(10, 55);
            this.lblTodayOrders.Name = "lblTodayOrders";
            this.lblTodayOrders.Size = new System.Drawing.Size(153, 55);
            this.lblTodayOrders.TabIndex = 1;
            this.lblTodayOrders.Text = "0";
            this.lblTodayOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrdersTitle
            // 
            this.lblOrdersTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOrdersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(122)))), ((int)(((byte)(142)))));
            this.lblOrdersTitle.Location = new System.Drawing.Point(10, 18);
            this.lblOrdersTitle.Name = "lblOrdersTitle";
            this.lblOrdersTitle.Size = new System.Drawing.Size(153, 28);
            this.lblOrdersTitle.TabIndex = 0;
            this.lblOrdersTitle.Text = "ORDERS TODAY";
            this.lblOrdersTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSalesCard
            // 
            this.pnlSalesCard.BackColor = System.Drawing.Color.White;
            this.pnlSalesCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSalesCard.Controls.Add(this.lblTodaySales);
            this.pnlSalesCard.Controls.Add(this.lblSalesTitle);
            this.pnlSalesCard.Location = new System.Drawing.Point(0, 16);
            this.pnlSalesCard.Name = "pnlSalesCard";
            this.pnlSalesCard.Size = new System.Drawing.Size(175, 145);
            this.pnlSalesCard.TabIndex = 0;
            // 
            // lblTodaySales
            // 
            this.lblTodaySales.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTodaySales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblTodaySales.Location = new System.Drawing.Point(10, 55);
            this.lblTodaySales.Name = "lblTodaySales";
            this.lblTodaySales.Size = new System.Drawing.Size(153, 55);
            this.lblTodaySales.TabIndex = 1;
            this.lblTodaySales.Text = "₱0.00";
            this.lblTodaySales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSalesTitle
            // 
            this.lblSalesTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSalesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(122)))), ((int)(((byte)(142)))));
            this.lblSalesTitle.Location = new System.Drawing.Point(10, 18);
            this.lblSalesTitle.Name = "lblSalesTitle";
            this.lblSalesTitle.Size = new System.Drawing.Size(153, 28);
            this.lblSalesTitle.TabIndex = 0;
            this.lblSalesTitle.Text = "TODAY\'S SALES";
            this.lblSalesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDashboardSubtitle
            // 
            this.lblDashboardSubtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDashboardSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDashboardSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(128)))), ((int)(((byte)(148)))));
            this.lblDashboardSubtitle.Location = new System.Drawing.Point(28, 65);
            this.lblDashboardSubtitle.Name = "lblDashboardSubtitle";
            this.lblDashboardSubtitle.Size = new System.Drawing.Size(964, 50);
            this.lblDashboardSubtitle.TabIndex = 1;
            this.lblDashboardSubtitle.Text = "Here is an overview of your store today.";
            this.lblDashboardSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(48)))), ((int)(((byte)(82)))));
            this.lblWelcome.Location = new System.Drawing.Point(28, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(964, 45);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome back!";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCashierCard
            // 
            this.pnlCashierCard.BackColor = System.Drawing.Color.White;
            this.pnlCashierCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCashierCard.Controls.Add(this.lblActiveCashierCount);
            this.pnlCashierCard.Location = new System.Drawing.Point(768, 16);
            this.pnlCashierCard.Name = "pnlCashierCard";
            this.pnlCashierCard.Size = new System.Drawing.Size(175, 145);
            this.pnlCashierCard.TabIndex = 4;
            // 
            // lblActiveCashierCount
            // 
            this.lblActiveCashierCount.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblActiveCashierCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(145)))), ((int)(((byte)(178)))));
            this.lblActiveCashierCount.Location = new System.Drawing.Point(10, 55);
            this.lblActiveCashierCount.Name = "lblActiveCashierCount";
            this.lblActiveCashierCount.Size = new System.Drawing.Size(153, 55);
            this.lblActiveCashierCount.TabIndex = 1;
            this.lblActiveCashierCount.Text = "1";
            this.lblActiveCashierCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCashierTitle
            // 
            this.lblCashierTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCashierTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(122)))), ((int)(((byte)(142)))));
            this.lblCashierTitle.Location = new System.Drawing.Point(10, 18);
            this.lblCashierTitle.Name = "lblCashierTitle";
            this.lblCashierTitle.Size = new System.Drawing.Size(153, 28);
            this.lblCashierTitle.TabIndex = 0;
            this.lblCashierTitle.Text = "ACTIVE CASHIERS";
            this.lblCashierTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1250, 760);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1050, 650);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enterprise POS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSidebar.ResumeLayout(false);
            this.pnlBrand.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlTransactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlProductsCard.ResumeLayout(false);
            this.pnlStockCard.ResumeLayout(false);
            this.pnlOrdersCard.ResumeLayout(false);
            this.pnlSalesCard.ResumeLayout(false);
            this.pnlCashierCard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
