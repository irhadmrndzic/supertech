using System;
using System.Collections.Generic;

#nullable disable

namespace superTech.Database
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public decimal Amount { get; set; }
        public int? FkUserId { get; set; }
        public int? FkSupplierId { get; set; }

        public virtual Supplier FkSupplier { get; set; }
        public virtual User FkUser { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
