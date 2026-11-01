using EnterprisePOS.Data;
using EnterprisePOS.Data.Repositories;
using EnterprisePOS.Domain;
using EnterprisePOS.Domain.Class;
using EnterprisePOS.Services.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnterprisePOS.Services;

namespace EnterprisePOS.WinForms
{
    public partial class MainForm : Form
    {
        private readonly UserSession _currentUser;

        private bool _canViewReports;
        private bool _canVoidOrders;

        private Panel _pageHost;

        // Cached module forms
        private ProductForm _productForm;
        private InventoryForm _inventoryForm;
        private SalesForm _salesForm;
        private AnalyticsForm _analyticsForm;
        private UserAdminForm _userAdminForm;

        // Current navigation state
        private Form _currentPage;
        private string _currentPageName = "Dashboard";

        private bool _isNavigating;

        // Dashboard automatic refresh timer
        private System.Windows.Forms.Timer _dashboardRefreshTimer;

        // Dashboard controls
        private Panel _pnlLowStock;
        private DataGridView _dgvLowStock;
        private Label _lblLowStockTitle;
        private Label _lblTerminalInfo;

        private Button _activeNavButton;
        private Button _btnVoid;

        private readonly Color _navNormalColor =
            Color.FromArgb(31, 41, 55);

        private readonly Color _navActiveColor =
            Color.FromArgb(59, 130, 246);

        public MainForm(UserSession user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _currentUser = user;

            InitializeComponent();

            CheckReportPermission();
            CheckVoidPermission();

            InitializePageHost();
            InitializeDashboardTables();
            InitializeVoidButton();

            ConfigureDashboard();

            if (_canViewReports)
            {
                LoadRecentTransactions();
                LoadLowStockTable();
            }
            else
            {
                ClearRestrictedDashboardData();
            }

            SetActiveNavButton(btnDashboard);

            // Start automatic dashboard refresh.
            InitializeDashboardRefreshTimer();
        }

        #region Permissions

        private void CheckReportPermission()
        {
            try
            {
                var service = new UserAdministrationService();

                _canViewReports = service.HasPermission(
                    _currentUser.UserId,
                    "Reports.View");
            }
            catch
            {
                _canViewReports = false;
            }
        }

        private void CheckVoidPermission()
        {
            try
            {
                var service = new UserAdministrationService();

                _canVoidOrders = service.HasPermission(
                    _currentUser.UserId,
                    "Orders.Void");
            }
            catch
            {
                _canVoidOrders = false;
            }
        }

        #endregion

        #region Initialization

        private void InitializePageHost()
        {
            _pageHost = new Panel
            {
                Name = "pnlPageHost",
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(244, 247, 252),
                Visible = false
            };

            pnlContent.Controls.Add(_pageHost);
            _pageHost.BringToFront();
        }

        private void InitializeDashboardRefreshTimer()
        {
            _dashboardRefreshTimer =
                new System.Windows.Forms.Timer();

            // Refresh every 10 seconds.
            _dashboardRefreshTimer.Interval = 10000;

            _dashboardRefreshTimer.Tick +=
                DashboardRefreshTimer_Tick;

            _dashboardRefreshTimer.Start();
        }

        private void InitializeDashboardTables()
        {
            lblTransactionsTitle.Text = "Recent Transactions";

            dgvTransactions.ReadOnly = true;
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dgvTransactions.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.MultiSelect = false;
            dgvTransactions.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.RowHeadersVisible = false;

            _pnlLowStock = new Panel
            {
                Name = "pnlLowStockProducts",
                BackColor = Color.White,
                Height = 260,
                Dock = DockStyle.Bottom,
                Padding = new Padding(18)
            };

            _lblLowStockTitle = new Label
            {
                Name = "lblLowStockProductsTitle",
                Text = "Low Stock Products",
                Dock = DockStyle.Top,
                Height = 40,
                Font = new Font(
                    "Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 48, 82),
                TextAlign = ContentAlignment.MiddleLeft
            };

            _dgvLowStock = new DataGridView
            {
                Name = "dgvLowStockProducts",
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoGenerateColumns = true,
                AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeight = 38,
                RowTemplate = { Height = 32 },
                GridColor = Color.FromArgb(232, 237, 244)
            };

            _dgvLowStock.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(241, 245, 249);

            _dgvLowStock.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            _dgvLowStock.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);

            _pnlLowStock.Controls.Add(_dgvLowStock);
            _pnlLowStock.Controls.Add(_lblLowStockTitle);

            pnlContent.Controls.Add(_pnlLowStock);
            _pnlLowStock.BringToFront();

            _lblTerminalInfo = new Label
            {
                Name = "lblTerminalInfo",
                AutoSize = false,
                Width = 200,
                Height = 20,
                Location = new Point(20, 78),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(160, 184, 225),
                Text = "Terminal: " + Environment.MachineName
            };

            pnlBrand.Controls.Add(_lblTerminalInfo);
        }

        private void InitializeVoidButton()
        {
            _btnVoid = new Button
            {
                Name = "btnVoid",
                Text = "Void Selected Order",
                Width = 165,
                Height = 32,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font(
                    "Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Visible = _canVoidOrders
            };

            _btnVoid.FlatAppearance.BorderSize = 0;
            _btnVoid.Click += btnVoid_Click;

            pnlTransactions.Controls.Add(_btnVoid);

            _btnVoid.Location = new Point(
                pnlTransactions.ClientSize.Width -
                _btnVoid.Width - 18,
                24);

            _btnVoid.BringToFront();

            lblTransactionsTitle.Width =
                pnlTransactions.ClientSize.Width - 220;

            pnlTransactions.Resize += (sender, e) =>
            {
                if (_btnVoid != null)
                {
                    _btnVoid.Location = new Point(
                        pnlTransactions.ClientSize.Width -
                        _btnVoid.Width - 18,
                        24);

                    lblTransactionsTitle.Width =
                        pnlTransactions.ClientSize.Width - 220;
                }
            };
        }

        #endregion

        #region Dashboard Automatic Refresh

        private void DashboardRefreshTimer_Tick(
            object sender, EventArgs e)
        {
            if (IsDisposed ||
                !IsHandleCreated ||
                !Visible ||
                _isNavigating ||
                _currentPage != null ||
                _currentPageName != "Dashboard")
            {
                return;
            }

            RefreshDashboardData(false);
        }

        private void RefreshDashboardData(bool showErrors)
        {
            if (IsDisposed || !IsHandleCreated)
                return;

            ConfigureDashboard(showErrors);

            if (_canViewReports)
            {
                LoadRecentTransactions(showErrors);
                LoadLowStockTable(showErrors);
            }
            else
            {
                ClearRestrictedDashboardData();
            }
        }

        #endregion

        #region Navigation

        private void NavigateToPage(
            Form page,
            string pageName,
            Button navButton)
        {
            if (page == null ||
                page.IsDisposed ||
                _isNavigating)
            {
                return;
            }

            if (_currentPage == page &&
                _currentPageName == pageName &&
                page.Visible)
            {
                SetActiveNavButton(navButton);
                return;
            }

            try
            {
                _isNavigating = true;

                SetActiveNavButton(navButton);

                if (_currentPage != null &&
                    _currentPage != page)
                {
                    _currentPage.Hide();
                }

                if (!_pageHost.Controls.Contains(page))
                {
                    _pageHost.Controls.Add(page);
                }

                _pageHost.Visible = true;
                _pageHost.BringToFront();

                page.Show();
                page.BringToFront();

                _currentPage = page;
                _currentPageName = pageName;

                lblPageTitle.Text = pageName;
            }
            finally
            {
                _isNavigating = false;
            }
        }

        private void ShowProductPage()
        {
            if (_productForm == null ||
                _productForm.IsDisposed)
            {
                _productForm = new ProductForm(_currentUser)
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };

                _productForm.RequestClose +=
                    ProductForm_RequestClose;
            }

            HideDashboardContent();

            NavigateToPage(
                _productForm,
                "Product Management",
                btnProducts);
        }

        private void ShowInventoryPage()
        {
            if (_inventoryForm == null ||
                _inventoryForm.IsDisposed)
            {
                _inventoryForm = new InventoryForm(_currentUser)
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
            }

            HideDashboardContent();

            NavigateToPage(
                _inventoryForm,
                "Inventory Management",
                btnInventory);
        }

        private void ShowSalesPage()
        {
            if (_salesForm == null ||
                _salesForm.IsDisposed)
            {
                _salesForm = new SalesForm(_currentUser)
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
            }

            HideDashboardContent();

            NavigateToPage(
                _salesForm,
                "Sales Management",
                btnSales);
        }

        private void ShowAnalyticsPage()
        {
            if (!_canViewReports)
            {
                MessageBox.Show(
                    "You are not authorized to access Reports & Analytics.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (_analyticsForm == null ||
                _analyticsForm.IsDisposed)
            {
                _analyticsForm = new AnalyticsForm(_currentUser)
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
            }

            HideDashboardContent();

            NavigateToPage(
                _analyticsForm,
                "Sales Reports and Analytics",
                btnReports);
        }

        private void ShowUserAdminPage()
        {
            if (_userAdminForm == null ||
                _userAdminForm.IsDisposed)
            {
                _userAdminForm = new UserAdminForm(_currentUser)
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
            }

            HideDashboardContent();

            NavigateToPage(
                _userAdminForm,
                "User Administration",
                btnAdministration);
        }

        private void ShowDashboardPage()
        {
            if (_isNavigating)
                return;

            try
            {
                _isNavigating = true;

                if (_currentPage != null)
                {
                    _currentPage.Hide();
                    _currentPage = null;
                }

                _currentPageName = "Dashboard";

                _pageHost.Visible = false;

                ShowDashboardContent();

                lblPageTitle.Text = "Dashboard";

                lblWelcome.Text =
                    "Welcome back, " + _currentUser.FullName + "!";

                SetActiveNavButton(btnDashboard);
            }
            finally
            {
                _isNavigating = false;
            }

            // Always refresh when returning to Dashboard.
            RefreshDashboardData(true);
        }

        private void HideDashboardContent()
        {
            lblWelcome.Visible = false;
            lblDashboardSubtitle.Visible = false;
            pnlCards.Visible = false;
            pnlTransactions.Visible = false;

            if (_pnlLowStock != null)
                _pnlLowStock.Visible = false;
        }

        private void ShowDashboardContent()
        {
            lblWelcome.Visible = true;
            lblDashboardSubtitle.Visible = true;
            pnlCards.Visible = true;
            pnlTransactions.Visible = true;

            if (_pnlLowStock != null)
                _pnlLowStock.Visible = true;
        }

        private void SetActiveNavButton(Button clickedButton)
        {
            Button[] navButtons =
            {
                btnDashboard,
                btnProducts,
                btnInventory,
                btnSales,
                btnReports,
                btnAdministration
            };

            foreach (Button button in navButtons)
            {
                if (button == null)
                    continue;

                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.BackColor = _navNormalColor;
                button.ForeColor = Color.White;
            }

            if (clickedButton == null)
                return;

            _activeNavButton = clickedButton;

            _activeNavButton.FlatStyle = FlatStyle.Flat;
            _activeNavButton.FlatAppearance.BorderSize = 0;
            _activeNavButton.BackColor = _navActiveColor;
            _activeNavButton.ForeColor = Color.White;
        }

        #endregion

        #region Navigation Button Events

        private void btnDashboard_Click(
            object sender, EventArgs e)
        {
            ShowDashboardPage();
        }

        private void menuProducts_Click(
            object sender, EventArgs e)
        {
            ShowProductPage();
        }

        private void menuProductEditing_Click(
            object sender, EventArgs e)
        {
            ShowInventoryPage();
        }

        private void menuNewOrder_Click(
            object sender, EventArgs e)
        {
            ShowSalesPage();
        }

        private void menuAnalytics_Click(
            object sender, EventArgs e)
        {
            ShowAnalyticsPage();
        }

        private void menuUsers_Click(
            object sender, EventArgs e)
        {
            try
            {
                var service = new UserAdministrationService();

                if (!service.HasPermission(
                    _currentUser.UserId,
                    "Users.Manage"))
                {
                    MessageBox.Show(
                        "You are not authorized to manage users.",
                        "Access Denied",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                ShowUserAdminPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open User Administration.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void menuLogout_Click(
            object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Close();
        }

        #endregion

        #region Dashboard

        private void ConfigureDashboard(bool showErrors = true)
        {
            lblUserInfo.Text =
                _currentUser.FullName + " | " +
                _currentUser.RoleName + " | " +
                Environment.MachineName;

            lblActiveCashier.Text =
                "Active Cashier: " + _currentUser.FullName;

            lblWelcome.Text =
                "Welcome back, " + _currentUser.FullName + "!";

            btnAdministration.Visible =
                string.Equals(
                    _currentUser.RoleName,
                    "Admin",
                    StringComparison.OrdinalIgnoreCase);

            btnReports.Visible = _canViewReports;

            if (_btnVoid != null)
                _btnVoid.Visible = _canVoidOrders;

            Text = "Enterprise POS - Dashboard";

            if (!_canViewReports)
            {
                SetDashboardValuesToZero();
                return;
            }

            try
            {
                DashboardRepository repository =
                    new DashboardRepository();

                var summary = repository.GetDashboardSummary(
                    _currentUser.UserId);

                if (summary == null)
                {
                    SetDashboardValuesToZero();
                    return;
                }

                lblTodaySales.Text =
                    (summary.TodaySales ?? 0m).ToString(
                        "C2",
                        CultureInfo.GetCultureInfo("en-PH"));

                lblTodayOrders.Text =
                    (summary.TodayOrders ?? 0).ToString();

                lblLowStock.Text =
                    (summary.LowStockCount ?? 0).ToString();

                lblActiveProducts.Text =
                    (summary.ActiveProducts ?? 0).ToString();
            }
            catch (Exception ex)
            {
                SetDashboardValuesToZero();

                if (showErrors)
                {
                    MessageBox.Show(
                        "Unable to load dashboard information.\n\n" +
                        ex.Message,
                        "Dashboard Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        private void LoadRecentTransactions(bool showErrors = true)
        {
            try
            {
                RecentTransactionsRepository repository =
                    new RecentTransactionsRepository();

                var transactions =
                    repository.GetRecentTransactions(
                        _currentUser.UserId);

                lblTransactionsTitle.Text = "Recent Transactions";

                dgvTransactions.DataSource = null;
                dgvTransactions.Columns.Clear();
                dgvTransactions.AutoGenerateColumns = true;
                dgvTransactions.DataSource = transactions;

                dgvTransactions.ReadOnly = true;
                dgvTransactions.AllowUserToAddRows = false;
                dgvTransactions.AllowUserToDeleteRows = false;
                dgvTransactions.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvTransactions.MultiSelect = false;
                dgvTransactions.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
                dgvTransactions.RowHeadersVisible = false;

                if (dgvTransactions.Columns["OrderId"] != null)
                    dgvTransactions.Columns["OrderId"].Visible = false;

                if (dgvTransactions.Columns["OrderNumber"] != null)
                    dgvTransactions.Columns["OrderNumber"].HeaderText =
                        "Order No.";

                if (dgvTransactions.Columns["OrderDate"] != null)
                {
                    dgvTransactions.Columns["OrderDate"].HeaderText =
                        "Date";

                    dgvTransactions.Columns["OrderDate"]
                        .DefaultCellStyle.Format =
                        "MMM dd, yyyy hh:mm tt";
                }

                if (dgvTransactions.Columns["CashierName"] != null)
                {
                    dgvTransactions.Columns["CashierName"].HeaderText =
                        "Cashier";
                }

                if (dgvTransactions.Columns["Total"] != null)
                {
                    dgvTransactions.Columns["Total"].HeaderText =
                        "Total";

                    dgvTransactions.Columns["Total"]
                        .DefaultCellStyle.Format = "₱#,##0.00";
                }

                if (dgvTransactions.Columns["PaymentMethod"] != null)
                    dgvTransactions.Columns["PaymentMethod"].HeaderText =
                        "Payment";

                if (dgvTransactions.Columns["Status"] != null)
                    dgvTransactions.Columns["Status"].HeaderText =
                        "Status";

                if (transactions == null ||
                    dgvTransactions.Rows.Count == 0)
                {
                    lblTransactionsTitle.Text =
                        "Recent Transactions — No transactions yet";
                }
            }
            catch (Exception ex)
            {
                if (showErrors)
                {
                    MessageBox.Show(
                        "Unable to load recent transactions.\n\n" +
                        ex.Message,
                        "Transaction Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        private void LoadLowStockTable(bool showErrors = true)
        {
            try
            {
                LowStockRepository repository =
                    new LowStockRepository();

                var products = repository.GetLowStockProducts(
                    _currentUser.UserId);

                _dgvLowStock.DataSource = null;
                _dgvLowStock.DataSource = products;

                if (_dgvLowStock.Columns["ProductId"] != null)
                    _dgvLowStock.Columns["ProductId"].Visible = false;

                if (_dgvLowStock.Columns["Sku"] != null)
                    _dgvLowStock.Columns["Sku"].HeaderText = "SKU";

                if (_dgvLowStock.Columns["Name"] != null)
                    _dgvLowStock.Columns["Name"].HeaderText =
                        "Product Name";

                if (_dgvLowStock.Columns["StockQty"] != null)
                    _dgvLowStock.Columns["StockQty"].HeaderText =
                        "Stock Quantity";

                if (_dgvLowStock.Columns["ReorderLevel"] != null)
                    _dgvLowStock.Columns["ReorderLevel"].HeaderText =
                        "Reorder Level";
            }
            catch (Exception ex)
            {
                if (showErrors)
                {
                    MessageBox.Show(
                        "Unable to load low-stock products.\n\n" +
                        ex.Message,
                        "Inventory Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        private void ClearRestrictedDashboardData()
        {
            SetDashboardValuesToZero();

            lblTransactionsTitle.Text =
                "Recent Transactions — Not available for your role";

            dgvTransactions.DataSource = null;
            dgvTransactions.Columns.Clear();

            _lblLowStockTitle.Text =
                "Low Stock Products — Not available for your role";

            _dgvLowStock.DataSource = null;
            _dgvLowStock.Columns.Clear();
        }

        private void SetDashboardValuesToZero()
        {
            lblTodaySales.Text = "₱0.00";
            lblTodayOrders.Text = "0";
            lblLowStock.Text = "0";
            lblActiveProducts.Text = "0";
        }

        #endregion

        #region Void Order

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (!_canVoidOrders)
            {
                MessageBox.Show(
                    "You are not authorized to void orders.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (dgvTransactions.CurrentRow == null ||
                dgvTransactions.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show(
                    "Please select a transaction first.",
                    "No Transaction Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            var transaction =
                dgvTransactions.CurrentRow.DataBoundItem
                as usp_Report_RecentTransactionsResult;

            if (transaction == null)
            {
                MessageBox.Show(
                    "Unable to read the selected transaction.",
                    "Transaction Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!string.Equals(
                transaction.Status,
                "Completed",
                StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Only completed transactions can be voided.",
                    "Invalid Transaction",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult confirmation = MessageBox.Show(
                "Are you sure you want to void this transaction?\n\n" +
                "Order No.: " + transaction.OrderNumber + "\n" +
                "Total: " + transaction.Total.ToString(
                    "C2",
                    CultureInfo.GetCultureInfo("en-PH")),
                "Confirm Void",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes)
                return;

            try
            {
                SalesService salesService = new SalesService();

                string message = salesService.VoidSale(
                    transaction.OrderId,
                    _currentUser.UserId
                );

                // Refresh dashboard data after voiding.
                RefreshDashboardData(true);

                MessageBox.Show(
                    message,
                    "Void Order",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Void Order Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        #endregion

        #region Child Form Events

        private void ProductForm_RequestClose(
            object sender, EventArgs e)
        {
            ShowDashboardPage();
        }

        #endregion

        #region Form Closing

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Stop and dispose dashboard timer.
            if (_dashboardRefreshTimer != null)
            {
                _dashboardRefreshTimer.Stop();

                _dashboardRefreshTimer.Tick -=
                    DashboardRefreshTimer_Tick;

                _dashboardRefreshTimer.Dispose();
                _dashboardRefreshTimer = null;
            }

            if (_productForm != null)
            {
                _productForm.RequestClose -=
                    ProductForm_RequestClose;

                _productForm.Dispose();
                _productForm = null;
            }

            if (_inventoryForm != null)
            {
                _inventoryForm.Dispose();
                _inventoryForm = null;
            }

            if (_salesForm != null)
            {
                _salesForm.Dispose();
                _salesForm = null;
            }

            if (_analyticsForm != null)
            {
                _analyticsForm.Dispose();
                _analyticsForm = null;
            }

            if (_userAdminForm != null)
            {
                _userAdminForm.Dispose();
                _userAdminForm = null;
            }

            base.OnFormClosed(e);
        }

        #endregion
    }
}