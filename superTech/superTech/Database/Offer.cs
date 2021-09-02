using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace superTech.Database
{
    public partial class Offer
    {
        public Offer()
        {
            ProductOffers = new HashSet<ProductOffer>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfferId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<ProductOffer> ProductOffers { get; set; }
    }
}
