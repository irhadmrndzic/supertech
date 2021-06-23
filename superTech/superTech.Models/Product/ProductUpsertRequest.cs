
namespace superTech.Models.Product
{
   public class ProductUpsertRequest
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public byte[] Image { get; set; }
        public int CategoryId { get; set; }
        public int UnitOfMeasureId { get; set; }


    }
}
