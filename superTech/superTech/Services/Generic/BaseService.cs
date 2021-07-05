using AutoMapper;
using superTech.Database;
using System.Collections.Generic;
using System.Linq;

namespace superTech.Services.Generic
{
    public class BaseService<TModel,TSearchFilter,TDatabase> : IBaseService<TModel, TSearchFilter> where TDatabase:class
    {
        public readonly superTechRSContext _dbContext;
        public readonly IMapper _mapper;

        public  BaseService(superTechRSContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public virtual List<TModel> Get(TSearchFilter searchFilter)
        {
            var list = _dbContext.Set<TDatabase>().ToList();

            return _mapper.Map<List<TModel>>(list);
        }

        public virtual TModel GetById(int id)
        {
            var entity = _dbContext.Set<TDatabase>().Find(id);
            return _mapper.Map<TModel>(entity);
        }
    }
}
