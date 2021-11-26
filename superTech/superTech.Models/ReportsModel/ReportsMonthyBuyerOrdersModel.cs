
using System.Collections.Generic;

namespace superTech.Models.ReportsModel
{
    public class ReportsMonthyBuyerOrdersModel
    {
        public int Month { get; set; }
        public string MonthString{ get; set; }

        public int Count { get; set; }
        public decimal? sumAmount { get; set; }
        public string SumAmountString { get; set; }
    }
}
