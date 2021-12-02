
namespace superTech.Models.Offers.OfferItems
{
    public class OfferItemsModel
    {
        public int ProductOfferId { get; set; }
        public decimal? Discount { get; set; }
        public string DiscountString { get; set; }
        public decimal? PriceWithDiscount { get; set; }
        public string PriceWithDiscountString { get; set; }
        public decimal? PriceNoDiscount { get; set; }
        public string PriceNoDiscounString { get; set; }
        public int? FkProductId { get; set; }
        public int? FkOfferId { get; set; }
        public string ProductName { get; set; }
    }
}
