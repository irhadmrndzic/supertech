using Microsoft.AspNetCore.Mvc;
using superTech.Models.Suppliers;
using superTech.Services.GenericCRUD;

namespace superTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SuppliersController : BaseCRUDController<SuppliersModel, SuppliersSearchRequest, SuppliersModel, SuppliersModel>
    {
        public SuppliersController(ICRUDService<SuppliersModel, SuppliersSearchRequest, SuppliersModel, SuppliersModel> IBaseService) : base(IBaseService)
        {

        }
    }
}