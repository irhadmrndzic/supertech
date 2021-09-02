using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace superTech.Database
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string WebAddress { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
