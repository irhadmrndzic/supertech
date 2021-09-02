using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace superTech.Database
{
    public partial class City
    {
        public City()
        {
            Users = new HashSet<User>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
