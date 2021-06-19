using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using superTech.Models.Category;
using superTech.Models.Roles;
using superTech.Services.GenericCRUD;

namespace superTech.Controllers
{
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseCRUDController<RolesModel, object, RolesModel, RolesModel>
    {
        public RolesController(ICRUDService<RolesModel, object, RolesModel, RolesModel> IBaseService) : base(IBaseService)
        {

        }
    }
}