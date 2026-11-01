using EnterprisePOS.Domain.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnterprisePOS.Domain;
using EnterprisePOS.Data.Repositories;


namespace EnterprisePOS.WinForms
{
    public partial class AnalyticsForm : Form
    {
        private readonly PrintDocument printDocument = new PrintDocument();
        private int printRowIndex = 0;
        private string printTitle = "Sales Analytics";

        private readonly UserSession _currentUser;

        private readonly AnalyticsRepository _analyticsRepository =
            new AnalyticsRepository();

        public AnalyticsForm(UserSession user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _currentUser = user;

            InitializeComponent();

            // Configure summary cards.
            SetupCard(
                pnlOrdersCard, lblOrdersCaption, lblTotalOrders,
                "Completed Orders", "0");

            SetupCard(
                pnlGrossCard, lblGrossCaption, lblTotalGross,
                "Gross Sales", "₱0.00");

            SetupCard(
                pnlNetCard, lblNetCaption, lblTotalNet,
                "Net Sales", "₱0.00");

            SetupCard(
                pnlTaxCard, lblTaxCaption, lblTotalTax,
                "Tax", "₱0.00");

            SetupCard(
                pnlDiscountCard, lblDiscountCaption, lblTotalDiscount,
                "Discounts", "₱0.00");

            // Configure report grids.
            SetupGrid(dgvDailySales);
            SetupGrid(dgvTopProducts);
            SetupGrid(dgvCashierSales);
            SetupGrid(dgvCategorySales);
            SetupGrid(dgvInventoryValuation);

            // Default date range: January 1 through today.
            dtpFrom.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpTo.Value = DateTime.Today;

            printDocument.PrintPage += PrintDocument_PrintPage;
            Load += AnalyticsForm_Load;
        }

        private void SetupCard(
            Panel card,
            Label caption,
            Label value,
            string captionText,
            string valueText)
        {
            card.BackColor = Color.White;
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(5);
            card.Padding = new Padding(10);

            // Ensure the caption belongs to this card.
            if (caption.Parent != card)
            {
                if (caption.Parent != null)
                    caption.Parent.Controls.Remove(caption);

                card.Controls.Add(caption);
            }

            // Ensure the value belongs to this card.
            if (value.Parent != card)
            {
                if (value.Parent != null)
                    value.Parent.Controls.Remove(value);

                card.Controls.Add(value);
            }

            caption.AutoSize = true;
            caption.Font = new Font("Segoe UI", 9F);
            caption.ForeColor = Color.FromArgb(107, 114, 128);
            caption.Location = new Point(10, 8);
            caption.Text = captionText;
            caption.Visible = true;

            value.AutoSize = true;
            value.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            value.ForeColor = Color.FromArgb(31, 41, 55);
            value.Location = new Point(10, 35);
            value.Text = valueText;
            value.Visible = true;

            card.Controls.SetChildIndex(caption, 0);
            card.Controls.SetChildIndex(value, 0);
        }

        private void SetupGrid(DataGridView grid)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.Dock = DockStyle.Fill;
            grid.AutoGenerateColumns = true;
        }

        private void AnalyticsForm_Load(object sender, EventArgs e)
        {
            LoadAllReports();
        }

        private void LoadAllReports()
        {
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                MessageBox.Show(
                    "The From date cannot be later than the To date.",
                    "Invalid Date Range",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                LoadDailySales();
                LoadTopProducts();
                LoadCashierSales();
                LoadCategorySales();
                LoadInventoryValuation();
                LoadSummaryCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load analytics reports.\n\n" +
                    ex.Message,
                    "Sales Analytics",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadDailySales()
        {
            dgvDailySales.DataSource =
                _analyticsRepository.GetDailySales(
                    _currentUser.UserId,
                    dtpFrom.Value.Date,
                    dtpTo.Value.Date);

            FormatDateColumn(dgvDailySales, "SaleDay");

            FormatMoneyColumns(
                dgvDailySales,
                "GrossSales",
                "Discounts",
                "Tax",
                "NetSales",
                "TotalCollected");
        }

        private void LoadTopProducts()
        {
            dgvTopProducts.DataSource =
                _analyticsRepository.GetTopProducts(
                    _currentUser.UserId,
                    dtpFrom.Value.Date,
                    dtpTo.Value.Date);

            FormatMoneyColumns(
                dgvTopProducts,
                "SalesAmount");
        }

        private void LoadCashierSales()
        {
            dgvCashierSales.DataSource =
                _analyticsRepository.GetCashierSales(
                    _currentUser.UserId,
                    dtpFrom.Value.Date,
                    dtpTo.Value.Date);

            FormatMoneyColumns(
                dgvCashierSales,
                "GrossSales",
                "Discounts",
                "TotalCollected");
        }

        private void LoadCategorySales()
        {
            dgvCategorySales.DataSource =
                _analyticsRepository.GetCategorySales(
                    _currentUser.UserId,
                    dtpFrom.Value.Date,
                    dtpTo.Value.Date);

            FormatMoneyColumns(
                dgvCategorySales,
                "SalesAmount");
        }

        private void LoadInventoryValuation()
        {
            dgvInventoryValuation.DataSource =
                _analyticsRepository.GetInventoryValuation(
                    _currentUser.UserId);

            FormatMoneyColumns(
                dgvInventoryValuation,
                "UnitCost",
                "UnitSellingPrice",
                "CostValue",
                "RetailValue");
        }

        private void LoadSummaryCards()
        {
            dynamic summary =
                _analyticsRepository.GetAnalyticsSummary(
                    _currentUser.UserId,
                    dtpFrom.Value.Date,
                    dtpTo.Value.Date);

            if (summary == null)
            {
                lblTotalOrders.Text = "0";
                lblTotalGross.Text = "₱0.00";
                lblTotalNet.Text = "₱0.00";
                lblTotalTax.Text = "₱0.00";
                lblTotalDiscount.Text = "₱0.00";
                return;
            }

            lblTotalOrders.Text =
                Convert.ToInt32(summary.OrderCount).ToString("N0");

            lblTotalGross.Text = FormatPeso(summary.GrossSales);
            lblTotalNet.Text = FormatPeso(summary.NetSales);
            lblTotalTax.Text = FormatPeso(summary.Tax);
            lblTotalDiscount.Text = FormatPeso(summary.Discounts);

            lblTotalOrders.Visible = true;
            lblTotalGross.Visible = true;
            lblTotalNet.Visible = true;
            lblTotalTax.Visible = true;
            lblTotalDiscount.Visible = true;
        }

        private string FormatPeso(object value)
        {
            decimal amount = Convert.ToDecimal(value);
            return "₱" + amount.ToString("N2");
        }

        private void FormatMoneyColumns(
            DataGridView grid,
            params string[] columnNames)
        {
            foreach (string name in columnNames)
            {
                if (grid.Columns.Contains(name))
                {
                    grid.Columns[name].DefaultCellStyle.Format = "N2";

                    grid.Columns[name].DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void FormatDateColumn(
            DataGridView grid,
            string columnName)
        {
            if (grid.Columns.Contains(columnName))
            {
                grid.Columns[columnName].DefaultCellStyle.Format =
                    "yyyy-MM-dd";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllReports();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataGridView grid = GetCurrentGrid();

            if (grid == null || grid.Columns.Count == 0)
            {
                MessageBox.Show(
                    "There is no report to export.",
                    "Export CSV",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV files (*.csv)|*.csv";
                dialog.Title = "Export Analytics Report";

                dialog.FileName =
                    GetCurrentReportName() + "_" +
                    DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    ExportGridToCsv(grid, dialog.FileName);

                    MessageBox.Show(
                        "Report exported successfully.",
                        "Export CSV",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Unable to export the report.\n\n" + ex.Message,
                        "Export CSV",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void ExportGridToCsv(
            DataGridView grid,
            string filePath)
        {
            StringBuilder csv = new StringBuilder();

            var visibleColumns = grid.Columns
                .Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .OrderBy(c => c.DisplayIndex)
                .ToList();

            csv.AppendLine(string.Join(",",
                visibleColumns.Select(c => EscapeCsv(c.HeaderText))));

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow)
                    continue;

                csv.AppendLine(string.Join(",",
                    visibleColumns.Select(c =>
                        EscapeCsv(Convert.ToString(
                            row.Cells[c.Index].FormattedValue)))));
            }

            File.WriteAllText(
                filePath,
                csv.ToString(),
                new UTF8Encoding(true));
        }

        private string EscapeCsv(string value)
        {
            if (value == null)
                return "";

            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataGridView grid = GetCurrentGrid();

            if (grid == null || grid.Columns.Count == 0)
            {
                MessageBox.Show(
                    "There is no report to print.",
                    "Print Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            printTitle = GetCurrentReportName();
            printRowIndex = 0;

            using (PrintPreviewDialog preview = new PrintPreviewDialog())
            {
                preview.Document = printDocument;
                preview.Width = 1000;
                preview.Height = 700;
                preview.ShowDialog(this);
            }
        }

        private void PrintDocument_PrintPage(
            object sender,
            PrintPageEventArgs e)
        {
            DataGridView grid = GetCurrentGrid();

            if (grid == null)
            {
                e.HasMorePages = false;
                return;
            }

            Graphics graphics = e.Graphics;
            float left = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;

            using (Font titleFont =
                new Font("Arial", 16, FontStyle.Bold))
            using (Font headerFont =
                new Font("Arial", 8, FontStyle.Bold))
            using (Font bodyFont = new Font("Arial", 8))
            using (Pen pen = new Pen(Color.Gray))
            {
                graphics.DrawString(
                    printTitle,
                    titleFont,
                    Brushes.Black,
                    left,
                    y);

                y += 30;

                graphics.DrawString(
                    "Period: " + dtpFrom.Value.ToShortDateString() +
                    " to " + dtpTo.Value.ToShortDateString(),
                    bodyFont,
                    Brushes.Black,
                    left,
                    y);

                y += 25;

                var columns = grid.Columns
                    .Cast<DataGridViewColumn>()
                    .Where(c => c.Visible)
                    .OrderBy(c => c.DisplayIndex)
                    .ToList();

                if (columns.Count == 0)
                {
                    e.HasMorePages = false;
                    return;
                }

                float columnWidth =
                    e.MarginBounds.Width / (float)columns.Count;

                float rowHeight = 25;

                for (int i = 0; i < columns.Count; i++)
                {
                    RectangleF rect = new RectangleF(
                        left + i * columnWidth,
                        y,
                        columnWidth,
                        rowHeight);

                    graphics.DrawRectangle(
                        pen,
                        rect.X,
                        rect.Y,
                        rect.Width,
                        rect.Height);

                    graphics.DrawString(
                        columns[i].HeaderText,
                        headerFont,
                        Brushes.Black,
                        rect);
                }

                y += rowHeight;

                while (printRowIndex < grid.Rows.Count)
                {
                    DataGridViewRow row = grid.Rows[printRowIndex];

                    if (row.IsNewRow)
                    {
                        printRowIndex++;
                        continue;
                    }

                    if (y + rowHeight > e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                    for (int i = 0; i < columns.Count; i++)
                    {
                        RectangleF rect = new RectangleF(
                            left + i * columnWidth,
                            y,
                            columnWidth,
                            rowHeight);

                        graphics.DrawRectangle(
                            pen,
                            rect.X,
                            rect.Y,
                            rect.Width,
                            rect.Height);

                        string value = Convert.ToString(
                            row.Cells[columns[i].Index].FormattedValue);

                        graphics.DrawString(
                            value ?? "",
                            bodyFont,
                            Brushes.Black,
                            rect);
                    }

                    y += rowHeight;
                    printRowIndex++;
                }

                e.HasMorePages = false;
            }
        }

        private DataGridView GetCurrentGrid()
        {
            if (tabReports.SelectedTab == tabDaily)
                return dgvDailySales;

            if (tabReports.SelectedTab == tabTopProducts)
                return dgvTopProducts;

            if (tabReports.SelectedTab == tabCashiers)
                return dgvCashierSales;

            if (tabReports.SelectedTab == tabCategories)
                return dgvCategorySales;

            if (tabReports.SelectedTab == tabInventory)
                return dgvInventoryValuation;

            return null;
        }

        private string GetCurrentReportName()
        {
            if (tabReports.SelectedTab == tabDaily)
                return "Daily Sales";

            if (tabReports.SelectedTab == tabTopProducts)
                return "Top Products";

            if (tabReports.SelectedTab == tabCashiers)
                return "Sales by Cashier";

            if (tabReports.SelectedTab == tabCategories)
                return "Sales by Category";

            if (tabReports.SelectedTab == tabInventory)
                return "Inventory Valuation";

            return "Sales Analytics";
        }
    }
}