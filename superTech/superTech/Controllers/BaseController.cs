using Microsoft.AspNetCore.Mvc;
using superTech.Services.Generic;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace superTech.Controllers
{
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T,TSearchFilter>:ControllerBase
    {
        private readonly IBaseService<T, TSearchFilter> _service;

        public BaseController(IBaseService<T,TSearchFilter> service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<T>> Get([FromQuery]TSearchFilter searchFilter)
        {
            return _service.Get(searchFilter);
        }


        [HttpGet("{id}")]
        public ActionResult<T> GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
