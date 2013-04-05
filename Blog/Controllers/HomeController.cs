using System;
using System.Linq;
using System.Web.Mvc;
using Blog.Interfaces.Repositories;
using Blog.Models;
using Blog.Interfaces.Models;
using System.Collections.Generic;

namespace Blog.Controllers
{
	public class HomeController : Controller
	{
		// TODO : About Me and Contact Me might benefit from having a white background.

		private readonly IBlogEntryRepository _blogEntryRepository;
		private readonly ITagRepository _tagRepository;

		public HomeController(IBlogEntryRepository blogEntryRepository, ITagRepository tagRepository)
		{
			_blogEntryRepository = blogEntryRepository;
			_tagRepository = tagRepository;
		}        

		public ActionResult Index()
		{
			DateTime mostRecentPostDate = _blogEntryRepository.GetMostRecentBlogEntry().PostedDate;

			var entries = _blogEntryRepository.GetBlogEntriesByMonthAndYear(mostRecentPostDate.Month, mostRecentPostDate.Year)
										.OrderByDescending(c => c.PostedDate).ToList();

			return View(new HomeViewModel { BlogEntries = entries });
		}

		public ActionResult Archive(int year, int month)
		{
			var entries = _blogEntryRepository.GetBlogEntriesByMonthAndYear(month, year)
											.OrderByDescending(c => c.PostedDate).ToList();
			if (entries.Count == 0)
			{
				DateTime mostRecentPostDate = _blogEntryRepository.GetMostRecentBlogEntry().PostedDate;

				entries = _blogEntryRepository.GetBlogEntriesByMonthAndYear(mostRecentPostDate.Month, mostRecentPostDate.Year)
											.OrderByDescending(c => c.PostedDate).ToList();
			}
			return View("Index", new HomeViewModel { BlogEntries = entries });
		}

		public ActionResult BlogEntry(int id)
		{
			var entry = _blogEntryRepository.Get(id);
			return View("BlogEntry", entry);
		}

		public ActionResult Tag(string tag)
		{
			var entries = _blogEntryRepository.GetBlogEntriesByTag(tag)
							.OrderByDescending(x => x.PostedDate).ToList();
			return View("Index", new HomeViewModel { BlogEntries = entries });
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Contact()
		{
			return View();
		}

		public ActionResult RecentPosts()
		{
			const int top = 5;
			var recentBlogEntries = _blogEntryRepository.All()
									.OrderByDescending(b => b.PostedDate)
									.Take(top).ToList();
			return PartialView("RecentPosts", recentBlogEntries);
		}

		public ActionResult Tags()
		{
			var allTags = _tagRepository.All().ToList();
			return PartialView("Tags", new TagsViewModel { Tags = allTags });
		}
	}
}
