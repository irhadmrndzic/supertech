using System;
using System.Collections.Generic;

#nullable disable

namespace superTech.Database
{
    public partial class UnitsOfMeasure
    {
        public UnitsOfMeasure()
        {
            Products = new HashSet<Product>();
        }

        public int UnitOfMeasureId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
