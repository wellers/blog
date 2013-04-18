using System.Collections.Generic;
using Blog.Interfaces.Models;

namespace Blog.Models
{
    public class PostRssViewModel
    {
        public IEnumerable<IBlogEntryModel> BlogEntries { get; set; }
    }
}