using superTech.Models.Product;
using System;
using System.Collections.Generic;

namespace superTechMobile.Global
{
    public class TempOrderItems
    {
        public TempOrderItems()
        {
        }
        public int BuyerOrderItemsId { get; set; }
        public int? Quantity { get; set; }
        public int? FkProductId { get; set; }
        public int? FkBuyerOrder { get; set; }
        public decimal? Amount { get; set; }

        public virtual ProductModel FkProduct { get; set; }


    }
}
