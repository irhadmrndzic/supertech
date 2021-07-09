using superTech.Models.Offers.OfferItems;
using System;
using System.Collections.Generic;

namespace superTech.Models.Offers
{
    public class OffersModel
    {
        public int OfferId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public virtual ICollection<OfferItemsModel> OfferItems { get; set; }
    }
}
