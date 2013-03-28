using System;

namespace Blog.Data.CodeFirst.Models
{
    public class BlogEntry : Entity
    {
        public string Title { get; set; }
        public string Entry { get; set; }
        public DateTime PostedDate { get; set; }
    }
}
