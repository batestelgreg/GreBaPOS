namespace EnterprisePOS.WinForms
{
    partial class InventoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlInventory;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnStockIn;
        private System.Windows.Forms.Button btnStockOut;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblSummary;

        private System.Windows.Forms.Button btnInventoryHistory;

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
            this.pnlInventory = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnStockIn = new System.Windows.Forms.Button();
            this.btnStockOut = new System.Windows.Forms.Button();
            this.btnInventoryHistory = new System.Windows.Forms.Button();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblSummary = new System.Windows.Forms.Label();

            this.pnlInventory.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.pnlSummary.SuspendLayout();
            this.SuspendLayout();

            // pnlInventory
            this.pnlInventory.BackColor = System.Drawing.Color.White;
            this.pnlInventory.Controls.Add(this.dgvInventory);
            this.pnlInventory.Controls.Add(this.pnlSummary);
            this.pnlInventory.Controls.Add(this.btnInventoryHistory);
            this.pnlInventory.Controls.Add(this.btnStockOut);
            this.pnlInventory.Controls.Add(this.btnStockIn);
            this.pnlInventory.Controls.Add(this.btnRefresh);
            this.pnlInventory.Controls.Add(this.txtSearch);
            this.pnlInventory.Controls.Add(this.pnlHeader);
            this.pnlInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInventory.Name = "pnlInventory";
            this.pnlInventory.Padding = new System.Windows.Forms.Padding(20);
            this.pnlInventory.TabIndex = 0;

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(20, 20);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(860, 85);
            this.pnlHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor =
                System.Drawing.Color.FromArgb(35, 45, 60);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Inventory Management";

            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(3, 45);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text =
                "Monitor stock levels and manage stock adjustments";

            // txtSearch
            this.txtSearch.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(20, 120);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(230, 25);
            this.txtSearch.TabIndex = 1;

            // btnRefresh
            this.btnRefresh.BackColor =
                System.Drawing.Color.FromArgb(45, 95, 160);
            this.btnRefresh.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(260, 116);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(85, 32);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;

            // btnStockIn
            this.btnStockIn.BackColor =
                System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnStockIn.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnStockIn.FlatAppearance.BorderSize = 0;
            this.btnStockIn.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnStockIn.ForeColor = System.Drawing.Color.White;
            this.btnStockIn.Location = new System.Drawing.Point(365, 116);
            this.btnStockIn.Name = "btnStockIn";
            this.btnStockIn.Size = new System.Drawing.Size(110, 32);
            this.btnStockIn.TabIndex = 3;
            this.btnStockIn.Text = "Stock In (+)";
            this.btnStockIn.UseVisualStyleBackColor = false;

            // btnStockOut
            this.btnStockOut.BackColor =
                System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnStockOut.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnStockOut.FlatAppearance.BorderSize = 0;
            this.btnStockOut.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnStockOut.ForeColor = System.Drawing.Color.White;
            this.btnStockOut.Location = new System.Drawing.Point(485, 116);
            this.btnStockOut.Name = "btnStockOut";
            this.btnStockOut.Size = new System.Drawing.Size(115, 32);
            this.btnStockOut.TabIndex = 4;
            this.btnStockOut.Text = "Stock Out (-)";
            this.btnStockOut.UseVisualStyleBackColor = false;

            // btnInventoryHistory
            this.btnInventoryHistory.BackColor =
                System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnInventoryHistory.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnInventoryHistory.FlatAppearance.BorderSize = 0;
            this.btnInventoryHistory.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnInventoryHistory.ForeColor =
                System.Drawing.Color.White;
            this.btnInventoryHistory.Location =
                new System.Drawing.Point(610, 116);
            this.btnInventoryHistory.Name = "btnInventoryHistory";
            this.btnInventoryHistory.Size =
                new System.Drawing.Size(145, 32);
            this.btnInventoryHistory.TabIndex = 5;
            this.btnInventoryHistory.Text = "Inventory History";
            this.btnInventoryHistory.UseVisualStyleBackColor = false;

            // dgvInventory
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AllowUserToResizeRows = false;
            this.dgvInventory.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.dgvInventory.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventory.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvInventory.CellBorderStyle =
                System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvInventory.ColumnHeadersHeight = 40;
            this.dgvInventory.EnableHeadersVisualStyles = false;
            this.dgvInventory.Location = new System.Drawing.Point(20, 165);
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.RowTemplate.Height = 32;
            this.dgvInventory.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.Size = new System.Drawing.Size(860, 330);
            this.dgvInventory.TabIndex = 5;

            this.dgvInventory.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(241, 245, 249);
            this.dgvInventory.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.FromArgb(35, 45, 60);
            this.dgvInventory.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvInventory.DefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9F);
            this.dgvInventory.GridColor =
                System.Drawing.Color.FromArgb(232, 237, 244);

            // pnlSummary
            this.pnlSummary.BackColor =
                System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlSummary.Controls.Add(this.lblSummary);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSummary.Location = new System.Drawing.Point(20, 515);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(860, 45);
            this.pnlSummary.TabIndex = 6;

            // lblSummary
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSummary.ForeColor =
                System.Drawing.Color.FromArgb(45, 55, 70);
            this.lblSummary.Location = new System.Drawing.Point(12, 13);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.TabIndex = 0;
            this.lblSummary.Text =
                "Products: 0     Low Stock: 0     Out of Stock: 0";

            // InventoryForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlInventory);
            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InventoryForm";
            this.Text = "Inventory Management";

            this.pnlInventory.ResumeLayout(false);
            this.pnlInventory.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}