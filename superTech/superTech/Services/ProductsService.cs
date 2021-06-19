

using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using superTech.Database;
using superTech.Models.Product;
using superTech.Services.GenericCRUD;

namespace superTech.Services
{
    public class ProductsService:IProductsService
    {

        private readonly superTechRSContext _dbContext;
        private readonly IMapper _mapper;
        public ProductsService(superTechRSContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public List<ProductModel> Get(ProductUpsertRequest searchFilter)
        {
            var query = _dbContext.Products.AsQueryable();
            query = query.Include(q => q.FkCategory).Include(x => x.FkUnitOfMeasure);
            var list = query.ToList();

            return _mapper.Map<List<ProductModel>>(list);
        }

        public ProductModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ProductModel Insert(ProductUpsertRequest request)
        {
            throw new System.NotImplementedException();
        }

        public ProductModel Update(int id, ProductUpsertRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
