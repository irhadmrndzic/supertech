using superTech.Models.BuyerOrders.BuyerOrderItems;
using System;
using System.Collections.Generic;

namespace superTech.Models.BuyerOrders
{
    public class BuyerOrdersUpsertRequest
    {
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public bool Canceled { get; set; }
        public int? UserId { get; set; }
        public int? OrderNumber { get; set; }
        public decimal? Amount { get; set; }
        public bool Confirmed { get; set; }


        public virtual ICollection<BuyerOrderItemsUpsertRequest> BuyerOrderItems { get; set; }

    }
}
