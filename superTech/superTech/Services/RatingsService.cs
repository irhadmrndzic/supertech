using AutoMapper;
using superTech.Database;
using superTech.Models.Ratings;
using superTech.Services.GenericCRUD;
using System;
using System.Collections.Generic;
using System.Linq;

namespace superTech.Services
{
    public class RatingsService : BaseCRUDService<RatingsModel, RatingsSearchRequest, Rating, RatingsUpsertRequest, RatingsUpsertRequest>, ICRUDService<RatingsModel, RatingsSearchRequest, RatingsUpsertRequest, RatingsUpsertRequest>
    {

        public RatingsService(superTechRSContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override List<RatingsModel> Get(RatingsSearchRequest searchFilter)
        {
            var query = _dbContext.Ratings.Where(x => x.FkProductId == searchFilter.ProductId && x.FkUserId == searchFilter.UserId);

            var list = query.ToList();

            return _mapper.Map<List<RatingsModel>>(list);
        }

        public override RatingsModel Insert(RatingsUpsertRequest request)
        {
            var entity = _dbContext.Products.Where(x => x.ProductId == request.FkProductId).SingleOrDefault();

            Rating rating = new Rating
            {
                FkProductId = entity.ProductId,
                Rating1 = request.Rating1,
                Date = DateTime.Now,
                FkUserId = request.FkUserId
            };

            _dbContext.Ratings.Add(rating);
            _dbContext.SaveChanges();

            return _mapper.Map<RatingsModel>(rating);
        }
    }
}
