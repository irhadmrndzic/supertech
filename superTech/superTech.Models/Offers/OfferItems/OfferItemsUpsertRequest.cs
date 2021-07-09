
namespace superTech.Models.Offers.OfferItems
{
    public class OfferItemsUpsertRequest
    {
        public decimal? Discount { get; set; }
        public decimal? PriceWithDiscount { get; set; }
        public int? FkProductId { get; set; }
        public int? FkOfferId { get; set; }

    }
}
