using System;
using System.Collections.Generic;

#nullable disable

namespace superTech.Database
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public DateTime? Date { get; set; }
        public int? Rating1 { get; set; }
        public int? FkUserId { get; set; }
        public int? FkProductId { get; set; }

        public virtual Product FkProduct { get; set; }
        public virtual User FkUser { get; set; }
    }
}
