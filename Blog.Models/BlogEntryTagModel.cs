using Blog.Interfaces.Models;

namespace Blog.Models
{
	public class BlogEntryTagModel : IBlogEntryTagModel
	{
		public int BlogEntryKey { get; set; }
		public int TagKey { get; set; }
		public int Key { get; set; }
	}
}
