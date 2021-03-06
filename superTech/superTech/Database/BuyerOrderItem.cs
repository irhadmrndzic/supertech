using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace superTech.Database
{
    public partial class BuyerOrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuyerOrderItemsId { get; set; }
        public int? Quantity { get; set; }
        public int? FkProductId { get; set; }
        public int? FkBuyerOrder { get; set; }
        public decimal? Amount { get; set; }

        public virtual BuyerOrder FkBuyerOrderNavigation { get; set; }
        public virtual Product FkProduct { get; set; }
    }
}
