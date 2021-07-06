
using Microsoft.AspNetCore.Mvc;
using superTech.Models.Orders;
using superTech.Services.GenericCRUD;

namespace superTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseCRUDController<OrdersModel, OrdersSearchRequest, OrdersUpsertRequest, OrdersUpsertRequest>
    {
        public OrdersController(ICRUDService<OrdersModel, OrdersSearchRequest, OrdersUpsertRequest, OrdersUpsertRequest> IBaseService) : base(IBaseService)
        {

        }
    }
}