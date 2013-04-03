using System.Collections.Generic;
using Blog.Interfaces.Models;

namespace Blog.Models
{
    public class TagsViewModel
    {
        public IEnumerable<ITagModel> Tags { get; set; }
    }
}