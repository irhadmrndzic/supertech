

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using superTech.Models.UnitsOfMeasures;
using superTech.Services.GenericCRUD;

namespace superTech.Controllers
{

    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsOfMeasuresController : BaseCRUDController<UnitsOfMeasuresModel,object,UnitsOfMeasuresUpsertRequest,UnitsOfMeasuresUpsertRequest>
    {
        public UnitsOfMeasuresController(ICRUDService<UnitsOfMeasuresModel, object, UnitsOfMeasuresUpsertRequest, UnitsOfMeasuresUpsertRequest> IBaseService) : base(IBaseService)
        {

        }
    }
}