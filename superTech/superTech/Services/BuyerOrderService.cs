using AutoMapper;
using Microsoft.EntityFrameworkCore;
using superTech.Database;
using superTech.Models.BuyerOrders;
using superTech.Services.GenericCRUD;
using System.Collections.Generic;
using System.Linq;

namespace superTech.Services
{
    public class BuyerOrderService : BaseCRUDService<BuyerOrdersModel, object, BuyerOrder, object, object>, ICRUDService<BuyerOrdersModel, object, object, object>
    {
        public BuyerOrderService(superTechRSContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<BuyerOrdersModel> Get(object searchFilter)
        {
            var query = _dbContext.BuyerOrders.Include(x => x.FkUser).AsQueryable();

            var list = query.ToList().OrderBy(x => x.Active ? 1 : 0);

            return _mapper.Map<List<BuyerOrdersModel>>(list);

        }

        public override BuyerOrdersModel GetById(int id)
        {
            var query = _dbContext.BuyerOrders.Where(x => x.BuyerOrderId == id);

            query = query.Include(o => o.FkUser).AsQueryable();

            var entity = query.SingleOrDefault();

            return _mapper.Map<BuyerOrdersModel>(entity);
        }

    }

}


