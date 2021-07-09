using AutoMapper;
using superTech.Database;
using superTech.Services.Generic;

namespace superTech.Services.GenericCRUD
{
    public class BaseCRUDService<TModel, TSearch, TDatabase, TInsert, TUpdate> : BaseService<TModel, TSearch, TDatabase>, ICRUDService<TModel, TSearch, TInsert, TUpdate>where TDatabase :class

    {

        public BaseCRUDService(superTechRSContext context, IMapper mapper):base(context,mapper)
        {
            
        }

   

        public virtual TModel Insert(TInsert request)
        {
            var entity = _mapper.Map<TDatabase>(request);

            _dbContext.Set<TDatabase>().Add(entity);
            _dbContext.SaveChanges();

            return _mapper.Map<TModel>(entity);

        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var entity = _dbContext.Set<TDatabase>().Find(id);
            _mapper.Map(request, entity);
            _dbContext.Set<TDatabase>().Attach(entity);
            _dbContext.Set<TDatabase>().Update(entity);
            _dbContext.SaveChanges();

            return _mapper.Map<TModel>(entity);

        }

        public virtual void Delete(int id)
        {
            var entity = _dbContext.Set<TDatabase>().Find(id);
            _dbContext.Set<TDatabase>().Remove(entity);
            _dbContext.SaveChanges();


        }
    }
}
