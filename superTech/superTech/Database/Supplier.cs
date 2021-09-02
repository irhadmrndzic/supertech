using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace superTech.Database
{
    public partial class Supplier
    {
        public Supplier()
        {
            Orders = new HashSet<Order>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string WebAddress { get; set; }
        public string BankAccount { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
