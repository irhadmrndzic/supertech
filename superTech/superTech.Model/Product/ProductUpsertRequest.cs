
namespace superTech.Model.Product
{
   public class ProductUpsertRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
    }
}
