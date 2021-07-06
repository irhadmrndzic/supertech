using System.ComponentModel.DataAnnotations.Schema;

namespace superTech.Models.Orders.OrderItems
{
 public   class OrderItemsUpsertRequest
    {
        public int? Quantity { get; set; }
        public decimal? Amount { get; set; }
        public int? FkProductId { get; set; }

        //public virtual Order FkOrder { get; set; }
        //public virtual Product FkProduct { get; set; }
    }
}
