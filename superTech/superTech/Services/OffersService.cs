using AutoMapper;
using Microsoft.EntityFrameworkCore;
using superTech.Database;
using superTech.Models.Offers;
using superTech.Services.GenericCRUD;
using System.Collections.Generic;
using System.Linq;

namespace superTech.Services
{
    public class OffersService : BaseCRUDService<OffersModel, OffersSearchRequest, Offer, OffersUpsertRequest, OffersUpsertRequest>, ICRUDService<OffersModel, OffersSearchRequest, OffersUpsertRequest, OffersUpsertRequest>
    {
        public OffersService(superTechRSContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override List<OffersModel> Get(OffersSearchRequest searchFilter)
        {

            var query = _dbContext.Offers.AsQueryable();

            query = query.Include(x => x.ProductOffers).ThenInclude(p => p.FkProduct);

            if (searchFilter?.DateFrom != null && (searchFilter?.DateFrom.ToString() != "1.1.0001. 00:00:00" && searchFilter?.DateFrom.ToString() != "1.1.0001. 01:00:00")
                && (searchFilter?.DateTo != null && (searchFilter?.DateTo.ToString() != "1.1.0001. 00:00:00" && searchFilter?.DateTo.ToString() != "1.1.0001. 01:00:00")))
            {
                query = query.Where(x => x.DateFrom >= searchFilter.DateFrom && x.DateTo <= searchFilter.DateTo);

            }

            var list = query.ToList();

            return _mapper.Map<List<OffersModel>>(list);

        }


        public override OffersModel GetById(int id)
        {
            var query = _dbContext.Offers.Where(x => x.OfferId == id);

            query = query.Include(x => x.ProductOffers).ThenInclude(q => q.FkProduct);

            var entity = query.SingleOrDefault();

            return _mapper.Map<OffersModel>(entity);

        }
        public override OffersModel Update(int id, OffersUpsertRequest request)
        {
            var entity = _dbContext.Offers.Where(x => x.OfferId == id).Include(q => q.ProductOffers).ThenInclude(w => w.FkProduct).SingleOrDefault();

            _dbContext.Update(entity);
            _dbContext.Attach(entity);

            entity.DateFrom = request.DateFrom;
            entity.DateTo = request.DateTo;
            entity.Title = request.Title;
            entity.Description = request.Description;

            entity.Active = request.Active;

            if (request.DateTo < System.DateTime.Today)
            {
                entity.Active = false;
            }

            _dbContext.SaveChanges();
            if (request.OfferItems != null &&  request.OfferItems.Count > 0)
            {
                _mapper.Map(request.OfferItems, entity.ProductOffers);
            }
            _dbContext.SaveChanges();

            return _mapper.Map<OffersModel>(entity);

        }




        public override void Delete(int id)
        {
            var query = _dbContext.Offers.Where(x => x.OfferId == id).Include(p => p.ProductOffers).ThenInclude(q => q.FkProduct).SingleOrDefault();

            foreach (var item in query.ProductOffers)
            {
                _dbContext.ProductOffers.Remove(item);
            }
            _dbContext.SaveChanges();

            _dbContext.Offers.Remove(query);
            _dbContext.SaveChanges();

        }

        public override OffersModel Insert(OffersUpsertRequest request)
        {

            Offer offer = new Offer();
            offer.Title = request.Title;
            offer.Description = request.Description;
            offer.DateFrom = request.DateFrom;
            offer.DateTo = request.DateTo;
            offer.Active = request.Active;

            if (request.DateTo < System.DateTime.Today)
            {
                offer.Active = false;
            }

            _dbContext.Offers.Add(offer);
            _dbContext.SaveChanges();

            foreach (var item in request.OfferItems)
            {
                ProductOffer oi = new ProductOffer
                {
                    Discount = item.Discount,
                    PriceWithDiscount = item.PriceWithDiscount,
                    FkProductId = item.FkProductId,
                    FkOfferId = offer.OfferId
                };

                offer.ProductOffers.Add(oi);
                _dbContext.ProductOffers.Add(oi);
            }
            _dbContext.SaveChanges();

            return _mapper.Map<OffersModel>(offer);

        }

    }
}

