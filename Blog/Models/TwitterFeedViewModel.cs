using System.Collections.Generic;

namespace Blog.Models
{
	public class TwitterFeedViewModel
	{
		public IEnumerable<TwitterFeedItem> Tweets { get; set; }
	}
}