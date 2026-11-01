using EnterprisePOS.Domain.Class;
using EnterprisePOS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnterprisePOS.Domain;

namespace EnterprisePOS.WinForms
{
    public partial class LoginForm : Form
    {
        private readonly LoginService _loginService;
        private bool _isLoggingIn;

        public LoginForm()
        {
            InitializeComponent();

            _loginService = new LoginService();

            AcceptButton = btnLogin;
            txtPassword.UseSystemPasswordChar = true;

            lblStatus.Text = string.Empty;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (_isLoggingIn)
                return;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            lblStatus.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                lblStatus.Text =
                    "Enter your username and password.";

                return;
            }

            _isLoggingIn = true;
            btnLogin.Enabled = false;
            btnLogin.Text = "Signing in...";

            try
            {
                UserSession user =
                    await _loginService.LoginAsync(username, password);

                if (user == null)
                {
                    lblStatus.Text =
                        "Invalid username or password.";

                    txtPassword.Clear();
                    txtPassword.Focus();

                    return;
                }

                MessageBox.Show(
                    "Successful login!\n\n" +
                    "Login in as: " + user.FullName +
                    "\nRole: " + user.RoleName,
                    "Login Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Hide();

                using (MainForm mainForm = new MainForm(user))
                {
                    mainForm.ShowDialog(this);
                }

                txtPassword.Clear();
                lblStatus.Text = string.Empty;

                Show();
                txtUsername.Focus();
            }
            catch (Exception)
            {
                lblStatus.Text =
                    "Unable to sign in. Please try again later.";
            }
            finally
            {
                _isLoggingIn = false;

                if (!IsDisposed)
                {
                    btnLogin.Enabled = true;
                    btnLogin.Text = "Sign In";
                }
            }
        }
    }
}