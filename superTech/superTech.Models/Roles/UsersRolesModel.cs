using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using superTech.Models.User;

namespace superTech.Models.Roles
{
   public class UsersRolesModel
    {
        public int UserRoleId { get; set; }
        public DateTime DateOfModification { get; set; }
        public int? FkUserId { get; set; }
        public int? FkRoleId { get; set; }
        public virtual RolesModel FkRole { get; set; }
        public virtual UserModel FkUser { get; set; }
    }
}
