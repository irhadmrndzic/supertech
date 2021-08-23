using System;

namespace superTech.Models.BuyerOrders
{
   public class BuyerOrdersModel
    {
        public int BuyerOrderId { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public bool Canceled { get; set; }
        public int? FkUserId { get; set; }
        public int? OrderNumber { get; set; }
        public decimal? Amount { get; set; }
        public bool? Confirmed { get; set; }
        public string UserString { get; set; }

    }
}
