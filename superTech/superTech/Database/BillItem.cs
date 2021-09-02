using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace superTech.Database
{
    public partial class BillItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillItemId { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public int Quantity { get; set; }
        public int? FkBillId { get; set; }
        public int? FkProductId { get; set; }

        public virtual Bill FkBill { get; set; }
        public virtual Product FkProduct { get; set; }
    }
}
