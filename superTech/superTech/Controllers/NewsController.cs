﻿using Microsoft.AspNetCore.Mvc;
using superTech.Models.News;
using superTech.Services.GenericCRUD;

namespace superTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NewsController : BaseCRUDController<NewsModel, NewsSearchRequest, NewsUpsertRequest, NewsUpsertRequest>
    {
        public NewsController(ICRUDService<NewsModel, NewsSearchRequest, NewsUpsertRequest, NewsUpsertRequest> IBaseService) : base(IBaseService)
        {

        }
    }
}