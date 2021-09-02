using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace superTech.Database
{
    public partial class Role
    {
        public Role()
        {
            UsersRoles = new HashSet<UsersRole>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UsersRole> UsersRoles { get; set; }
    }
}
