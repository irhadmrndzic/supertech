using System.ComponentModel.DataAnnotations.Schema;

namespace superTech.Models.Orders.OrderItems
{
 public   class OrderItemsUpsertRequest
    {
        public int? Quantity { get; set; }
        public decimal? Amount { get; set; }
        public int? FkProductId { get; set; }

    }
}
