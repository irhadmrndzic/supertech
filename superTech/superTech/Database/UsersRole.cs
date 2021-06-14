using System;
using System.Collections.Generic;

#nullable disable

namespace superTech.Database
{
    public partial class UsersRole
    {
        public int UserRoleId { get; set; }
        public DateTime DateOfModification { get; set; }
        public int? FkUserId { get; set; }
        public int? FkRoleId { get; set; }

        public virtual Role FkRole { get; set; }
        public virtual User FkUser { get; set; }
    }
}