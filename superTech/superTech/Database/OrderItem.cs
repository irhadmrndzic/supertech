using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace superTech.Database
{
    public partial class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Amount { get; set; }
        public int? FkOrderId { get; set; }
        public int? FkProductId { get; set; }

        public virtual Order FkOrder { get; set; }
        public virtual Product FkProduct { get; set; }
    }
}
