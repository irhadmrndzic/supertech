using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace superTech.Database
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int? OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public decimal Amount { get; set; }
        public int? FkUserId { get; set; }
        public int? FkSupplierId { get; set; }
        public bool? Confirmed { get; set; }
        public bool? Canceled { get; set; }

        public virtual Supplier FkSupplier { get; set; }
        public virtual User FkUser { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
