using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using superTech.Services.Generic;
using superTech.Services.GenericCRUD;

namespace superTech.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCRUDController<T,TSearch,TInsert,TUpdate> : BaseController<T,TSearch>
    {
        private readonly ICRUDService<T, TSearch, TInsert, TUpdate> _service;
        public BaseCRUDController(ICRUDService<T,TSearch,TInsert,TUpdate> service) : base(service)
        {
            _service = service;
        }


        [HttpPost]
        public T Insert(TInsert request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public T Update(int id,[FromBody]TUpdate request)
        {
            return _service.Update(id,request);
        }
    }
}