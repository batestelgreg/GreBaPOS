using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace EnterprisePOS.WinForms.Classes
{
    public sealed class PaymentDialog : Form
    {
        private readonly decimal _total;
        private readonly Label lblTotal;
        private readonly ComboBox cmbPaymentMethod;
        private readonly NumericUpDown nudAmountPaid;
        private readonly Label lblChange;

        public string PaymentMethod
        {
            get { return cmbPaymentMethod.SelectedItem?.ToString(); }
        }

        public decimal AmountPaid
        {
            get { return nudAmountPaid.Value; }
        }

        public PaymentDialog(decimal total)
        {
            _total = total;

            Text = "Payment";
            Size = new Size(380, 300);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            var lblTotalTitle = new Label
            {
                Text = "Total Amount:",
                Location = new Point(25, 25),
                AutoSize = true
            };

            lblTotal = new Label
            {
                Text = total.ToString("N2"),
                Location = new Point(155, 25),
                AutoSize = true,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };

            var lblMethod = new Label
            {
                Text = "Payment Method:",
                Location = new Point(25, 75),
                AutoSize = true
            };

            cmbPaymentMethod = new ComboBox
            {
                Location = new Point(155, 70),
                Width = 175,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cmbPaymentMethod.Items.AddRange(
                new object[] { "Cash", "Card", "Mobile" });

            cmbPaymentMethod.SelectedIndex = 0;

            var lblPaid = new Label
            {
                Text = "Amount Paid:",
                Location = new Point(25, 120),
                AutoSize = true
            };

            nudAmountPaid = new NumericUpDown
            {
                Location = new Point(155, 115),
                Width = 175,
                DecimalPlaces = 2,
                Minimum = 0,
                Maximum = 100000000,
                ThousandsSeparator = true,
                Value = Math.Min(total, 100000000m)
            };

            lblChange = new Label
            {
                Text = "Change: 0.00",
                Location = new Point(155, 155),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            nudAmountPaid.ValueChanged += (s, e) =>
            {
                UpdateChange();
            };

            nudAmountPaid.TextChanged += (s, e) =>
            {
                UpdateChangeWhileTyping();
            };

            UpdateChange();

            var btnConfirm = new Button
            {
                Text = "Confirm Payment",
                Location = new Point(155, 200),
                Width = 175,
                Height = 35,
                DialogResult = DialogResult.None
            };

            btnConfirm.Click += (s, e) =>
            {
                if (nudAmountPaid.Value < _total)
                {
                    MessageBox.Show(
                        "Amount paid must be at least the total amount.",
                        "Insufficient Payment",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            };

            var btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(25, 200),
                Width = 110,
                Height = 35,
                DialogResult = DialogResult.Cancel
            };

            Controls.AddRange(new Control[]
            {
                lblTotalTitle, lblTotal, lblMethod, cmbPaymentMethod,
                lblPaid, nudAmountPaid, lblChange, btnConfirm, btnCancel
            });

            AcceptButton = btnConfirm;
            CancelButton = btnCancel;
        }

        private void UpdateChange()
        {
            decimal change = nudAmountPaid.Value - _total;

            if (change < 0)
                change = 0m;

            lblChange.Text = "Change: " + change.ToString("N2");
        }

        private void UpdateChangeWhileTyping()
        {
            decimal amountPaid;

            if (decimal.TryParse(
                nudAmountPaid.Text,
                System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.CurrentCulture,
                out amountPaid))
            {
                decimal change = amountPaid - _total;

                if (change < 0)
                    change = 0m;

                lblChange.Text = "Change: " + change.ToString("N2");
            }
        }
    }
}