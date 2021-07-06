
using superTech.Models.Orders.OrderItems;
using System;
using System.Collections.Generic;

namespace superTech.Models.Orders
{
    public class OrdersUpsertRequest
    {
        public int OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public decimal Amount { get; set; }
        public int? UserId { get; set; }
        public int? SupplierId { get; set; }

        public  ICollection<OrderItemsUpsertRequest> OrderItems { get; set; }
    }
}
