
using Microsoft.AspNetCore.Mvc;
using superTech.Models.BuyerOrders;
using superTech.Services.GenericCRUD;


namespace superTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerOrdersController : BaseCRUDController<BuyerOrdersModel, object, object, object>
    {
        public BuyerOrdersController(ICRUDService<BuyerOrdersModel, object, object, object> IBaseService):base(IBaseService)
        {

        }
    }
}
