using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using superTech.Models.Offers;
using superTech.Services.GenericCRUD;

namespace superTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : BaseCRUDController<OffersModel, OffersSearchRequest, OffersUpsertRequest, OffersUpsertRequest>
    {
        public OffersController(ICRUDService<OffersModel, OffersSearchRequest, OffersUpsertRequest, OffersUpsertRequest> IBaseService) : base(IBaseService)
        {

        }
    }
}