using Microsoft.AspNetCore.Mvc;
using superTech.Models.Bills;
using superTech.Services.GenericCRUD;

namespace superTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : BaseCRUDController<BillsModel, object, object, object>
    {
        public BillsController(ICRUDService<BillsModel, object, object, object> IBaseService) : base(IBaseService)
        {

        }
    }
}
