namespace superTech.Models.BuyerOrders.BuyerOrderItems
{
    public class BuyerOrderItemsModel
    {
        public int Quantity { get; set; }
        public decimal? Amount { get; set; }
        public string AmountString { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductPriceString { get; set; }
        public int? FkProductId { get; set; }
        public int? FkBuyerOrder { get; set; }
    }
}
