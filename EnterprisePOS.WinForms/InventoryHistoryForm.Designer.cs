namespace EnterprisePOS.WinForms
{
    partial class InventoryHistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblRecordCount;

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbTransactionType;

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.DataGridView dgvInventoryHistory;


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
            this.components =
                new System.ComponentModel.Container();

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblRecordCount = new System.Windows.Forms.Label();

            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbTransactionType = new System.Windows.Forms.ComboBox();

            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();

            this.dgvInventoryHistory =
                new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvInventoryHistory)).BeginInit();

            this.SuspendLayout();

            // Form
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1100, 650);

            this.MinimumSize =
                new System.Drawing.Size(850, 500);

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text = "Inventory History";

            this.Font = new System.Drawing.Font(
                "Segoe UI", 9F);

            this.BackColor =
                System.Drawing.Color.FromArgb(245, 247, 250);

            // Title
            this.lblTitle.AutoSize = true;

            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 18F,
                System.Drawing.FontStyle.Bold);

            this.lblTitle.ForeColor =
                System.Drawing.Color.FromArgb(31, 41, 55);

            this.lblTitle.Location =
                new System.Drawing.Point(20, 15);

            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Inventory History";

            // Search label
            this.lblSearch.AutoSize = true;

            this.lblSearch.Location =
                new System.Drawing.Point(22, 78);

            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Text = "Search:";

            // Search textbox
            this.txtSearch.Location =
                new System.Drawing.Point(85, 73);

            this.txtSearch.Name = "txtSearch";

            this.txtSearch.Size =
                new System.Drawing.Size(250, 25);

            this.txtSearch.TabIndex = 0;

            // Transaction label
            this.lblType.AutoSize = true;

            this.lblType.Location =
                new System.Drawing.Point(355, 78);

            this.lblType.Name = "lblType";
            this.lblType.Text = "Transaction:";

            // Transaction dropdown
            this.cmbTransactionType.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbTransactionType.FormattingEnabled = true;

            this.cmbTransactionType.Items.AddRange(
                new object[]
                {
                    "All",
                    "Stock In",
                    "Stock Out"
                });

            this.cmbTransactionType.Location =
                new System.Drawing.Point(440, 73);

            this.cmbTransactionType.Name =
                "cmbTransactionType";

            this.cmbTransactionType.Size =
                new System.Drawing.Size(150, 25);

            this.cmbTransactionType.TabIndex = 1;

            // Search button
            this.btnSearch.Location =
                new System.Drawing.Point(610, 70);

            this.btnSearch.Name = "btnSearch";

            this.btnSearch.Size =
                new System.Drawing.Size(90, 32);

            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";

            this.btnSearch.UseVisualStyleBackColor = true;

            // Refresh button
            this.btnRefresh.Location =
                new System.Drawing.Point(710, 70);

            this.btnRefresh.Name = "btnRefresh";

            this.btnRefresh.Size =
                new System.Drawing.Size(90, 32);

            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";

            this.btnRefresh.UseVisualStyleBackColor = true;

            // Record count
            this.lblRecordCount.AutoSize = true;

            this.lblRecordCount.Location =
                new System.Drawing.Point(20, 112);

            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Text = "Records: 0";

            this.lblRecordCount.ForeColor =
                System.Drawing.Color.FromArgb(75, 85, 99);

            // Inventory history grid
            this.dgvInventoryHistory.AllowUserToAddRows = false;
            this.dgvInventoryHistory.AllowUserToDeleteRows = false;

            this.dgvInventoryHistory.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvInventoryHistory.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvInventoryHistory.BorderStyle =
                System.Windows.Forms.BorderStyle.None;

            this.dgvInventoryHistory.ReadOnly = true;
            this.dgvInventoryHistory.RowHeadersVisible = false;

            this.dgvInventoryHistory.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvInventoryHistory.MultiSelect = false;

            this.dgvInventoryHistory.AutoGenerateColumns = true;

            this.dgvInventoryHistory.Location =
                new System.Drawing.Point(20, 140);

            this.dgvInventoryHistory.Name =
                "dgvInventoryHistory";

            this.dgvInventoryHistory.Size =
                new System.Drawing.Size(1040, 440);

            this.dgvInventoryHistory.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            this.dgvInventoryHistory.TabIndex = 4;

            this.dgvInventoryHistory.ColumnHeadersHeight = 38;

            this.dgvInventoryHistory.EnableHeadersVisualStyles = false;

            this.dgvInventoryHistory.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(31, 41, 55);

            this.dgvInventoryHistory.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;

            this.dgvInventoryHistory.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);

            this.dgvInventoryHistory.DefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9F);

            this.dgvInventoryHistory.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(219, 234, 254);

            this.dgvInventoryHistory.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.FromArgb(31, 41, 55);

            this.dgvInventoryHistory.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(249, 250, 251);

            this.dgvInventoryHistory.RowTemplate.Height = 30;

            // Add controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cmbTransactionType);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.dgvInventoryHistory);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvInventoryHistory)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}