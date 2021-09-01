using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using superTech.Models.Brands;
using superTech.Services.GenericCRUD;


namespace superTech.Controllers
{

    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseCRUDController<BrandsModel, BrandsSearchRequest, BrandsUpsertRequest, BrandsUpsertRequest>
    {
        public BrandsController(ICRUDService<BrandsModel, BrandsSearchRequest, BrandsUpsertRequest, BrandsUpsertRequest> IBaseService) : base(IBaseService)
        {

        }
    }
}
