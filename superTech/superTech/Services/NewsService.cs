
using AutoMapper;
using superTech.Database;
using superTech.Models.News;
using superTech.Services.Generic;
using superTech.Services.GenericCRUD;
using System;
using System.Collections.Generic;
using System.Linq;

namespace superTech.Services
{
    public class NewsService : BaseCRUDService<NewsModel, NewsSearchRequest, News, NewsModel, NewsModel>, ICRUDService<NewsModel, NewsSearchRequest, NewsModel, NewsModel>
    {
        public NewsService(superTechRSContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<NewsModel> Get(NewsSearchRequest searchFilter)
        {
            var query = _dbContext.News.AsQueryable();
            if (searchFilter?.DateOfCreation != null && searchFilter?.DateOfCreation.ToString() != "1.1.0001. 00:00:00")
            {
                var date = searchFilter.DateOfCreation.Date;

                query = query.Where(x => x.DateOfCreation.Date == date);

                query = query.OrderBy(x => x.DateOfCreation);

            }

            query.OrderBy(x => x.DateOfCreation);
            var list = query.ToList();
            return _mapper.Map<List<NewsModel>>(list);

        }
    }
}
