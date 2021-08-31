

using System;

namespace superTech.Models.Ratings
{
    public class RatingsModel
    {
        public int RatingId { get; set; }
        public DateTime? Date { get; set; }
        public int? Rating1 { get; set; }
        public int? FkUserId { get; set; }
        public int? FkProductId { get; set; }

        //public virtual Product FkProduct { get; set; }
        //public virtual User FkUser { get; set; }
    }
}
