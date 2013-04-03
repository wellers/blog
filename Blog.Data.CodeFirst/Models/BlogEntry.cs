using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Blog.Data.CodeFirst.Models
{
    public class BlogEntry : Entity
    {
        public string Title { get; set; }
        public string Entry { get; set; }
        public DateTime PostedDate { get; set; }
        public virtual IList<BlogEntryTag> BlogEntryTags { get; set; }
    }
}
