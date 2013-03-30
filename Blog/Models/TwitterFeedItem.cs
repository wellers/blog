using System;

namespace Blog.Models
{
	public class TwitterFeedItem
	{
		public string UserName { get; set; }
		public string Message { get; set; }
		public string ImageSource { get; set; }
        public DateTime PostedDate { get; set; }
	}
}