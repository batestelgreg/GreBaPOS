using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterprisePOS.Domain.Class
{
    public sealed class ReceiptData
    {
        public string BusinessName { get; set; } = "GREBA ENTERPRISE POS";
        public string BusinessAddress { get; set; } = "123 Main Street, City";
        public string BusinessPhone { get; set; } = "Tel: +1 555 0100";

        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string CashierName { get; set; }

        public List<ReceiptItem> Items { get; set; }
            = new List<ReceiptItem>();

        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        public string PaymentMethod { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal ChangeDue { get; set; }

        public string ReturnPolicy { get; set; }
            = "Please keep your receipt for returns or exchanges.";
    }

    public sealed class ReceiptItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }
}