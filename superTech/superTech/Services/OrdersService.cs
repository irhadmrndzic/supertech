﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using superTech.Database;
using superTech.Models.Orders;
using superTech.Models.Orders.OrderItems;
using superTech.Services.GenericCRUD;
using System.Collections.Generic;
using System.Linq;

namespace superTech.Services
{
    public class OrdersService : BaseCRUDService<OrdersModel, OrdersSearchRequest, Order, OrdersUpsertRequest, OrdersUpsertRequest>, ICRUDService<OrdersModel, OrdersSearchRequest, OrdersUpsertRequest, OrdersUpsertRequest>
    {
        public OrdersService(superTechRSContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<OrdersModel> Get(OrdersSearchRequest searchFilter)
        {
            var query = _dbContext.Orders.AsQueryable();

            query = query.Include(o => o.FkUser).Include(a => a.FkSupplier).Include(x=>x.OrderItems).ThenInclude(p=>p.FkProduct);
            if (searchFilter.OrderNumber!=0 && searchFilter!=null)
            {
                query = query.Where(q => q.OrderNumber == searchFilter.OrderNumber);
            }

            var list = query.ToList();

            return _mapper.Map<List<OrdersModel>>(list);
        }


        public override OrdersModel Insert(OrdersUpsertRequest request)
        {
            Order entity = new Order();

            entity.OrderNumber = request.OrderNumber;
            entity.Date = request.Date;
            entity.Active = request.Active;
            entity.Amount = request.Amount;
            entity.FkUserId = request.UserId;
            entity.FkSupplierId = request.SupplierId;



            _dbContext.Orders.Add(entity);
            _dbContext.SaveChanges();

            foreach (var item in request.OrderItems)
            {
                OrderItem oi = new OrderItem
                {
                    Quantity = item.Quantity,
                    Amount = item.Amount,
                    FkOrderId = entity.OrderId,
                    FkProductId = item.FkProductId
                };

                entity.OrderItems.Add(oi);
                _dbContext.OrderItems.Add(oi);
            }
            _dbContext.SaveChanges();

            return _mapper.Map<OrdersModel>(entity);

        }

    }
}