

using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using superTech.Database;
using superTech.Models.Product;
using superTech.Services.GenericCRUD;

namespace superTech.Services
{
    public class ProductsService : IProductsService
    {

        private readonly superTechRSContext _dbContext;
        private readonly IMapper _mapper;
        public ProductsService(superTechRSContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public List<ProductModel> Get(ProductsSearchRequest searchFilter)
        {
            var query = _dbContext.Products.AsQueryable();

            if (searchFilter?.CategoryId.HasValue == true && searchFilter?.CategoryId != 0)
            {
                query = query.Where(x => x.FkCategoryId == searchFilter.CategoryId).Include(q => q.FkCategory);
            }
            query.OrderBy(x => x.Name);
            query = query.Include(q => q.FkCategory).Include(x => x.FkUnitOfMeasure).Include(r => r.Ratings);
            var list = query.ToList();

            return _mapper.Map<List<ProductModel>>(list);
        }

        public ProductModel GetById(int id)
        {
            var query = _dbContext.Products.Where(x => x.ProductId == id).Include(q => q.FkCategory).Include(u => u.FkUnitOfMeasure).Include(r => r.Ratings).SingleOrDefault();

            return _mapper.Map<ProductModel>(query);
        }

        public ProductModel Insert(ProductUpsertRequest request)
        {
            var entity = _mapper.Map<Product>(request);

            _dbContext.Products.Add(entity);
            _dbContext.SaveChanges();

            entity.FkCategoryId = request.CategoryId;
            entity.FkUnitOfMeasureId = request.UnitOfMeasureId;

            _dbContext.SaveChanges();

            return _mapper.Map<ProductModel>(entity);

        }

        public ProductModel Update(int id, ProductUpsertRequest request)
        {

            var entity = _dbContext.Products.Find(id);

            _dbContext.Products.Attach(entity);
            entity.FkCategoryId = request.CategoryId;
            entity.FkUnitOfMeasureId = request.UnitOfMeasureId;
            _dbContext.Update(entity);


            _mapper.Map(request, entity);

            _dbContext.SaveChanges();


            var query = _dbContext.Products.Where(x => x.ProductId == entity.ProductId).Include(q => q.Ratings)
             .Include(r => r.FkCategory).Include(c => c.FkUnitOfMeasure).SingleOrDefault();

            return _mapper.Map<ProductModel>(query);
        }
    }
}
