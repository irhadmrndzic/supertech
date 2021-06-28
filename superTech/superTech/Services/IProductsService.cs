using superTech.Models.Product;
using System.Collections.Generic;


namespace superTech.Services
{
   public interface IProductsService
    {
        public List<ProductModel> Get(ProductsSearchRequest searchFilter);
        public ProductModel GetById(int id);
        public ProductModel Insert(ProductUpsertRequest request);
        public ProductModel Update(int id, ProductUpsertRequest request);
        public void Delete(int id);

    }
}
