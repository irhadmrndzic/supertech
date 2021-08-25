namespace superTech.Models.Bills.BillItems
{
    public class BillItemsModel
    {
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public int Quantity { get; set; }
        public int? FkBillId { get; set; }
        public int? FkProductId { get; set; }
        public string ProductString { get; set; }

    }
}
