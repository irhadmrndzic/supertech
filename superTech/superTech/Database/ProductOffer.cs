using System;
using System.Collections.Generic;

#nullable disable

namespace superTech.Database
{
    public partial class ProductOffer
    {
        public int ProductOfferId { get; set; }
        public decimal? Discount { get; set; }
        public decimal? PriceWithDiscount { get; set; }
        public int? FkProductId { get; set; }
        public int? FkOfferId { get; set; }

        public virtual Offer FkOffer { get; set; }
        public virtual Product FkProduct { get; set; }
    }
}
