using System;
using System.Collections.Generic;

#nullable disable

namespace superTech.Database
{
    public partial class Role
    {
        public Role()
        {
            UsersRoles = new HashSet<UsersRole>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UsersRole> UsersRoles { get; set; }
    }
}
