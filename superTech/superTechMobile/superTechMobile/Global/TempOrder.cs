using System;
using System.Collections.Generic;

namespace superTechMobile.Global
{
    public class TempOrder
    {
        public TempOrder()
        {
            this.tempOrderItemsList = new List<TempOrderItems>();

        }

        public int BuyerOrderId { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public bool Canceled { get; set; }
        public int? FkUserId { get; set; }
        public int? OrderNumber { get; set; }
        public decimal? Amount { get; set; }
        public bool? Confirmed { get; set; }


        public List<TempOrderItems> tempOrderItemsList { get; set; }
    }
}
