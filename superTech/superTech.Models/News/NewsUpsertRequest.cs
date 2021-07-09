using System;
using System.ComponentModel.DataAnnotations;

namespace superTech.Models.News
{
    public class NewsUpsertRequest
    {
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        [MinLength(1)]
        public string Content { get; set; }
        [Required]
        public DateTime DateOfCreation { get; set; }
        public bool Active { get; set; }
    }
}
