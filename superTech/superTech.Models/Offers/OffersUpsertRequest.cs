using superTech.Models.Offers.OfferItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace superTech.Models.Offers
{
  public  class OffersUpsertRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool Active { get; set; }
        //public ICollection<OrderItemsUpsertRequest> OrderItems { get; set; }
        public ICollection<OfferItemsUpsertRequest> OfferItems { get; set; }

    }
}
