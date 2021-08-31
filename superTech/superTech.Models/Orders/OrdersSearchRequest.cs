using System;
using System.Collections.Generic;
using System.Text;

namespace superTech.Models.Orders
{
    public class OrdersSearchRequest
    {

        public int? OrderNumber { get; set; }
        public DateTime Date { get; set; }

    }
}
