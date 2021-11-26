using System;
using System.Collections.Generic;
using System.Text;

namespace superTech.Models.ReportsModel
{
 public   class TopSoldProducts
    {
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; } = 0;
        public decimal? TaxPrice { get; set; } = 0;
        public int testId { get; set; }

        public string PriceString { get; set; } 
        public string TaxPriceString { get; set; } 

    }
}
