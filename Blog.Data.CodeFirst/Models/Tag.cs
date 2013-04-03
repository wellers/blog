using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.CodeFirst.Models
{
    public class Tag : Entity
    {
        public string LookupID { get; set; }
        public string Name { get; set; }
        public virtual IList<BlogEntryTag> BlogEntryTags { get; set; }
    }
}
