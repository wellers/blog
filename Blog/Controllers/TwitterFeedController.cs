using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Xml.Linq;
using Blog.Models;

namespace Blog.Controllers
{
	public class TwitterFeedController : AsyncController
	{
		public void IndexAsync()
		{
			AsyncManager.OutstandingOperations.Increment();
			// TODO : Make this value configurable.
			GetTwitterFeed("wellers");
		}

		public ActionResult IndexCompleted(List<TwitterFeedItem> tweets)
		{
			TwitterFeedViewModel model;
			if (tweets == null || !tweets.Any())
			{
				model = new TwitterFeedViewModel { Tweets = new List<TwitterFeedItem>() };
			}
			else
			{
				// TODO : Make this value configurable.
				model = new TwitterFeedViewModel { Tweets = tweets.Take(5) };
			}

			return PartialView("TwitterFeed", model);
		}


		private void GetTwitterFeed(string screenName)
		{
			if (string.IsNullOrEmpty(screenName))
				throw new ArgumentNullException("screenName");

			var twitter = new WebClient();

			twitter.DownloadStringCompleted += (sender, e) =>
			{
				if (e.Error != null)
					return;
				XElement xmlTweets = XElement.Parse(e.Result);

				var tweets = xmlTweets.Descendants("status").Select(tweet => new TwitterFeedItem
				{
					ImageSource = tweet.Element("user").Element("profile_image_url").Value,
					Message = tweet.Element("text").Value,
					UserName = tweet.Element("user").Element("screen_name").Value
				});

				AsyncManager.Parameters["tweets"] = tweets.ToList();
				AsyncManager.OutstandingOperations.Decrement();
			};
			var feedUrl = new Uri(string.Format("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name={0}", screenName));
			twitter.DownloadStringAsync(feedUrl);
		}

	}
}
