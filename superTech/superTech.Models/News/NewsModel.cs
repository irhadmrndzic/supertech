using System;

namespace superTech.Models.News
{
    public class NewsModel
    {
        public int NewsId { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateOfCreation { get; set; }
        public bool Active { get; set; }
    }
}
