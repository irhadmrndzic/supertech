using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace superTech.Database
{
    public partial class ProductOffer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductOfferId { get; set; }
        public decimal? Discount { get; set; }
        public decimal? PriceWithDiscount { get; set; }
        public int? FkProductId { get; set; }
        public int? FkOfferId { get; set; }

        public virtual Offer FkOffer { get; set; }
        public virtual Product FkProduct { get; set; }
    }
}
