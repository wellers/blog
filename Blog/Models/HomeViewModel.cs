using System.Collections.Generic;
using Blog.Interfaces.Models;

namespace Blog.Models
{
	public class HomeViewModel
	{
		public IEnumerable<IBlogEntryModel> BlogEntries { get; set; }
	}
}