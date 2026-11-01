using EnterprisePOS.Data.Repositories;
using EnterprisePOS.Domain.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnterprisePOS.WinForms
{
    public partial class InventoryForm : Form
    {
        private readonly DatabaseRepository _database;
        private readonly UserSession _user;

        public InventoryForm(UserSession user)
        {
            InitializeComponent();

            _user = user;
            _database = new DatabaseRepository();

            // Connect button and search events.
            txtSearch.TextChanged += txtSearch_TextChanged;
            btnRefresh.Click += btnRefresh_Click;
            btnStockIn.Click += btnStockIn_Click;
            btnStockOut.Click += btnStockOut_Click;
            btnInventoryHistory.Click += btnInventoryHistory_Click;
            dgvInventory.SelectionChanged += dgvInventory_SelectionChanged;

            // Keep both buttons enabled.
            btnStockIn.Enabled = true;
            btnStockOut.Enabled = true;

            // Clear the initial product selection.
            this.Shown += (sender, e) =>
            {
                ClearProductSelection();
                HighlightInventoryRows();
            };

            LoadInventory();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadInventory(txtSearch.Text.Trim());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInventory(txtSearch.Text.Trim());
        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            AdjustStock(true);
        }

        private void btnStockOut_Click(object sender, EventArgs e)
        {
            AdjustStock(false);
        }

        private void btnInventoryHistory_Click(object sender, EventArgs e)
        {
            try
            {
                using (InventoryHistoryForm form = new InventoryHistoryForm())
                {
                    form.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open Inventory History.\n\n" + ex.Message,
                    "Inventory History Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvInventory_SelectionChanged(
            object sender, EventArgs e)
        {
            // Do not disable Stock In or Stock Out.
            btnStockIn.Enabled = true;
            btnStockOut.Enabled = true;
        }

        private void ClearProductSelection()
        {
            dgvInventory.ClearSelection();
            dgvInventory.CurrentCell = null;

            btnStockIn.Enabled = true;
            btnStockOut.Enabled = true;
        }

        private void UpdateStockButtons()
        {
            // Both buttons must remain enabled.
            btnStockIn.Enabled = true;
            btnStockOut.Enabled = true;
        }

        private void LoadInventory(string keyword = "")
        {
            try
            {
                using (var db = _database.CreateContext())
                {
                    var products = db.Products
                        .Where(p =>
                            p.IsActive &&
                            (string.IsNullOrEmpty(keyword) ||
                             p.Sku.Contains(keyword) ||
                             p.Name.Contains(keyword)))
                        .OrderBy(p => p.Name)
                        .Select(p => new
                        {
                            p.ProductId,
                            p.Sku,
                            ProductName = p.Name,
                            p.StockQty,
                            p.ReorderLevel,

                            StockStatus = p.StockQty == 0
                                ? "Out of Stock"
                                : p.StockQty <= p.ReorderLevel
                                    ? "Low Stock"
                                    : "In Stock",

                            Status = p.IsActive
                                ? "Active"
                                : "Inactive"
                        })
                        .ToList();

                    // Bind products to the grid.
                    dgvInventory.DataSource = null;
                    dgvInventory.DataSource = products;

                    // Hide the internal ProductId column.
                    if (dgvInventory.Columns["ProductId"] != null)
                    {
                        dgvInventory.Columns["ProductId"].Visible = false;
                    }

                    // Remove automatic selection after binding.
                    ClearProductSelection();

                    // Apply stock status colors.
                    HighlightInventoryRows();

                    int totalProducts = products.Count;

                    int lowStock = products.Count(p =>
                        p.StockQty > 0 &&
                        p.StockQty <= p.ReorderLevel);

                    int outOfStock = products.Count(p =>
                        p.StockQty == 0);

                    lblSummary.Text =
                        "Products: " + totalProducts +
                        "     Low Stock: " + lowStock +
                        "     Out of Stock: " + outOfStock;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load inventory.\n\n" + ex.Message,
                    "Inventory Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AdjustStock(bool isStockIn)
        {
            // Validate product selection.
            if (dgvInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a product first.",
                    "Product Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow selectedRow = dgvInventory.SelectedRows[0];

            if (selectedRow.IsNewRow ||
                selectedRow.Cells["ProductId"].Value == null)
            {
                MessageBox.Show(
                    "Please select a valid product.",
                    "Product Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string status = Convert.ToString(
                selectedRow.Cells["Status"].Value);

            if (status != "Active")
            {
                MessageBox.Show(
                    "Stock adjustment is not allowed for inactive products. " +
                    "Please reactivate the product in Product Management first.",
                    "Inactive Product",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int productId = Convert.ToInt32(
                selectedRow.Cells["ProductId"].Value);

            string productName = Convert.ToString(
                selectedRow.Cells["ProductName"].Value);

            // Ask for quantity.
            string quantityText;

            if (!ShowInputDialog(
                isStockIn ? "Stock In" : "Stock Out",
                "Enter the quantity to " +
                (isStockIn ? "add to " : "remove from ") +
                productName + ":",
                "1",
                out quantityText))
            {
                return;
            }

            int quantity;

            if (!int.TryParse(quantityText, out quantity) ||
                quantity <= 0)
            {
                MessageBox.Show(
                    "Enter a whole number greater than zero.",
                    "Invalid Quantity",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Ask for adjustment reason.
            string defaultReason = isStockIn
                ? "Stock received"
                : "Damaged or used stock";

            string reason;

            if (!ShowInputDialog(
                "Adjustment Reason",
                "Enter the reason for this stock adjustment:",
                defaultReason,
                out reason))
            {
                return;
            }

            reason = reason.Trim();

            if (string.IsNullOrWhiteSpace(reason))
            {
                MessageBox.Show(
                    "A reason is required.",
                    "Inventory",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (reason.Length > 200)
            {
                MessageBox.Show(
                    "The reason must not exceed 200 characters.",
                    "Invalid Reason",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Positive quantity means stock in.
            // Negative quantity means stock out.
            int changeQty = isStockIn ? quantity : -quantity;

            DialogResult confirm = MessageBox.Show(
                (isStockIn ? "Add " : "Remove ") + quantity +
                " unit(s) " +
                (isStockIn ? "to " : "from ") +
                productName +
                "?\n\nReason: " + reason,
                "Confirm Stock Adjustment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (var db = _database.CreateContext())
                {
                    // Call the stored procedure mapped in the DBML.
                    db.usp_Inventory_Adjust(
                        productId,
                        changeQty,
                        reason,
                        _user.UserId);
                }

                MessageBox.Show(
                    "Stock adjustment completed successfully.",
                    "Inventory Updated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadInventory(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to adjust inventory.\n\n" + ex.Message,
                    "Inventory Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void HighlightInventoryRows()
        {
            foreach (DataGridViewRow row in dgvInventory.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string stockStatus = Convert.ToString(
                    row.Cells["StockStatus"].Value);

                if (stockStatus == "Low Stock")
                {
                    row.DefaultCellStyle.BackColor =
                        Color.FromArgb(255, 220, 220);

                    row.DefaultCellStyle.ForeColor =
                        Color.FromArgb(153, 27, 27);
                }
                else if (stockStatus == "Out of Stock")
                {
                    row.DefaultCellStyle.BackColor =
                        Color.FromArgb(254, 202, 202);

                    row.DefaultCellStyle.ForeColor =
                        Color.FromArgb(127, 29, 29);
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor =
                        Color.FromArgb(35, 45, 60);
                }
            }
        }

        private bool ShowInputDialog(
            string title,
            string prompt,
            string defaultValue,
            out string result)
        {
            result = string.Empty;

            using (Form dialog = new Form())
            using (Label promptLabel = new Label())
            using (TextBox input = new TextBox())
            using (Button okButton = new Button())
            using (Button cancelButton = new Button())
            {
                dialog.Text = title;
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.ClientSize = new Size(390, 145);
                dialog.MinimizeBox = false;
                dialog.MaximizeBox = false;
                dialog.ShowInTaskbar = false;
                dialog.Font = new Font("Segoe UI", 9F);

                promptLabel.Text = prompt;
                promptLabel.Location = new Point(15, 15);
                promptLabel.Size = new Size(360, 38);

                input.Location = new Point(18, 58);
                input.Size = new Size(354, 25);
                input.Text = defaultValue;
                input.MaxLength = 200;

                okButton.Text = "OK";
                okButton.Location = new Point(202, 100);
                okButton.Size = new Size(80, 30);
                okButton.DialogResult = DialogResult.OK;

                cancelButton.Text = "Cancel";
                cancelButton.Location = new Point(292, 100);
                cancelButton.Size = new Size(80, 30);
                cancelButton.DialogResult = DialogResult.Cancel;

                dialog.Controls.Add(promptLabel);
                dialog.Controls.Add(input);
                dialog.Controls.Add(okButton);
                dialog.Controls.Add(cancelButton);

                dialog.AcceptButton = okButton;
                dialog.CancelButton = cancelButton;

                dialog.Shown += (sender, e) =>
                {
                    input.Focus();
                    input.SelectAll();
                };

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    result = input.Text;
                    return true;
                }

                return false;
            }
        }
    }
}