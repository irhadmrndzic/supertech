

using superTech.Models.Orders.OrderItems;
using System;
using System.Collections.Generic;

namespace superTech.Models.Orders
{
    public class OrdersModel
    {
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public bool Confirmed { get; set; }
        public decimal Amount { get; set; }
        public int? FkUserId { get; set; }
        public int? FkSupplierId { get; set; }
        public string SupplierString { get; set; }
        public string UserString { get; set; }
        public virtual ICollection<OrderItemModel> OrderItems { get; set; }

    }
}
