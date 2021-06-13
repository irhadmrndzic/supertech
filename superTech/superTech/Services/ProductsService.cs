

using System.Collections.Generic;
using AutoMapper;
using superTech.Database;
using superTech.Models.Product;
using superTech.Services.GenericCRUD;

namespace superTech.Services
{
    public class ProductsService:BaseCRUDService<ProductModel,object,Product,ProductUpsertRequest,ProductUpsertRequest>
    {
        public ProductsService(superTechRSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<ProductModel> Get(object searchFilter) //Napraiviti proizvodi search request sa vrsta id 
        {
            return base.Get(searchFilter);
        }
    }
}
