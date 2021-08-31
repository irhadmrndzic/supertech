using Microsoft.AspNetCore.Mvc;
using superTech.Models.Ratings;
using superTech.Services.GenericCRUD;

namespace superTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : BaseCRUDController<RatingsModel, RatingsSearchRequest, RatingsUpsertRequest, RatingsUpsertRequest>
    {
        public RatingsController(ICRUDService<RatingsModel, RatingsSearchRequest, RatingsUpsertRequest, RatingsUpsertRequest> IBaseService) : base(IBaseService)
        {

        }
    }
}
