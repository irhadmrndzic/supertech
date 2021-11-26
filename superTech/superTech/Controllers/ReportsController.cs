using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using superTech.Models.ReportsModel;
using superTech.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace superTech.Controllers
{
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        public IReports _reportsService;
        public ReportsController(IReports reports)
        {
            _reportsService = reports;
        }

        [Authorize(Roles = "Administrator,Kupac,Dostavljac")]
        [HttpGet]
        public ReportsModel Get([FromQuery]ReportsSearchRequest request)
        {
            return _reportsService.GetReports(request);
        }
    }
}
