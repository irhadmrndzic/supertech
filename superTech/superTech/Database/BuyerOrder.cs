using System;
using System.Collections.Generic;

#nullable disable

namespace superTech.Database
{
    public partial class BuyerOrder
    {
        public BuyerOrder()
        {
            Bills = new HashSet<Bill>();
            BuyerOrderItems = new HashSet<BuyerOrderItem>();
        }

        public int BuyerOrderId { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public bool Canceled { get; set; }
        public int? FkUserId { get; set; }

        public virtual User FkUser { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<BuyerOrderItem> BuyerOrderItems { get; set; }
    }
}
