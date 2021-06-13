using System;
using System.Collections.Generic;

#nullable disable

namespace superTech.Database
{
    public partial class City
    {
        public City()
        {
            Users = new HashSet<User>();
        }

        public int CityId { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
