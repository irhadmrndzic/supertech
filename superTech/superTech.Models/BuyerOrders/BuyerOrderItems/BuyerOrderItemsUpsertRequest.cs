namespace superTech.Models.BuyerOrders.BuyerOrderItems
{
    public class BuyerOrderItemsUpsertRequest
    {
        public int? Quantity { get; set; }
        public int? FkProductId { get; set; }
        public int? BuyerOrderId { get; set; }
        public decimal? Amount { get; set; }

    }
}
