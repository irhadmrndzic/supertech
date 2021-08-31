using AutoMapper;
using Microsoft.EntityFrameworkCore;
using superTech.Database;
using superTech.Models.Bills;
using superTech.Services.GenericCRUD;
using System.Collections.Generic;
using System.Linq;

namespace superTech.Services
{
    public class BillsService : BaseCRUDService<BillsModel, BillsSearchRequest, Bill, BillsUpsertRequest, BillsUpsertRequest>, ICRUDService<BillsModel, BillsSearchRequest, BillsUpsertRequest, BillsUpsertRequest>
    {
        public BillsService(superTechRSContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<BillsModel> Get(BillsSearchRequest searchFilter)
        {


            var query = _dbContext.Bills.AsQueryable();

            query = query.Include(q => q.BillItems).ThenInclude(a => a.FkProduct).ThenInclude(s => s.BuyerOrderItems).ThenInclude(y => y.FkBuyerOrderNavigation)
                .ThenInclude(d => d.FkUser);

            if (!string.IsNullOrWhiteSpace(searchFilter.Username))
            {
                query = query.Where(x => x.FkUser.UserName == searchFilter.Username);
            }

            var list = query.ToList();

            return _mapper.Map<List<BillsModel>>(list);
        }


        public override BillsModel GetById(int id)
        {
            var entity = _dbContext.Bills.Where(x => x.BillId == id).
                Include(q => q.BillItems).ThenInclude(a => a.FkProduct)
                .ThenInclude(s => s.BuyerOrderItems)
                .ThenInclude(y => y.FkBuyerOrderNavigation)
                .ThenInclude(d => d.FkUser)
                .SingleOrDefault();

            return _mapper.Map<BillsModel>(entity);
        }

        public override BillsModel Update(int id, BillsUpsertRequest request)
        {
            var entity = _dbContext.Bills.Where(x => x.BillId == id).
             Include(q => q.BillItems).ThenInclude(a => a.FkProduct)
             .ThenInclude(s => s.BuyerOrderItems)
             .ThenInclude(y => y.FkBuyerOrderNavigation)
             .ThenInclude(d => d.FkUser)
             .SingleOrDefault();

            entity.Closed = request.Closed;
            _dbContext.Update(entity);

            _mapper.Map(request, entity);
            _dbContext.SaveChanges();


            return _mapper.Map<BillsModel>(entity);

        }
    }
}
