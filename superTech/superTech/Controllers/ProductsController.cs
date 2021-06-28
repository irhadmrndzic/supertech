using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using superTech.Models.Product;
using superTech.Services;
using System.Collections.Generic;

namespace superTech.Controllers
{
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
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
        public List<ProductModel> Get([FromQuery]ProductsSearchRequest searchFilter)
        {
            return _productsService.Get(searchFilter);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ProductModel GetById(int id)
        {
            return _productsService.GetById(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ProductModel Insert(ProductUpsertRequest request)
        {
            return _productsService.Insert(request);
        }



        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ProductModel Update(int id, [FromBody]ProductUpsertRequest request)
        {
            return _productsService.Update(id, request);
        }


        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
             _productsService.Delete(id);
        }

    }
}