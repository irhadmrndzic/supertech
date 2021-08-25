
using Microsoft.AspNetCore.Mvc;
using superTech.Models.BuyerOrders;
using superTech.Services.GenericCRUD;


namespace superTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerOrdersController : BaseCRUDController<BuyerOrdersModel, BuyerOrdersSearchRequest, BuyerOrdersUpsertRequest, BuyerOrdersUpsertRequest>
    {
        public BuyerOrdersController(ICRUDService<BuyerOrdersModel, BuyerOrdersSearchRequest, BuyerOrdersUpsertRequest, BuyerOrdersUpsertRequest> IBaseService):base(IBaseService)
        {

        }
    }
}
