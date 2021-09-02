using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace superTech.Database
{
    public partial class UsersRole
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserRoleId { get; set; }
        public DateTime DateOfModification { get; set; }
        public int? FkUserId { get; set; }
        public int? FkRoleId { get; set; }

        public virtual Role FkRole { get; set; }
        public virtual User FkUser { get; set; }
    }
}
