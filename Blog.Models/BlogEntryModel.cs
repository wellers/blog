using System;
using System.Linq;
using Blog.Interfaces.Models;

namespace Blog.Models
{
	public class BlogEntryModel : BaseModel, IBlogEntryModel
	{
		public string Title { get; set; }
		public string Entry { get; set; }
		public DateTime PostedDate { get; set; }
        public IQueryable<ITagModel> Tags { get; set; }
    }
}
