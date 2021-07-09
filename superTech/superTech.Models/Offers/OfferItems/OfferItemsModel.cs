
namespace superTech.Models.Offers.OfferItems
{
    public class OfferItemsModel
    {
        public int ProductOfferId { get; set; }
        public decimal? Discount { get; set; }
        public decimal? PriceWithDiscount { get; set; }
        public int? FkProductId { get; set; }
        public int? FkOfferId { get; set; }
        public string ProductName { get; set; }
    }
}
