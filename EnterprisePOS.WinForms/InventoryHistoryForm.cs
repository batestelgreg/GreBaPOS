using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnterprisePOS.Data;
using EnterprisePOS.Data.Repositories;

namespace EnterprisePOS.WinForms
{
    public partial class InventoryHistoryForm : Form
    {
        private readonly DatabaseRepository _repository =
            new DatabaseRepository();

        public InventoryHistoryForm()
        {
            InitializeComponent();

            // Set the default transaction filter.
            cmbTransactionType.SelectedIndex = 0;

            // Search button.
            btnSearch.Click += (sender, e) =>
            {
                LoadInventoryHistory();
            };

            // Refresh button.
            btnRefresh.Click += (sender, e) =>
            {
                txtSearch.Clear();
                cmbTransactionType.SelectedIndex = 0;
                LoadInventoryHistory();
            };

            // Press Enter in the search box to search.
            txtSearch.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    LoadInventoryHistory();
                }
            };

            // Load inventory history when the form opens.
            LoadInventoryHistory();
        }

        private void LoadInventoryHistory()
        {
            try
            {
                using (EnterprisePOSDataDataContext db =
                    _repository.CreateContext())
                {
                    string search = txtSearch.Text.Trim();

                    string transactionType =
                        cmbTransactionType.SelectedItem == null
                            ? "All"
                            : cmbTransactionType.SelectedItem.ToString();

                    var query =
                        from log in db.InventoryLogs
                        join product in db.Products
                            on log.ProductId equals product.ProductId
                        join user in db.Users
                            on log.UserId equals user.UserId into userGroup
                        from user in userGroup.DefaultIfEmpty()
                        select new
                        {
                            log.LogId,
                            ProductName = product.Name,
                            log.ChangeQty,
                            log.Reason,
                            Username = user == null
                                ? "Unknown"
                                : user.Username,
                            log.CreatedAt
                        };

                    // Search by product, reason, or username.
                    if (!string.IsNullOrWhiteSpace(search))
                    {
                        query = query.Where(x =>
                            x.ProductName.Contains(search) ||
                            (x.Reason != null &&
                             x.Reason.Contains(search)) ||
                            x.Username.Contains(search));
                    }

                    // Filter transaction type.
                    if (transactionType == "Stock In")
                    {
                        query = query.Where(x => x.ChangeQty > 0);
                    }
                    else if (transactionType == "Stock Out")
                    {
                        query = query.Where(x => x.ChangeQty < 0);
                    }

                    // Get the newest transactions first.
                    var history = query
                        .OrderByDescending(x => x.CreatedAt)
                        .ToList()
                        .Select(x => new
                        {
                            x.LogId,
                            x.ProductName,
                            x.ChangeQty,

                            TransactionType = x.ChangeQty > 0
                                ? "Stock In"
                                : x.ChangeQty < 0
                                    ? "Stock Out"
                                    : "No Change",

                            x.Reason,
                            x.Username,
                            x.CreatedAt
                        })
                        .ToList();

                    dgvInventoryHistory.DataSource = null;
                    dgvInventoryHistory.DataSource = history;

                    // Set readable column headings.
                    if (dgvInventoryHistory.Columns["LogId"] != null)
                    {
                        dgvInventoryHistory.Columns["LogId"].HeaderText =
                            "Log ID";
                    }

                    if (dgvInventoryHistory.Columns["ProductName"] != null)
                    {
                        dgvInventoryHistory.Columns["ProductName"].HeaderText =
                            "Product";
                    }

                    if (dgvInventoryHistory.Columns["ChangeQty"] != null)
                    {
                        dgvInventoryHistory.Columns["ChangeQty"].HeaderText =
                            "Quantity Change";
                    }

                    if (dgvInventoryHistory.Columns["TransactionType"] != null)
                    {
                        dgvInventoryHistory.Columns["TransactionType"].HeaderText =
                            "Transaction Type";
                    }

                    if (dgvInventoryHistory.Columns["Reason"] != null)
                    {
                        dgvInventoryHistory.Columns["Reason"].HeaderText =
                            "Reason";
                    }

                    if (dgvInventoryHistory.Columns["Username"] != null)
                    {
                        dgvInventoryHistory.Columns["Username"].HeaderText =
                            "Username";
                    }

                    if (dgvInventoryHistory.Columns["CreatedAt"] != null)
                    {
                        dgvInventoryHistory.Columns["CreatedAt"].HeaderText =
                            "Date & Time";

                        dgvInventoryHistory.Columns["CreatedAt"]
                            .DefaultCellStyle.Format =
                            "MMM dd, yyyy hh:mm tt";
                    }

                    // Keep columns readable.
                    if (dgvInventoryHistory.Columns["LogId"] != null)
                    {
                        dgvInventoryHistory.Columns["LogId"].FillWeight = 45;
                    }

                    if (dgvInventoryHistory.Columns["ProductName"] != null)
                    {
                        dgvInventoryHistory.Columns["ProductName"].FillWeight = 120;
                    }

                    if (dgvInventoryHistory.Columns["Reason"] != null)
                    {
                        dgvInventoryHistory.Columns["Reason"].FillWeight = 130;
                    }

                    if (dgvInventoryHistory.Columns["CreatedAt"] != null)
                    {
                        dgvInventoryHistory.Columns["CreatedAt"].FillWeight = 115;
                    }

                    // Show the number of displayed records.
                    lblRecordCount.Text =
                        "Records: " + history.Count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load inventory history.\n\n" + ex.Message,
                    "Inventory History Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}