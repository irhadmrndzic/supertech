using AutoMapper;
using Microsoft.EntityFrameworkCore;
using superTech.Database;
using superTech.Models.BuyerOrders.BuyerOrderItems;
using superTech.Models.ReportsModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace superTech.Services
{
    public class ReportsService : IReports
    {
        private readonly superTechRSContext _dbContext;
        private readonly IMapper _mapper;

        public ReportsService(superTechRSContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }




        public ReportsModel GetReports(ReportsSearchRequest request)
        {
            ReportsModel report = new ReportsModel();

            int employeesCount = _dbContext.UsersRoles.Where(q => q.FkRole.Name == "Administrator" || q.FkRole.Name == "Dostavljac").Include(x => x.FkRole).Count();
            report.EmployeesCount = employeesCount;

            int buyersCount = _dbContext.UsersRoles.Where(q => q.FkRole.Name == "Kupac").Count();
            report.BuyersCount = buyersCount;

            int allProductsCount = _dbContext.Products.Count();
            report.AllProductCount = allProductsCount;

            int buyerOrdersCount = _dbContext.BuyerOrders.Where(q=>q.Active == false).Count();
            report.BuyerOrdersCount = buyerOrdersCount;

            decimal buyerBillsSum = _dbContext.Bills.Sum(q => q.AmountWithTax);
            report.BuyerBillsSum = buyerBillsSum.ToString() + " KM";

            int ordersCount = _dbContext.Orders.Count();
            report.OrdersCount = ordersCount;


            //List<int> test = _dbContext.Bills.Where(q => q.Closed == true).Select(a => a.BillItems.Sum(g => g.Quantity)).ToList();


            int productsSold = (int)_dbContext.BuyerOrderItems.Sum(q=>q.Quantity);
            report.ProductsSold = productsSold;

            TopSoldProducts products = new TopSoldProducts();


            IQueryable<TopSoldProducts> result = _dbContext.BillItems.GroupBy(o => o.FkProduct.Name)
                  .Select(g => new TopSoldProducts { Name = g.Key, Quantity = g.Sum(i => i.Quantity) }).OrderByDescending(x => x.Quantity).Take(5);

            report.TopSoldProducts = (List<TopSoldProducts>)result.Select(s => new TopSoldProducts { Name = s.Name, Quantity = s.Quantity}).ToList();

            var bills = _dbContext.Bills.ToList();
  

            var prods = _dbContext.Products.ToList();
            foreach (var a in prods)
            {
                foreach (var item in report.TopSoldProducts)
                {
                    if(a.Name == item.Name)
                    {
                        item.TaxPrice += Math.Round((decimal)((item.Quantity * a.Price * (decimal)0.17) + (item.Quantity * a.Price)), 2);
                        item.Price += Math.Round((decimal)(item.Quantity * a.Price), 2);

                        item.TaxPriceString = item.TaxPrice.ToString() + " KM ";
                        item.PriceString = item.Price.ToString() + " KM ";
                    }
                }
            }


            IQueryable<ReportsMonthyBuyerOrdersModel> ordersByMonth = _dbContext.Bills.GroupBy(x => x.IssuingDate.Month)
                .Select(q => new ReportsMonthyBuyerOrdersModel { Month = q.Key, sumAmount = q.Sum(s => s.AmountWithTax), Count = q.Count() });

            List<ReportsMonthyBuyerOrdersModel> monthlyOrdersList = ordersByMonth
                .Select(q => new ReportsMonthyBuyerOrdersModel { Count = q.Count, sumAmount = q.sumAmount, Month = q.Month,MonthString = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(q.Month).ToUpper(),SumAmountString = q.sumAmount.ToString() +" KM "  }).ToList();

        
            report.MonthlyOrders = monthlyOrdersList;
                
            if(request.DateFrom.HasValue && request.DateTo.HasValue)
            {
                var bls = _dbContext.Bills.Include(b=>b.BillItems).Where(a=>a.IssuingDate >= request.DateFrom && a.IssuingDate <=request.DateTo).ToList();
                var bits = _dbContext.BillItems.Include(a=>a.FkProduct).ToList();
                List<BillItem> newBills = new List<BillItem>();

                foreach (var item in bls)
                {
                    foreach (var it in bits)
                    {
                        if(item.BillId == it.FkBillId)
                        {
                            newBills.Add(it);
                        }
                    }
                }

                List<TopProductsByDateModel> test2 = newBills.GroupBy(q => q.FkProduct.Name)
                    .Select(f => new TopProductsByDateModel
                    {
                        Name = f.Key,
                        Quanity = f.Sum(a => a.Quantity),
                        Sum = (int)f.Sum(a => a.Quantity * a.FkProduct.Price)
                    }).ToList();
                report.TopProductsByDateModel = test2;

           //NAPRAVITI DESIGNS
            
            }

            return report;
        }
    }
}
