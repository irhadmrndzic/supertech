using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using superTech.Models.Product;
using superTech.Services;
using superTech.Services.GenericCRUD;
using System.Collections.Generic;

namespace superTech.Controllers
{
    //[Authorize(AuthenticationSchemes = "BasicAuthentication")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }


        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public List<ProductModel> Get([FromQuery]ProductUpsertRequest searchFilter)
        {
            return _productsService.Get(searchFilter);
        }
    }
}