

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using superTech.Database;
using superTech.MachineLearning;
using superTech.Models.Product;
using superTech.Services.GenericCRUD;

namespace superTech.Services
{
    public class ProductsService : IProductsService
    {
        static MLContext mlContext = null;
        public static ITransformer model = null;
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

            if (searchFilter.BrandId.HasValue && searchFilter.BrandId > 0)
            {
                query = query.Where(x => x.BrandId == searchFilter.BrandId);
            }
            else if(searchFilter.BrandId.HasValue && searchFilter.BrandId > 0 && searchFilter.CategoryId.HasValue && searchFilter.CategoryId > 0)
            {
                query = query.Where(x => x.BrandId == searchFilter.BrandId && x.FkCategoryId == searchFilter.CategoryId);
            }
            else if (searchFilter.CategoryId.HasValue && searchFilter.CategoryId > 0)
            {
                query = query.Where(x=>x.FkCategoryId == searchFilter.CategoryId);
            }


            if ((string.IsNullOrWhiteSpace(searchFilter?.Name) && string.IsNullOrWhiteSpace(searchFilter?.Code)) && (searchFilter?.CategoryId.HasValue == true && searchFilter?.CategoryId != 0))
            {
                query = query.Where(x => x.FkCategoryId == searchFilter.CategoryId).Include(q => q.FkCategory).Include(q => q.FkCategory); 
            }

            if ((!string.IsNullOrWhiteSpace(searchFilter?.Name) && !string.IsNullOrWhiteSpace(searchFilter?.Code)) && (searchFilter?.CategoryId.HasValue == true && searchFilter?.CategoryId == 0))
            {
                query = query.Where(x => x.Name.ToLower().Contains(searchFilter.Name.ToLower()) && x.Code.ToLower().Contains(searchFilter.Code.ToLower())).Include(q => q.FkCategory); 
            }

            if((!string.IsNullOrWhiteSpace(searchFilter?.Name) && string.IsNullOrWhiteSpace(searchFilter?.Code)) && (searchFilter?.CategoryId.HasValue == true && searchFilter?.CategoryId == 0))
            {
                query = query.Where(x => x.Name.ToLower().Contains(searchFilter.Name.ToLower())).Include(q => q.FkCategory); 
            }

            if ((string.IsNullOrWhiteSpace(searchFilter?.Name) && !string.IsNullOrWhiteSpace(searchFilter?.Code)) && (searchFilter?.CategoryId.HasValue == true && searchFilter?.CategoryId == 0))
            {
                query = query.Where(x => x.Code.ToLower().Contains(searchFilter.Code.ToLower())).Include(q => q.FkCategory); 
            }

            if ((string.IsNullOrWhiteSpace(searchFilter?.Name) && string.IsNullOrWhiteSpace(searchFilter?.Code)) && (searchFilter?.CategoryId.HasValue == true && searchFilter?.CategoryId != 0))
            {
                query = query.Where(x => x.FkCategoryId == searchFilter.CategoryId).Include(q => q.FkCategory);
            }

            if ((!string.IsNullOrWhiteSpace(searchFilter?.Name) && !string.IsNullOrWhiteSpace(searchFilter?.Code)) && (searchFilter?.CategoryId.HasValue == true && searchFilter?.CategoryId != 0))
            {
                query = query.Where(x => x.FkCategoryId == searchFilter.CategoryId && x.Name.ToLower().Contains(searchFilter.Name.ToLower())
                && x.Code.ToLower().Contains(searchFilter.Code.ToLower())).Include(q => q.FkCategory);
            }

            if ((!string.IsNullOrWhiteSpace(searchFilter?.Name) && string.IsNullOrWhiteSpace(searchFilter?.Code)) && (searchFilter?.CategoryId.HasValue == true && searchFilter?.CategoryId != 0))
            {
                query = query.Where(x => x.FkCategoryId == searchFilter.CategoryId && x.Name.ToLower().Contains(searchFilter.Name.ToLower())).Include(q => q.FkCategory);
            }

            if ((string.IsNullOrWhiteSpace(searchFilter?.Name) && !string.IsNullOrWhiteSpace(searchFilter?.Code)) && (searchFilter?.CategoryId.HasValue == true && searchFilter?.CategoryId != 0))
            {
                query = query.Where(x => x.FkCategoryId == searchFilter.CategoryId && x.Code.ToLower().Contains(searchFilter.Code.ToLower())).Include(q => q.FkCategory);
            }


            query = query
                .Include(b=>b.Brand)
                .Include(q => q.FkCategory)
                .Include(x => x.FkUnitOfMeasure)
                .Include(r => r.Ratings)
                .Include(o=>o.OrderItems)
                .ThenInclude(f=>f.FkOrder)
                .Include(p=>p.BuyerOrderItems)
                .ThenInclude(l=>l.FkBuyerOrderNavigation);
            query.OrderBy(x => x.Name);



            var list = query.ToList();


            return _mapper.Map<List<ProductModel>>(list);
        }

        public ProductModel GetById(int id)
        {
            var query = _dbContext.Products.Where(x => x.ProductId == id)
                .Include(b => b.Brand)
                .Include(q => q.FkCategory)
                .Include(u => u.FkUnitOfMeasure)
                .Include(r => r.Ratings)
                .Include(o => o.OrderItems)
                .ThenInclude(f => f.FkOrder)
                .Include(p => p.BuyerOrderItems)
                .ThenInclude(l => l.FkBuyerOrderNavigation)
                .SingleOrDefault();

            return _mapper.Map<ProductModel>(query);
        }

        public ProductModel Insert(ProductUpsertRequest request)
        {
            var entity = _mapper.Map<Product>(request);

            _dbContext.Products.Add(entity);
            _dbContext.SaveChanges();

            entity.FkCategoryId = request.CategoryId;
            entity.FkUnitOfMeasureId = request.UnitOfMeasureId;
            entity.BrandId = request.BrandId;
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

        public void Delete(int id)
        {
            var entity = _dbContext.Products.Where(x => x.ProductId == id).Include(r => r.Ratings).Include(p => p.FkCategory).Include(u => u.FkUnitOfMeasure).FirstOrDefault();

            _dbContext.Products.Remove(entity);

            _dbContext.SaveChanges();

        }

        public List<ProductModel> Recommender(int id)
        {
            if(mlContext == null)
            {
                 mlContext = new MLContext();

                var tmpData = _dbContext.BuyerOrders.Include(x => x.BuyerOrderItems).ToList();

                var data = new List<ProductEntry>();

                foreach (var item in tmpData)
                {
                    if(item.BuyerOrderItems.Count > 1)
                    {
                        var distItemId = item.BuyerOrderItems.Select(q => q.FkProductId).ToList();
                        distItemId.ForEach(y =>
                        {
                            var relatedItem = item.BuyerOrderItems.Where(a => a.FkProductId != y).ToList();

                            relatedItem.ForEach(t =>
                            {
                                data.Add(new ProductEntry() { ProductID = (uint)y, CoPurchaseProductID = (uint)t.FkProductId });
                            });
                        });
                    }
                }

                var trainData = mlContext.Data.LoadFromEnumerable(data);
                MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
                options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
                options.LabelColumnName = "Label";
                options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                options.Alpha = 0.01;
                options.Lambda = 0.0001;

                var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

               model = est.Fit(trainData);
            }

            var allItems = _dbContext.Products.Where(x => x.ProductId != id).ToList();
            var predResult = new List<Tuple<Database.Product, float>>();

            foreach (var aItem in allItems)
            {
                var predictionengine = mlContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
                var prediction = predictionengine.Predict(
                                         new ProductEntry()
                                         {
                                             ProductID = (uint)id,

                                             CoPurchaseProductID = (uint)aItem.ProductId
                                         });
                predResult.Add(new Tuple<Product, float>(aItem, prediction.Score));
            }


            var probResult = predResult.OrderByDescending(x=>x.Item2).Select(x=>x.Item1).Take(3).ToList();
            return _mapper.Map<List<ProductModel>>(probResult);
        }
    }
}
