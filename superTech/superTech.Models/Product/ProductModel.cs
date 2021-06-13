
namespace superTech.Models.Product
{
   public class ProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }

        //public ICollection<ProductsCategories> KorisniciUloge { get; set; }
    }
}
