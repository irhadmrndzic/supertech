using System;
using System.Collections.Generic;

#nullable disable

namespace superTech.Database
{
    public partial class Supplier
    {
        public Supplier()
        {
            Orders = new HashSet<Order>();
        }

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
