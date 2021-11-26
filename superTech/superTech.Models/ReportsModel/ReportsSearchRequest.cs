using System;
using System.Collections.Generic;
using System.Text;

namespace superTech.Models.ReportsModel
{
   public class ReportsSearchRequest
    {
        public int? ProductId { get; set; }
        public string ProductCode { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
