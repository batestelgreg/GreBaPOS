using EnterprisePOS.Domain.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnterprisePOS.WinForms.Classes
{
    public sealed class ReceiptService : IDisposable
    {
        private readonly ReceiptData _receipt;
        private readonly PrintDocument _document;
        private readonly List<string> _lines;
        private int _currentLine;
        private const int ReceiptWidth = 42;
        private const int NameWidth = 24;
        private const int QtyWidth = 5;
        private const int AmtWidth = 13;
        private const int HeaderLineCount = 3;

        private const int PaperWidth = 315;

        private const int EstimatedLineHeight = 18;
        private const int VerticalPadding = 40;
        private const int MinimumPaperHeight = 400;

        public ReceiptService(ReceiptData receipt)
        {
            _receipt = receipt ??
                throw new ArgumentNullException(nameof(receipt));

            _document = new PrintDocument();
            _document.DocumentName =
                "Receipt - " + receipt.OrderNumber;

            _document.DefaultPageSettings.Margins =
                new Margins(5, 5, 8, 8);

            _lines = BuildLines();

            int estimatedHeight =
                (_lines.Count * EstimatedLineHeight)
                + VerticalPadding;

            if (estimatedHeight < MinimumPaperHeight)
                estimatedHeight = MinimumPaperHeight;

            _document.DefaultPageSettings.PaperSize =
                new PaperSize(
                    "80mm Receipt",
                    PaperWidth,
                    estimatedHeight);

            _document.PrintPage += Document_PrintPage;
        }

        private string Center(string text)
        {
            if (text.Length >= ReceiptWidth)
                return text;

            return text.PadLeft(
                (ReceiptWidth + text.Length) / 2)
                .PadRight(ReceiptWidth);
        }

        private List<string> WrapText(string text, int width)
        {
            var result = new List<string>();

            if (string.IsNullOrWhiteSpace(text))
            {
                result.Add("");
                return result;
            }

            string remaining = text.Trim();

            while (remaining.Length > width)
            {
                int split = remaining.LastIndexOf(' ', width);

                if (split <= 0)
                    split = width;

                result.Add(
                    remaining.Substring(0, split).Trim());

                remaining = remaining.Substring(split).Trim();
            }

            if (remaining.Length > 0)
                result.Add(remaining);

            return result;
        }

        private string AmountLine(string label, decimal amount)
        {
            string value = "₱" + amount.ToString("N2");

            int spaces =
                ReceiptWidth - label.Length - value.Length;

            if (spaces < 1)
                spaces = 1;

            return label + new string(' ', spaces) + value;
        }

        private string ItemRow(
            string name, string qty, string amount)
        {
            return name.PadRight(NameWidth) +
                   qty.PadLeft(QtyWidth) +
                   amount.PadLeft(AmtWidth);
        }

        private List<string> BuildLines()
        {
            var lines = new List<string>();

            lines.Add(_receipt.BusinessName);
            lines.Add(_receipt.BusinessAddress);
            lines.Add(_receipt.BusinessPhone);

            lines.Add(new string('-', ReceiptWidth));

            lines.Add("Order: " + _receipt.OrderNumber);
            lines.Add("Date : " +
                _receipt.OrderDate.ToString("yyyy-MM-dd HH:mm"));
            lines.Add("Cashier: " + _receipt.CashierName);

            lines.Add(new string('-', ReceiptWidth));

            lines.Add(ItemRow("Product", "Qty", "Amount"));

            lines.Add(new string('-', ReceiptWidth));

            foreach (var item in _receipt.Items)
            {
                var nameLines =
                    WrapText(item.ProductName, NameWidth);

                string qty = item.Quantity.ToString();
                string amount =
                    "₱" + item.LineTotal.ToString("N2");

                lines.Add(
                    ItemRow(nameLines[0], qty, amount));

                for (int i = 1; i < nameLines.Count; i++)
                    lines.Add(nameLines[i]);
            }

            lines.Add(new string('-', ReceiptWidth));

            lines.Add(AmountLine("Subtotal", _receipt.Subtotal));
            lines.Add(AmountLine("Tax", _receipt.Tax));
            lines.Add(AmountLine("Discount", _receipt.Discount));
            lines.Add(AmountLine("TOTAL", _receipt.Total));

            lines.Add(new string('-', ReceiptWidth));

            lines.Add(
                "Payment: " + _receipt.PaymentMethod.ToUpper());

            lines.Add(
                AmountLine("Tendered", _receipt.AmountPaid));

            lines.Add(
                AmountLine("Change", _receipt.ChangeDue));

            lines.Add("");
            lines.Add(Center("Thank you for your purchase!"));
            lines.Add("");

            lines.AddRange(
                WrapText(_receipt.ReturnPolicy, ReceiptWidth));

            lines.Add("");
            lines.Add(Center("Please come again!"));

            return lines;
        }

        private void Document_PrintPage(
            object sender, PrintPageEventArgs e)
        {
            using (var font = new Font("Consolas", 9f))
            using (var boldFont =
                new Font("Consolas", 9f, FontStyle.Bold))
            using (var titleFont =
                new Font("Consolas", 11f, FontStyle.Bold))
            using (var brush = new SolidBrush(Color.Black))
            {
                float y = e.MarginBounds.Top;
                float lineSpacing = 4f;

                while (_currentLine < _lines.Count)
                {
                    string text = _lines[_currentLine];

                    bool isTitle = _currentLine == 0;
                    bool isHeader =
                        _currentLine < HeaderLineCount;
                    bool isTotal = text.StartsWith("TOTAL");

                    Font selectedFont =
                        isTitle ? titleFont :
                        isTotal ? boldFont : font;

                    float height =
                        selectedFont.GetHeight(e.Graphics)
                        + lineSpacing;

                    if (y + height > e.MarginBounds.Bottom)
                    {

                        e.HasMorePages = true;
                        return;
                    }

                    float x = e.MarginBounds.Left;

                    if (isHeader)
                    {
                        SizeF size = e.Graphics.MeasureString(
                            text,
                            selectedFont,
                            int.MaxValue,
                            StringFormat.GenericTypographic);

                        x = e.MarginBounds.Left +
                            (e.MarginBounds.Width - size.Width) / 2f;
                    }

                    e.Graphics.DrawString(
                        text,
                        selectedFont,
                        brush,
                        x,
                        y,
                        StringFormat.GenericTypographic);

                    y += height;
                    _currentLine++;
                }

                e.HasMorePages = false;
                _currentLine = 0;
            }
        }

        public void ShowPrintPreview(IWin32Window owner)
        {
            _currentLine = 0;

            using (var preview = new PrintPreviewDialog())
            {
                preview.Document = _document;
                preview.Width = 900;
                preview.Height = 700;
                preview.StartPosition =
                    FormStartPosition.CenterParent;

                preview.ShowDialog(owner);
            }

            _currentLine = 0;
        }

        public void Print()
        {
            _currentLine = 0;
            _document.Print();
            _currentLine = 0;
        }

        public void Dispose()
        {
            _document.PrintPage -= Document_PrintPage;
            _document.Dispose();
        }
    }
}