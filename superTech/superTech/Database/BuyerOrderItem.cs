using System;
using System.Collections.Generic;

#nullable disable

namespace superTech.Database
{
    public partial class BuyerOrderItem
    {
        public int BuyerOrderItemsId { get; set; }
        public int? Quantity { get; set; }
        public int? FkProductId { get; set; }
        public int? FkBuyerOrder { get; set; }
        public decimal? Amount { get; set; }

        public virtual BuyerOrder FkBuyerOrderNavigation { get; set; }
        public virtual Product FkProduct { get; set; }
    }
}
