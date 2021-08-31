using Microsoft.AspNetCore.Mvc;
using superTech.Models.Bills;
using superTech.Services.GenericCRUD;

namespace superTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : BaseCRUDController<BillsModel, BillsSearchRequest, BillsUpsertRequest, BillsUpsertRequest>
    {
        public BillsController(ICRUDService<BillsModel, BillsSearchRequest, BillsUpsertRequest, BillsUpsertRequest> IBaseService) : base(IBaseService)
        {

        }
    }
}
