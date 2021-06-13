using System;
using System.Collections.Generic;

#nullable disable

namespace superTech.Database
{
    public partial class Offer
    {
        public Offer()
        {
            ProductOffers = new HashSet<ProductOffer>();
        }

        public int OfferId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual ICollection<ProductOffer> ProductOffers { get; set; }
    }
}
