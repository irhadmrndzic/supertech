using AutoMapper;
using Microsoft.EntityFrameworkCore;
using superTech.Database;
using superTech.Models.BuyerOrders;
using superTech.Services.GenericCRUD;
using System.Collections.Generic;
using System.Linq;

namespace superTech.Services
{
    public class BuyerOrderService : BaseCRUDService<BuyerOrdersModel, BuyerOrdersSearchRequest, BuyerOrder, BuyerOrdersUpsertRequest, BuyerOrdersUpsertRequest>, ICRUDService<BuyerOrdersModel, BuyerOrdersSearchRequest, BuyerOrdersUpsertRequest, BuyerOrdersUpsertRequest>
    {

        public BuyerOrderService(superTechRSContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<BuyerOrdersModel> Get(BuyerOrdersSearchRequest searchFilter)
        {
            var query = _dbContext.BuyerOrders.Include(x => x.FkUser).AsQueryable();
            query = query.Include(x => x.FkUser).Include(q => q.BuyerOrderItems).ThenInclude(p => p.FkProduct).ThenInclude(o => o.ProductOffers).ThenInclude(p => p.FkOffer); ;

            if (searchFilter.Status == "Procesirana")
            {
                query = query.Where(x => x.Active == false);
            }
            else if (searchFilter.Status == "Neprocesirana")
            {
                query = query.Where(x => x.Active == true);

            }

            var list = query.ToList().OrderBy(x => x.Active ? 0 : 1).ThenBy(q => q.Date);

            return _mapper.Map<List<BuyerOrdersModel>>(list);

        }

        public override BuyerOrdersModel GetById(int id)
        {
            var query = _dbContext.BuyerOrders.Where(x => x.BuyerOrderId == id);

            query = query.Include(x => x.FkUser).Include(q => q.BuyerOrderItems).ThenInclude(p => p.FkProduct).ThenInclude(o => o.ProductOffers).ThenInclude(p => p.FkOffer);

            var entity = query.SingleOrDefault();

            return _mapper.Map<BuyerOrdersModel>(entity);
        }

        public override BuyerOrdersModel Update(int id, BuyerOrdersUpsertRequest request)
        {
            var entity = _dbContext.BuyerOrders.Where(x => x.BuyerOrderId == id)
                .Include(x => x.BuyerOrderItems)
                .ThenInclude(x => x.FkProduct).ThenInclude(x => x.ProductOffers)
                .ThenInclude(o => o.FkOffer)
                .SingleOrDefault();
            var count = _dbContext.Bills.Count();
            _dbContext.BuyerOrders.Attach(entity);
            _dbContext.BuyerOrders.Update(entity);


            if (request.Confirmed)
            {

                entity.Confirmed = true;
                entity.Active = false;
                entity.Canceled = false;

                Bill bill = new Bill();

                bill.Tax = 17;
                bill.FkUserId = entity.FkUserId;
                bill.BillNumber = count + 1;
                bill.Closed = false;
                bill.FkBuyerOrder = entity.BuyerOrderId;
                bill.IssuingDate = System.DateTime.Now;

                _dbContext.Bills.Add(bill);
                _dbContext.SaveChanges();


                foreach (var buyerItem in entity.BuyerOrderItems)
                {
                    BillItem billItem = new BillItem();

                    billItem.Quantity = (int)buyerItem.Quantity;
                    billItem.FkBillId = bill.BillId;
                    billItem.FkProductId = buyerItem.FkProductId;
                    billItem.Price = (decimal)(buyerItem.FkProduct.ProductOffers.Where(x => x.FkProductId == billItem.FkProductId && x.FkOffer.Active == true).Count() > 0 ?
                     buyerItem.FkProduct.ProductOffers.Where(x => x.FkProductId == billItem.FkProductId && x.FkOffer.Active == true).Select(q => q.PriceWithDiscount).FirstOrDefault() : buyerItem.FkProduct.Price);


                    billItem.Discount = (decimal)(buyerItem.FkProduct.ProductOffers.Where(x => x.FkProductId == billItem.FkProductId && x.FkOffer.Active == true).Count() > 0 ?
                     buyerItem.FkProduct.ProductOffers.Where(x => x.FkProductId == billItem.FkProductId && x.FkOffer.Active == true).Select(q => q.Discount).FirstOrDefault() : 0);

                    bill.BillItems.Add(billItem);
                    _dbContext.BillItems.Add(billItem);
                }

                foreach (var item in bill.BillItems)
                {
                    bill.Amount += (item.Price * item.Quantity);
                }

                bill.AmountWithTax = bill.Amount + (bill.Amount * (decimal)0.17);

                _dbContext.SaveChanges();

            }
            else if (request.Canceled)
            {
                entity.Canceled = true;
                entity.Confirmed = false;
                entity.Active = false;
            }
            else
            {
                entity.Active = true;
                entity.Confirmed = false;
                entity.Canceled = false;
            }

            _dbContext.SaveChanges();

            return _mapper.Map<BuyerOrdersModel>(entity);
        }

    }

}


