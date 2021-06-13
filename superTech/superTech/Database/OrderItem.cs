using System;
using System.Collections.Generic;

#nullable disable

namespace superTech.Database
{
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Amount { get; set; }
        public int? FkOrderId { get; set; }
        public int? FkProductId { get; set; }

        public virtual Order FkOrder { get; set; }
        public virtual Product FkProduct { get; set; }
    }
}
