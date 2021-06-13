using System;
using System.Collections.Generic;

#nullable disable

namespace superTech.Database
{
    public partial class Bill
    {
        public Bill()
        {
            BillItems = new HashSet<BillItem>();
        }

        public int BillId { get; set; }
        public int BillNumber { get; set; }
        public DateTime IssuingDate { get; set; }
        public bool Closed { get; set; }
        public decimal Tax { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountWithTax { get; set; }
        public int? FkUserId { get; set; }
        public int? FkBuyerOrder { get; set; }

        public virtual BuyerOrder FkBuyerOrderNavigation { get; set; }
        public virtual User FkUser { get; set; }
        public virtual ICollection<BillItem> BillItems { get; set; }
    }
}
