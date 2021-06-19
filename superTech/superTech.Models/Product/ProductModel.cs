
namespace superTech.Models.Product
{
   public class ProductModel
    {
        //public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }

        //public byte[] Image { get; set; }
        //public byte[] ImageThumb { get; set; }
        public string FkUnitOfMeasureString { get; set; }
        public string CategoryString { get; set; }

        //public ICollection<ProductsCategories> ProductsCategories { get; set; }
    }
}
