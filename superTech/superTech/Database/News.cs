using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace superTech.Database
{
    public partial class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateOfCreation { get; set; }
        public bool Active { get; set; }
        public int? FkUserId { get; set; }

        public virtual User FkUser { get; set; }
    }
}
