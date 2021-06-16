using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using superTech.Models.City;
using superTech.Services.GenericCRUD;

namespace superTech.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : BaseCRUDController<CityModel, object, CityUpsertRequest, CityUpsertRequest>
    {
        public CitiesController(ICRUDService<CityModel, object, CityUpsertRequest, CityUpsertRequest> IBaseService) : base(IBaseService)
        {

        }
    }
}