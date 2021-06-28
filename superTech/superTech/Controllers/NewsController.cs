using Microsoft.AspNetCore.Mvc;
using superTech.Models.News;
using superTech.Services.GenericCRUD;

namespace superTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NewsController : BaseCRUDController<NewsModel, object, NewsModel, NewsModel>
    {
        public NewsController(ICRUDService<NewsModel, object, NewsModel, NewsModel> IBaseService) : base(IBaseService)
        {

        }
    }
}