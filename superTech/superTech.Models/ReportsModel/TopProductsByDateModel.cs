
using System.Collections.Generic;

namespace superTech.Models.ReportsModel
{
   public class TopProductsByDateModel
    {
        public string Name { get; set; }
        public int Quanity { get; set; }
        public decimal Sum { get; set; }
        public string SumString { get; set; }

        public List<object> test { get; set; }
    }
}
