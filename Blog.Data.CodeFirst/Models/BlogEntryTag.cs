using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.CodeFirst.Models
{
    public class BlogEntryTag : Entity
    {
        [Key, Column(Order = 0)]
        [ForeignKey("BlogEntry")]
        public int BlogEntryId { get; set; }
        public virtual BlogEntry BlogEntry { get; set; }
        
        [Key, Column(Order = 1)]
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
