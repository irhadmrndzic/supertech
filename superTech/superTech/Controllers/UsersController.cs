using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using superTech.Models.User;
using superTech.Services;
using System.Collections.Generic;

namespace superTech.Controllers
{
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _service;
        public UsersController(IUsersService service) 
        {
            _service = service;
        }

        [Authorize(Roles = "Administrator,Kupac,Serviser,Dostavljac")]
        [HttpGet]
        public List<UserModel> Get([FromQuery]UserSearchRequest searchFilter)
        {
            return _service.Get(searchFilter);
        }

        [Authorize(Roles = "Administrator,Kupac,Serviser,Dostavljac")]
        [HttpGet("{id}")]
        public UserModel GetById(int id)
        {
            return _service.GetById(id);
        }

        [Authorize(Roles = "Administrator,Kupac,Serviser,Dostavljac")]
        [AllowAnonymous]
        [HttpPost]
        public UserModel Insert(UserUpsertRequest request)
        {
            return _service.Insert(request);
        }


        [Authorize(Roles = "Administrator,Kupac,Serviser,Dostavljac")]
        [AllowAnonymous]
        [HttpPut("{id}")]
        public UserModel Update(int id, [FromBody]UserUpsertRequest request)
        {
            return _service.Update(id, request);
        }



    }
}