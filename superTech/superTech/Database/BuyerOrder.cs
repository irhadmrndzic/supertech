using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace superTech.Database
{
    public partial class BuyerOrder
    {
        public BuyerOrder()
        {
            Bills = new HashSet<Bill>();
            BuyerOrderItems = new HashSet<BuyerOrderItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuyerOrderId { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public bool Canceled { get; set; }
        public int? FkUserId { get; set; }
        public int? OrderNumber { get; set; }
        public decimal? Amount { get; set; }
        public bool? Confirmed { get; set; }

        public virtual User FkUser { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<BuyerOrderItem> BuyerOrderItems { get; set; }
    }
}
