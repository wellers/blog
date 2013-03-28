using System.Collections.Generic;
using Blog.Controllers;

namespace Blog.Models
{
	public class TwitterFeedViewModel
	{
		public IEnumerable<TwitterFeedItem> Tweets { get; set; }
	}
}