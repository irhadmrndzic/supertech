using Microsoft.AspNetCore.Mvc;
using superTech.Models.News;
using superTech.Services.GenericCRUD;

namespace superTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NewsController : BaseCRUDController<NewsModel, NewsSearchRequest, NewsModel, NewsModel>
    {
        public NewsController(ICRUDService<NewsModel, NewsSearchRequest, NewsModel, NewsModel> IBaseService) : base(IBaseService)
        {

        }
    }
}