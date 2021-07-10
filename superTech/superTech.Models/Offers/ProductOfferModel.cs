
namespace superTech.Models.Offers
{
    public class ProductOfferModel
    {
        public int  ProductId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public decimal? PriceWithDiscount { get; set; }
    }
}
