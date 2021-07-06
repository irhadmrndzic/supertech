using System;
using System.Collections.Generic;
using System.Text;

namespace superTech.Models.Orders.OrderItems
{
  public  class OrderItemModel
    {
        public int OrderItemId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Amount { get; set; }
        public int? FkOrderId { get; set; }
        public int? FkProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
    }
}
