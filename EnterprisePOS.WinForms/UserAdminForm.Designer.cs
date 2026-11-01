namespace EnterprisePOS.WinForms
{
    partial class UserAdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label lblSelectedUser;

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.TabPage tabAudit;

        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblRoleFilter;
        private System.Windows.Forms.ComboBox cboRoleFilter;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.ComboBox cboStatusFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.DataGridView dgvUsers;

        private System.Windows.Forms.GroupBox grpCreateUser;
        private System.Windows.Forms.Label lblNewUsername;
        private System.Windows.Forms.TextBox txtNewUsername;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblNewRole;
        private System.Windows.Forms.ComboBox cboNewRole;

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Button btnDeactivate;

        private System.Windows.Forms.GroupBox grpAuditSearch;
        private System.Windows.Forms.Label lblAuditSearch;
        private System.Windows.Forms.TextBox txtAuditSearch;
        private System.Windows.Forms.Button btnRefreshAudit;
        private System.Windows.Forms.DataGridView dgvAuditHistory;

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

            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.lblSelectedUser = new System.Windows.Forms.Label();

            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.tabAudit = new System.Windows.Forms.TabPage();

            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblRoleFilter = new System.Windows.Forms.Label();
            this.cboRoleFilter = new System.Windows.Forms.ComboBox();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.cboStatusFilter = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();

            this.dgvUsers = new System.Windows.Forms.DataGridView();

            this.grpCreateUser = new System.Windows.Forms.GroupBox();
            this.lblNewUsername = new System.Windows.Forms.Label();
            this.txtNewUsername = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblNewRole = new System.Windows.Forms.Label();
            this.cboNewRole = new System.Windows.Forms.ComboBox();

            this.btnCreate = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnActivate = new System.Windows.Forms.Button();
            this.btnDeactivate = new System.Windows.Forms.Button();

            this.grpAuditSearch = new System.Windows.Forms.GroupBox();
            this.lblAuditSearch = new System.Windows.Forms.Label();
            this.txtAuditSearch = new System.Windows.Forms.TextBox();
            this.btnRefreshAudit = new System.Windows.Forms.Button();
            this.dgvAuditHistory = new System.Windows.Forms.DataGridView();

            this.tabMain.SuspendLayout();
            this.tabUsers.SuspendLayout();
            this.tabAudit.SuspendLayout();
            this.grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.grpCreateUser.SuspendLayout();
            this.grpAuditSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditHistory)).BeginInit();
            this.SuspendLayout();

            // Form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(1180, 760);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "UserAdminForm";
            this.Text = "User Administration";

            // Page title
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font(
                "Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(35, 45, 65);
            this.lblPageTitle.Location = new System.Drawing.Point(20, 15);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Text = "User Administration";

            // Current user
            this.lblCurrentUser.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right;
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCurrentUser.ForeColor = System.Drawing.Color.FromArgb(90, 100, 115);
            this.lblCurrentUser.Location = new System.Drawing.Point(750, 28);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Text = "Logged in as:";

            // Tabs
            this.tabMain.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.tabMain.Controls.Add(this.tabUsers);
            this.tabMain.Controls.Add(this.tabAudit);
            this.tabMain.Location = new System.Drawing.Point(20, 65);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1140, 675);

            // Users tab
            this.tabUsers.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.tabUsers.Text = "Users";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(10);
            this.tabUsers.AutoScroll = true;

            // Search group
            this.grpSearch.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.grpSearch.Controls.Add(this.lblSearch);
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Controls.Add(this.lblRoleFilter);
            this.grpSearch.Controls.Add(this.cboRoleFilter);
            this.grpSearch.Controls.Add(this.lblStatusFilter);
            this.grpSearch.Controls.Add(this.cboStatusFilter);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.btnClearSearch);
            this.grpSearch.Controls.Add(this.btnRefresh);
            this.grpSearch.Location = new System.Drawing.Point(10, 10);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(1095, 100);
            this.grpSearch.Text = "Search and Filter Users";

            // Search
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(15, 28);
            this.lblSearch.Text = "Search";

            this.txtSearch.Location = new System.Drawing.Point(18, 50);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(235, 27);

            // Role filter
            this.lblRoleFilter.AutoSize = true;
            this.lblRoleFilter.Location = new System.Drawing.Point(265, 28);
            this.lblRoleFilter.Text = "Role";

            this.cboRoleFilter.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoleFilter.Location = new System.Drawing.Point(268, 50);
            this.cboRoleFilter.Name = "cboRoleFilter";
            this.cboRoleFilter.Size = new System.Drawing.Size(165, 28);

            // Status filter
            this.lblStatusFilter.AutoSize = true;
            this.lblStatusFilter.Location = new System.Drawing.Point(450, 28);
            this.lblStatusFilter.Text = "Status";

            this.cboStatusFilter.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatusFilter.Items.AddRange(new object[]
            {
                "All Statuses",
                "Active",
                "Inactive"
            });
            this.cboStatusFilter.Location = new System.Drawing.Point(453, 50);
            this.cboStatusFilter.Name = "cboStatusFilter";
            this.cboStatusFilter.Size = new System.Drawing.Size(140, 28);

            // Search button
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(45, 105, 180);
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(610, 47);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 33);
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;

            // Clear search button
            this.btnClearSearch.Location = new System.Drawing.Point(715, 47);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(95, 33);
            this.btnClearSearch.Text = "Clear";

            // Refresh button
            this.btnRefresh.Location = new System.Drawing.Point(820, 47);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(95, 33);
            this.btnRefresh.Text = "Refresh";

            // Users grid
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.dgvUsers.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvUsers.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.ColumnHeadersHeight = 38;
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Location = new System.Drawing.Point(10, 120);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(1095, 255);

            // Selected user label
            this.lblSelectedUser.AutoSize = true;
            this.lblSelectedUser.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSelectedUser.Location = new System.Drawing.Point(10, 385);
            this.lblSelectedUser.Name = "lblSelectedUser";
            this.lblSelectedUser.Text = "No user selected.";

            // Create / Update group
            this.grpCreateUser.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            this.grpCreateUser.Controls.Add(this.lblNewUsername);
            this.grpCreateUser.Controls.Add(this.txtNewUsername);
            this.grpCreateUser.Controls.Add(this.lblNewPassword);
            this.grpCreateUser.Controls.Add(this.txtNewPassword);
            this.grpCreateUser.Controls.Add(this.lblFirstName);
            this.grpCreateUser.Controls.Add(this.txtFirstName);
            this.grpCreateUser.Controls.Add(this.lblMiddleName);
            this.grpCreateUser.Controls.Add(this.txtMiddleName);
            this.grpCreateUser.Controls.Add(this.lblLastName);
            this.grpCreateUser.Controls.Add(this.txtLastName);
            this.grpCreateUser.Controls.Add(this.lblNewRole);
            this.grpCreateUser.Controls.Add(this.cboNewRole);
            this.grpCreateUser.Controls.Add(this.btnCreate);
            this.grpCreateUser.Controls.Add(this.btnResetPassword);
            this.grpCreateUser.Controls.Add(this.btnActivate);
            this.grpCreateUser.Controls.Add(this.btnDeactivate);

            this.grpCreateUser.Location = new System.Drawing.Point(10, 410);
            this.grpCreateUser.Name = "grpCreateUser";
            this.grpCreateUser.Size = new System.Drawing.Size(1095, 205);
            this.grpCreateUser.Text = "Create User / Manage Selected User";

            // Username
            this.lblNewUsername.AutoSize = true;
            this.lblNewUsername.Location = new System.Drawing.Point(15, 30);
            this.lblNewUsername.Name = "lblNewUsername";
            this.lblNewUsername.Text = "Username *";

            this.txtNewUsername.Location = new System.Drawing.Point(18, 52);
            this.txtNewUsername.Name = "txtNewUsername";
            this.txtNewUsername.Size = new System.Drawing.Size(230, 27);

            // Password
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(265, 30);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Text = "Password *";

            this.txtNewPassword.Location = new System.Drawing.Point(268, 52);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(230, 27);
            this.txtNewPassword.UseSystemPasswordChar = true;

            // First name
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(515, 30);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Text = "First Name *";

            this.txtFirstName.Location = new System.Drawing.Point(518, 52);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(230, 27);

            // Middle name
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Location = new System.Drawing.Point(765, 30);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Text = "Middle Name";

            this.txtMiddleName.Location = new System.Drawing.Point(768, 52);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(140, 27);

            // Last name
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(15, 95);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Text = "Last Name *";

            this.txtLastName.Location = new System.Drawing.Point(18, 117);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(230, 27);

            // Role
            this.lblNewRole.AutoSize = true;
            this.lblNewRole.Location = new System.Drawing.Point(265, 95);
            this.lblNewRole.Name = "lblNewRole";
            this.lblNewRole.Text = "Role *";

            this.cboNewRole.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNewRole.Location = new System.Drawing.Point(268, 117);
            this.cboNewRole.Name = "cboNewRole";
            this.cboNewRole.Size = new System.Drawing.Size(230, 28);

            // Create / Update button
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(40, 145, 90);
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(518, 112);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(125, 38);
            this.btnCreate.Text = "Create User";
            this.btnCreate.UseVisualStyleBackColor = false;

            // Reset password
            this.btnResetPassword.Location = new System.Drawing.Point(650, 112);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(130, 38);
            this.btnResetPassword.Text = "Reset Password";
            this.btnResetPassword.Enabled = false;

            // Activate
            this.btnActivate.BackColor = System.Drawing.Color.FromArgb(40, 145, 90);
            this.btnActivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivate.ForeColor = System.Drawing.Color.White;
            this.btnActivate.Location = new System.Drawing.Point(785, 112);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(105, 38);
            this.btnActivate.Text = "Activate";
            this.btnActivate.Enabled = false;
            this.btnActivate.UseVisualStyleBackColor = false;

            // Deactivate
            this.btnDeactivate.BackColor = System.Drawing.Color.FromArgb(190, 65, 65);
            this.btnDeactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeactivate.ForeColor = System.Drawing.Color.White;
            this.btnDeactivate.Location = new System.Drawing.Point(895, 112);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(125, 38);
            this.btnDeactivate.Text = "Deactivate";
            this.btnDeactivate.Enabled = false;
            this.btnDeactivate.UseVisualStyleBackColor = false;

            // Add controls to Users tab
            this.tabUsers.Controls.Add(this.grpSearch);
            this.tabUsers.Controls.Add(this.dgvUsers);
            this.tabUsers.Controls.Add(this.lblSelectedUser);
            this.tabUsers.Controls.Add(this.grpCreateUser);

            // Audit tab
            this.tabAudit.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.tabAudit.Text = "Audit History";
            this.tabAudit.Padding = new System.Windows.Forms.Padding(10);

            // Audit search group
            this.grpAuditSearch.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.grpAuditSearch.Controls.Add(this.lblAuditSearch);
            this.grpAuditSearch.Controls.Add(this.txtAuditSearch);
            this.grpAuditSearch.Controls.Add(this.btnRefreshAudit);
            this.grpAuditSearch.Location = new System.Drawing.Point(10, 10);
            this.grpAuditSearch.Name = "grpAuditSearch";
            this.grpAuditSearch.Size = new System.Drawing.Size(1095, 85);
            this.grpAuditSearch.Text = "Search Audit History";

            this.lblAuditSearch.AutoSize = true;
            this.lblAuditSearch.Location = new System.Drawing.Point(15, 25);
            this.lblAuditSearch.Name = "lblAuditSearch";
            this.lblAuditSearch.Text = "Search";

            this.txtAuditSearch.Location = new System.Drawing.Point(18, 47);
            this.txtAuditSearch.Name = "txtAuditSearch";
            this.txtAuditSearch.Size = new System.Drawing.Size(300, 27);

            this.btnRefreshAudit.Location = new System.Drawing.Point(330, 44);
            this.btnRefreshAudit.Name = "btnRefreshAudit";
            this.btnRefreshAudit.Size = new System.Drawing.Size(120, 33);
            this.btnRefreshAudit.Text = "Refresh";

            // Audit history grid
            this.dgvAuditHistory.AllowUserToAddRows = false;
            this.dgvAuditHistory.AllowUserToDeleteRows = false;
            this.dgvAuditHistory.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.dgvAuditHistory.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAuditHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvAuditHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAuditHistory.ColumnHeadersHeight = 38;
            this.dgvAuditHistory.MultiSelect = false;
            this.dgvAuditHistory.ReadOnly = true;
            this.dgvAuditHistory.RowHeadersVisible = false;
            this.dgvAuditHistory.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuditHistory.Location = new System.Drawing.Point(10, 105);
            this.dgvAuditHistory.Name = "dgvAuditHistory";
            this.dgvAuditHistory.Size = new System.Drawing.Size(1095, 520);

            this.tabAudit.Controls.Add(this.grpAuditSearch);
            this.tabAudit.Controls.Add(this.dgvAuditHistory);

            // Add controls to form
            this.Controls.Add(this.lblPageTitle);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.tabMain);

            this.tabMain.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            this.tabUsers.PerformLayout();
            this.tabAudit.ResumeLayout(false);
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.grpCreateUser.ResumeLayout(false);
            this.grpCreateUser.PerformLayout();
            this.grpAuditSearch.ResumeLayout(false);
            this.grpAuditSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}