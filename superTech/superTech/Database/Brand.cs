using System;
using System.Collections.Generic;

#nullable disable

namespace superTech.Database
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int BrandId { get; set; }
        public string Name { get; set; }
        public string WebAddress { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
