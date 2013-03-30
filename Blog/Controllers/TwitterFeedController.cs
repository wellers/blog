using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Xml.Linq;
using Blog.Core.Extensions;
using Blog.Core.Utility;
using Blog.Models;

namespace Blog.Controllers
{
	public class TwitterFeedController : AsyncController
	{
		private const string _cacheKey = "TwitterFeed";

		public void IndexAsync()
		{
			// TODO : Make this value configurable.
			const string userName = "wellers";

			AsyncManager.OutstandingOperations.Increment();
			GetTwitterFeed(userName);
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
				model = new TwitterFeedViewModel { Tweets = tweets };
			}

			return PartialView("TwitterFeed", model);
		}

		private void GetTwitterFeed(string screenName)
		{
			if (string.IsNullOrEmpty(screenName))
				throw new ArgumentNullException("screenName");

			// check the cache for Tweets
			List<TwitterFeedItem> items;
			if (CacheHelper.TryGet<List<TwitterFeedItem>>(_cacheKey, out items))
			{
				AsyncManager.Parameters["tweets"] = items.ToList();
				AsyncManager.OutstandingOperations.Decrement();
				return;
			}

			var twitter = new WebClient();

			twitter.DownloadStringCompleted += (sender, e) =>
			{
				// TODO : Make this value configurable.
				const int numberOfTweets = 5;

				if (e.Error != null)
					return;

				XElement xmlTweets = XElement.Parse(e.Result);
				var tweets = xmlTweets.Descendants("status").Take(numberOfTweets).Select(tweet => new TwitterFeedItem
				{
					ImageSource = tweet.Element("user").Element("profile_image_url").Value,
					Message = tweet.Element("text").Value,
					UserName = tweet.Element("user").Element("screen_name").Value,
					PostedDate = tweet.Element("created_at").Value.ParseTwitterDateTime()
				});

				// add tweets to cache
				var tweetsList = tweets.ToList();

				// TODO : make timeout configurable.
				CacheHelper.Add<List<TwitterFeedItem>>(tweetsList, _cacheKey, (double)30);

				AsyncManager.Parameters["tweets"] = tweetsList;
				AsyncManager.OutstandingOperations.Decrement();
			};

			var feedUrl = new Uri(string.Format("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name={0}", screenName));
			twitter.DownloadStringAsync(feedUrl);
		}
	}
}
