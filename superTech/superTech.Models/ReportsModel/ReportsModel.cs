
using superTech.Models.BuyerOrders.BuyerOrderItems;
using System.Collections.Generic;

namespace superTech.Models.ReportsModel
{
    public class ReportsModel
    {
        public int EmployeesCount { get; set; }
        public int BuyersCount { get; set; }
        public int AllProductCount { get; set; }
        public int BuyerOrdersCount { get; set; }
        public string BuyerBillsSum { get; set; }
        public int OrdersCount { get; set; }
        public int ProductsSold { get; set; }
        public List<TopSoldProducts> TopSoldProducts { get; set; }
        public List<ReportsMonthyBuyerOrdersModel> MonthlyOrders { get; set; }
        public List<TopProductsByDateModel> TopProductsByDateModel { get; set; }


        public int ProductSoldByDate { get; set; }
       public List<ReportsBuyerItemsModel> ProductSoldByDateInfo { get; set; }
       public List<ReportsBuyerItemsModel> AllProductSoldByDateInfo { get; set; }
    }
}
