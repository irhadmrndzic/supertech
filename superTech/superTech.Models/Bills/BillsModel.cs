using superTech.Models.Bills.BillItems;
using System;
using System.Collections.Generic;

namespace superTech.Models.Bills
{
    public class BillsModel
    {
        public int BillId { get; set; }
        public int BillNumber { get; set; }
        public DateTime IssuingDate { get; set; }
        public bool Closed { get; set; }
        public decimal Tax { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountWithTax { get; set; }
        public int? FkUserId { get; set; }
        public int? FkBuyerOrder { get; set; }
        //public string EmployeeString { get; set; }
        //public string BuyerString { get; set; }

        public virtual ICollection<BillItemsModel> BillItems { get; set; }

    }
}
