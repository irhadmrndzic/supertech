using System;
using System.Collections.Generic;
using System.Text;

namespace superTech.Models.Ratings
{
    public class RatingsUpsertRequest
    {
        public int? Rating1 { get; set; }
        public int? FkUserId { get; set; }
        public int? FkProductId { get; set; }
    }
}
