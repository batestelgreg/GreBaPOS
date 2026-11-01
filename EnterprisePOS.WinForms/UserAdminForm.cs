using EnterprisePOS.Data;
using EnterprisePOS.Domain.Class;
using EnterprisePOS.Services;
using EnterprisePOS.Services.Service;
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
    public partial class UserAdminForm : Form
    {
        private readonly UserSession _currentUser;
        private readonly UserAdministrationService _service;
        private bool _isUpdatingFields;

        private readonly ErrorProvider _errorProvider = new ErrorProvider();
        private readonly ToolTip _toolTip = new ToolTip();

        public UserAdminForm(UserSession currentUser)
        {
            if (currentUser == null)
                throw new ArgumentNullException(nameof(currentUser));

            InitializeComponent();

            _currentUser = currentUser;
            _service = new UserAdministrationService();

            RegisterEvents();
            ConfigureForm();
        }

        private void RegisterEvents()
        {
            btnRefresh.Click += btnRefresh_Click;
            btnCreate.Click += btnCreate_Click;
            btnResetPassword.Click += btnResetPassword_Click;
            btnActivate.Click += btnActivate_Click;
            btnDeactivate.Click += btnDeactivate_Click;
            btnSearch.Click += btnSearch_Click;
            btnClearSearch.Click += btnClearSearch_Click;
            btnRefreshAudit.Click += btnRefreshAudit_Click;

            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;
            txtAuditSearch.KeyDown += txtAuditSearch_KeyDown;
        }

        private void ConfigureForm()
        {
            lblCurrentUser.Text =
                "Logged in as: " + _currentUser.FullName +
                " (" + _currentUser.RoleName + ")";

            _errorProvider.ContainerControl = this;
            _errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            _toolTip.SetToolTip(txtNewUsername, "Required field: Username");
            _toolTip.SetToolTip(txtNewPassword,
                "Required field: Password (minimum 8 characters)");
            _toolTip.SetToolTip(txtFirstName, "Required field: First Name");
            _toolTip.SetToolTip(txtLastName, "Required field: Last Name");
            _toolTip.SetToolTip(cboNewRole, "Required field: Role");

            LoadRoles();
            SetDefaultFilterSelections();
            SetCreateMode();
            LoadUsers();
            LoadAuditHistory();
        }

        private void SetDefaultFilterSelections()
        {
            cboStatusFilter.SelectedIndex =
                cboStatusFilter.Items.Count > 0 ? 0 : -1;

            cboRoleFilter.SelectedIndex =
                cboRoleFilter.Items.Count > 0 ? 0 : -1;

            cboNewRole.SelectedIndex =
                cboNewRole.Items.Count > 0 ? 0 : -1;
        }

        private void LoadRoles()
        {
            try
            {
                cboNewRole.Items.Clear();
                cboRoleFilter.Items.Clear();

                var roles = _service.GetRoles(_currentUser.UserId);

                cboRoleFilter.Items.Add(new RoleOption
                {
                    RoleId = 0,
                    RoleName = "All Roles"
                });

                if (roles != null)
                {
                    foreach (var role in roles)
                    {
                        var option = new RoleOption
                        {
                            RoleId = role.RoleId,
                            RoleName = role.RoleName
                        };

                        cboNewRole.Items.Add(option);

                        cboRoleFilter.Items.Add(new RoleOption
                        {
                            RoleId = role.RoleId,
                            RoleName = role.RoleName
                        });
                    }
                }

                cboRoleFilter.SelectedIndex =
                    cboRoleFilter.Items.Count > 0 ? 0 : -1;

                cboNewRole.SelectedIndex =
                    cboNewRole.Items.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                ShowError("Unable to load roles.", ex);
            }
        }

        private void LoadUsers()
        {
            try
            {
                int? roleId = null;
                bool? isActive = null;

                if (cboRoleFilter.SelectedItem is RoleOption selectedRole &&
                    selectedRole.RoleId > 0)
                {
                    roleId = selectedRole.RoleId;
                }

                string status = cboStatusFilter.SelectedItem?.ToString() ?? "";

                if (status == "Active")
                    isActive = true;
                else if (status == "Inactive")
                    isActive = false;

                var users = _service.GetUsers(
                    _currentUser.UserId,
                    txtSearch.Text.Trim(),
                    roleId,
                    isActive);

                dgvUsers.DataSource = null;
                dgvUsers.DataSource = users;

                ConfigureUsersGrid();
                ClearGridSelection();
                UpdateSelectedUser();
            }
            catch (Exception ex)
            {
                ShowError("Unable to load users.", ex);
            }
        }

        private void ConfigureUsersGrid()
        {
            dgvUsers.AutoGenerateColumns = true;
            dgvUsers.ReadOnly = true;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.MultiSelect = false;
            dgvUsers.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.ScrollBars = ScrollBars.Both;
            dgvUsers.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;

            SetColumnHeader("UserId", "User ID");
            SetColumnHeader("Username", "Username");
            SetColumnHeader("FirstName", "First Name");
            SetColumnHeader("MiddleName", "Middle Name");
            SetColumnHeader("LastName", "Last Name");
            SetColumnHeader("FullName", "Full Name");
            SetColumnHeader("RoleName", "Role");
            SetColumnHeader("IsActive", "Status");
            SetColumnHeader("CreatedAt", "Date Created");
            SetColumnHeader("LastLoginAt", "Last Login");

            HideColumn("PasswordHash");
            HideColumn("Salt");
            HideColumn("RoleId");

            SetColumnWidth("UserId", 70);
            SetColumnWidth("Username", 120);
            SetColumnWidth("FirstName", 120);
            SetColumnWidth("MiddleName", 120);
            SetColumnWidth("LastName", 120);
            SetColumnWidth("FullName", 170);
            SetColumnWidth("RoleName", 100);
            SetColumnWidth("IsActive", 80);
            SetColumnWidth("CreatedAt", 150);
            SetColumnWidth("LastLoginAt", 150);

            foreach (DataGridViewColumn column in dgvUsers.Columns)
            {
                column.Resizable = DataGridViewTriState.True;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void SetColumnHeader(string name, string text)
        {
            if (dgvUsers.Columns.Contains(name))
                dgvUsers.Columns[name].HeaderText = text;
        }

        private void SetColumnWidth(string name, int width)
        {
            if (dgvUsers.Columns.Contains(name))
                dgvUsers.Columns[name].Width = width;
        }

        private void HideColumn(string name)
        {
            if (dgvUsers.Columns.Contains(name))
                dgvUsers.Columns[name].Visible = false;
        }

        private void ClearGridSelection()
        {
            dgvUsers.ClearSelection();
            dgvUsers.CurrentCell = null;

            if (dgvUsers.Columns.Count > 0)
            {
                foreach (DataGridViewColumn column in dgvUsers.Columns)
                {
                    if (column.Visible)
                    {
                        dgvUsers.FirstDisplayedScrollingColumnIndex =
                            column.Index;
                        break;
                    }
                }
            }

            if (dgvUsers.Rows.Count > 0)
                dgvUsers.FirstDisplayedScrollingRowIndex = 0;
        }

        private void LoadAuditHistory()
        {
            try
            {
                var history = _service.GetAuditHistory(
                    _currentUser.UserId,
                    txtAuditSearch.Text.Trim());

                dgvAuditHistory.DataSource = null;
                dgvAuditHistory.DataSource = history;

                if (dgvAuditHistory.Columns.Contains("PasswordHash"))
                    dgvAuditHistory.Columns["PasswordHash"].Visible = false;

                if (dgvAuditHistory.Columns.Contains("Salt"))
                    dgvAuditHistory.Columns["Salt"].Visible = false;

                dgvAuditHistory.ScrollBars = ScrollBars.Both;
                dgvAuditHistory.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            catch (Exception ex)
            {
                ShowError("Unable to load audit history.", ex);
            }
        }

        private int? GetSelectedUserId()
        {
            if (dgvUsers.CurrentRow == null ||
                dgvUsers.CurrentRow.IsNewRow ||
                !dgvUsers.Columns.Contains("UserId"))
                return null;

            object value = dgvUsers.CurrentRow.Cells["UserId"].Value;

            if (value == null || value == DBNull.Value)
                return null;

            return int.TryParse(value.ToString(), out int id)
                ? id
                : (int?)null;
        }

        private string GetSelectedUsername()
        {
            if (dgvUsers.CurrentRow == null ||
                !dgvUsers.Columns.Contains("Username"))
                return "";

            return Convert.ToString(
                dgvUsers.CurrentRow.Cells["Username"].Value) ?? "";
        }

        private bool? GetSelectedUserStatus()
        {
            if (dgvUsers.CurrentRow == null ||
                !dgvUsers.Columns.Contains("IsActive"))
                return null;

            object value = dgvUsers.CurrentRow.Cells["IsActive"].Value;

            if (value == null || value == DBNull.Value)
                return null;

            if (value is bool status)
                return status;

            if (bool.TryParse(value.ToString(), out bool parsed))
                return parsed;

            string text = value.ToString();

            if (text.Equals("Active", StringComparison.OrdinalIgnoreCase))
                return true;

            if (text.Equals("Inactive", StringComparison.OrdinalIgnoreCase))
                return false;

            return null;
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (_isUpdatingFields)
                return;

            UpdateSelectedUser();
        }

        private void UpdateSelectedUser()
        {
            int? userId = GetSelectedUserId();
            bool hasSelection = userId.HasValue;

            btnResetPassword.Enabled = hasSelection;
            btnActivate.Enabled = hasSelection;
            btnDeactivate.Enabled = hasSelection;

            if (!hasSelection)
            {
                lblSelectedUser.Text = "No user selected.";
                SetCreateMode();
                return;
            }

            DataGridViewRow row = dgvUsers.CurrentRow;

            _isUpdatingFields = true;

            try
            {
                txtNewUsername.Text =
                    Convert.ToString(row.Cells["Username"].Value) ?? "";

                txtFirstName.Text =
                    Convert.ToString(row.Cells["FirstName"].Value) ?? "";

                txtMiddleName.Text =
                    Convert.ToString(row.Cells["MiddleName"].Value) ?? "";

                txtLastName.Text =
                    Convert.ToString(row.Cells["LastName"].Value) ?? "";

                txtNewUsername.ReadOnly = false;
                txtNewPassword.Clear();
                txtNewPassword.Enabled = false;
                txtNewPassword.Visible = false;
                lblNewPassword.Visible = false;

                SelectExistingRole(row);

                btnCreate.Text = "Update User";

                lblSelectedUser.Text =
                    "Selected User: " + GetSelectedUsername() +
                    " (ID: " + userId.Value + ")";
            }
            finally
            {
                _isUpdatingFields = false;
            }

            ClearRequiredFieldErrors();
        }

        private void SelectExistingRole(DataGridViewRow row)
        {
            int roleId = 0;

            if (row.DataGridView.Columns.Contains("RoleId"))
            {
                object value = row.Cells["RoleId"].Value;

                if (value != null &&
                    value != DBNull.Value)
                {
                    int.TryParse(value.ToString(), out roleId);
                }
            }

            string roleName =
                Convert.ToString(row.Cells["RoleName"].Value) ?? "";

            for (int i = 0; i < cboNewRole.Items.Count; i++)
            {
                if (cboNewRole.Items[i] is RoleOption option &&
                    ((roleId > 0 && option.RoleId == roleId) ||
                     (roleId == 0 &&
                      option.RoleName.Equals(
                          roleName,
                          StringComparison.OrdinalIgnoreCase))))
                {
                    cboNewRole.SelectedIndex = i;
                    return;
                }
            }
        }

        private void SetCreateMode()
        {
            _isUpdatingFields = true;

            try
            {
                txtNewUsername.ReadOnly = false;

                txtNewPassword.Enabled = true;
                txtNewPassword.Visible = true;
                lblNewPassword.Visible = true;

                btnCreate.Text = "Create User";

                txtNewUsername.Clear();
                txtNewPassword.Clear();
                txtFirstName.Clear();
                txtMiddleName.Clear();
                txtLastName.Clear();

                if (cboNewRole.Items.Count > 0)
                    cboNewRole.SelectedIndex = 0;
            }
            finally
            {
                _isUpdatingFields = false;
            }

            ClearRequiredFieldErrors();
        }

        private void ClearRequiredFieldErrors()
        {
            _errorProvider.SetError(txtNewUsername, "");
            _errorProvider.SetError(txtNewPassword, "");
            _errorProvider.SetError(txtFirstName, "");
            _errorProvider.SetError(txtLastName, "");
            _errorProvider.SetError(cboNewRole, "");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (GetSelectedUserId().HasValue)
            {
                UpdateSelectedUserDetails();
                return;
            }

            CreateUser();
        }

        private void CreateUser()
        {
            ClearRequiredFieldErrors();

            string username = txtNewUsername.Text.Trim();
            string password = txtNewPassword.Text;
            string firstName = txtFirstName.Text.Trim();
            string middleName = txtMiddleName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            var missing = new List<string>();

            if (string.IsNullOrWhiteSpace(username))
            {
                missing.Add("Username");
                _errorProvider.SetError(txtNewUsername, "Username is required.");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                missing.Add("Password");
                _errorProvider.SetError(txtNewPassword, "Password is required.");
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                missing.Add("First Name");
                _errorProvider.SetError(txtFirstName, "First Name is required.");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                missing.Add("Last Name");
                _errorProvider.SetError(txtLastName, "Last Name is required.");
            }

            RoleOption role = cboNewRole.SelectedItem as RoleOption;

            if (role == null || role.RoleId <= 0)
            {
                missing.Add("Role");
                _errorProvider.SetError(cboNewRole, "Please select a role.");
            }

            if (missing.Count > 0)
            {
                MessageBox.Show(
                    "Please complete the following required fields:\n\n" +
                    string.Join("\n", missing.Select(x => "⚠ " + x)),
                    "Required Fields Missing",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (password.Length < 8)
            {
                _errorProvider.SetError(
                    txtNewPassword,
                    "Password must contain at least 8 characters.");

                MessageBox.Show(
                    "Password must contain at least 8 characters.",
                    "Invalid Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNewPassword.Focus();
                return;
            }

            if (MessageBox.Show(
                "Create account for '" + username + "'?",
                "Confirm Create User",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _service.CreateUser(
                    _currentUser.UserId,
                    username,
                    password,
                    firstName,
                    middleName,
                    lastName,
                    role.RoleId);

                MessageBox.Show(
                    "User created successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                SetCreateMode();
                LoadUsers();
                LoadAuditHistory();
            }
            catch (Exception ex)
            {
                if (HandleDuplicateUsername(ex, username))
                    return;

                ShowError("Unable to create user.", ex);
            }
        }

        private void UpdateSelectedUserDetails()
        {
            int? userId = GetSelectedUserId();

            if (!userId.HasValue)
            {
                MessageBox.Show(
                    "Please select a user first.",
                    "Update User",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string username = txtNewUsername.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string middleName = txtMiddleName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            RoleOption role = cboNewRole.SelectedItem as RoleOption;

            ClearRequiredFieldErrors();

            if (string.IsNullOrWhiteSpace(username))
                _errorProvider.SetError(
                    txtNewUsername, "Username is required.");

            if (string.IsNullOrWhiteSpace(firstName))
                _errorProvider.SetError(
                    txtFirstName, "First Name is required.");

            if (string.IsNullOrWhiteSpace(lastName))
                _errorProvider.SetError(
                    txtLastName, "Last Name is required.");

            if (role == null || role.RoleId <= 0)
                _errorProvider.SetError(
                    cboNewRole, "Please select a role.");

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                role == null ||
                role.RoleId <= 0)
            {
                MessageBox.Show(
                    "Please complete Username, First Name, Last Name, and Role.",
                    "Required Fields",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string oldUsername = GetSelectedUsername();

            if (MessageBox.Show(
                "Save changes for '" + oldUsername +
                "' to username '" + username + "'?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _service.UpdateUser(
                    _currentUser.UserId,
                    userId.Value,
                    username,
                    firstName,
                    middleName,
                    lastName,
                    role.RoleId);

                MessageBox.Show(
                    "User updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadUsers();
                SelectUserRow(userId.Value);
                LoadAuditHistory();
            }
            catch (Exception ex)
            {
                if (HandleDuplicateUsername(ex, username))
                    return;

                ShowError("Unable to update user.", ex);
            }
        }
        private void SelectUserRow(int userId)
        {
            foreach (DataGridViewRow row in dgvUsers.Rows)
            {
                if (row.IsNewRow ||
                    !dgvUsers.Columns.Contains("UserId"))
                    continue;

                object value = row.Cells["UserId"].Value;

                if (value != null &&
                    value != DBNull.Value &&
                    int.TryParse(value.ToString(), out int id) &&
                    id == userId)
                {
                    row.Selected = true;

                    if (dgvUsers.Columns.Count > 0)
                        dgvUsers.CurrentCell = row.Cells[
                            dgvUsers.Columns.GetFirstColumn(
                                DataGridViewElementStates.Visible).Index];

                    return;
                }
            }

            ClearGridSelection();
            UpdateSelectedUser();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();

            if (cboRoleFilter.Items.Count > 0)
                cboRoleFilter.SelectedIndex = 0;

            if (cboStatusFilter.Items.Count > 0)
                cboStatusFilter.SelectedIndex = 0;

            LoadUsers();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRoles();
            SetDefaultFilterSelections();
            LoadUsers();
            LoadAuditHistory();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            int? userId = GetSelectedUserId();

            if (!userId.HasValue)
            {
                MessageBox.Show(
                    "Please select a user first.",
                    "Reset Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (PasswordPromptForm prompt =
                new PasswordPromptForm(GetSelectedUsername()))
            {
                if (prompt.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    _service.ResetPassword(
                        _currentUser.UserId,
                        userId.Value,
                        prompt.NewPassword);

                    MessageBox.Show(
                        "Password reset successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadAuditHistory();
                }
                catch (Exception ex)
                {
                    ShowError("Unable to reset password.", ex);
                }
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            ChangeUserStatus(true);
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            ChangeUserStatus(false);
        }

        private void ChangeUserStatus(bool activate)
        {
            int? userId = GetSelectedUserId();

            if (!userId.HasValue)
            {
                MessageBox.Show(
                    "Please select a user first.",
                    "User Status",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!activate && userId.Value == _currentUser.UserId)
            {
                MessageBox.Show(
                    "You cannot deactivate your own account while logged in.",
                    "User Status",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            bool? currentStatus = GetSelectedUserStatus();

            if (currentStatus.HasValue && currentStatus.Value == activate)
            {
                MessageBox.Show(
                    activate
                        ? "This user is already active."
                        : "This user is already inactive.",
                    "User Status",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string username = GetSelectedUsername();
            string action = activate ? "activate" : "deactivate";

            if (MessageBox.Show(
                "Are you sure you want to " + action +
                " the account '" + username + "'?",
                "Confirm User Status",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _service.SetUserStatus(
                    _currentUser.UserId,
                    userId.Value,
                    activate);

                MessageBox.Show(
                    activate
                        ? "User activated successfully."
                        : "User deactivated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadUsers();
                LoadAuditHistory();
            }
            catch (Exception ex)
            {
                ShowError("Unable to update user status.", ex);
            }
        }

        private void btnRefreshAudit_Click(object sender, EventArgs e)
        {
            LoadAuditHistory();
        }

        private void txtAuditSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadAuditHistory();
            }
        }

        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show(
                message + "\n\n" + ex.Message,
                "User Administration",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private sealed class RoleOption
        {
            public int RoleId { get; set; }
            public string RoleName { get; set; }

            public override string ToString()
            {
                return RoleName;
            }
        }

        private sealed class PasswordPromptForm : Form
        {
            private readonly TextBox txtPassword;
            private readonly TextBox txtConfirmPassword;

            public string NewPassword { get; private set; }

            public PasswordPromptForm(string username)
            {
                Text = "Reset Password";
                StartPosition = FormStartPosition.CenterParent;
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;
                MinimizeBox = false;
                ShowInTaskbar = false;
                ClientSize = new Size(380, 220);

                Label lblUser = new Label
                {
                    Text = "Reset password for: " + username,
                    AutoSize = true,
                    Left = 20,
                    Top = 18
                };

                Label lblPassword = new Label
                {
                    Text = "New Password",
                    AutoSize = true,
                    Left = 20,
                    Top = 55
                };

                txtPassword = new TextBox
                {
                    Left = 20,
                    Top = 75,
                    Width = 335,
                    UseSystemPasswordChar = true
                };

                Label lblConfirm = new Label
                {
                    Text = "Confirm Password",
                    AutoSize = true,
                    Left = 20,
                    Top = 110
                };

                txtConfirmPassword = new TextBox
                {
                    Left = 20,
                    Top = 130,
                    Width = 335,
                    UseSystemPasswordChar = true
                };

                Button btnOK = new Button
                {
                    Text = "Reset",
                    Left = 170,
                    Top = 175,
                    Width = 85
                };

                Button btnCancel = new Button
                {
                    Text = "Cancel",
                    Left = 265,
                    Top = 175,
                    Width = 90,
                    DialogResult = DialogResult.Cancel
                };

                btnOK.Click += (sender, args) =>
                {
                    if (txtPassword.Text.Length < 8)
                    {
                        MessageBox.Show(
                            "Password must contain at least 8 characters.",
                            "Validation",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    if (txtPassword.Text != txtConfirmPassword.Text)
                    {
                        MessageBox.Show(
                            "Passwords do not match.",
                            "Validation",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    NewPassword = txtPassword.Text;
                    DialogResult = DialogResult.OK;
                    Close();
                };

                Controls.Add(lblUser);
                Controls.Add(lblPassword);
                Controls.Add(txtPassword);
                Controls.Add(lblConfirm);
                Controls.Add(txtConfirmPassword);
                Controls.Add(btnOK);
                Controls.Add(btnCancel);

                AcceptButton = btnOK;
                CancelButton = btnCancel;
            }
        }

        private bool HandleDuplicateUsername(Exception ex, string username)
        {
            Exception current = ex;
            bool isDuplicate = false;

            while (current != null)
            {
                if (current is System.Data.SqlClient.SqlException sqlEx)
                {
                    foreach (System.Data.SqlClient.SqlError error in sqlEx.Errors)
                    {
                        if (error.Number == 50003 ||
                            error.Number == 2601 ||
                            error.Number == 2627)
                        {
                            isDuplicate = true;
                            break;
                        }
                    }
                }

                if (current.Message.IndexOf(
                    "Username already exists",
                    StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    isDuplicate = true;
                }

                if (isDuplicate)
                    break;

                current = current.InnerException;
            }

            if (!isDuplicate)
                return false;

            _errorProvider.SetError(
                txtNewUsername,
                "Username already exists. Please choose another username.");

            MessageBox.Show(
                "The username '" + username +
                "' already exists. Please use another username.",
                "Duplicate Username",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtNewUsername.Focus();
            txtNewUsername.SelectAll();

            return true;
        }
    }
}