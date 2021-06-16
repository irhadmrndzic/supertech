using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using superTech.Models.Product;
using superTech.Services.GenericCRUD;

namespace superTech.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseCRUDController<ProductModel, object, ProductUpsertRequest, ProductUpsertRequest>
    {
        public ProductsController(ICRUDService<ProductModel, object, ProductUpsertRequest, ProductUpsertRequest> IBaseService) : base(IBaseService)
        {
            
        }
    }
}