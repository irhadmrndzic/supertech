using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace superTech.Database
{
    public partial class Rating
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }
        public DateTime? Date { get; set; }
        public int? Rating1 { get; set; }
        public int? FkUserId { get; set; }
        public int? FkProductId { get; set; }

        public virtual Product FkProduct { get; set; }
        public virtual User FkUser { get; set; }
    }
}
