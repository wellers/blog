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
		private readonly IBlogEntryRepository _blogEntryRepository;
		private readonly ITagRepository _tagRepository;

		public HomeController(IBlogEntryRepository blogEntryRepository, ITagRepository tagRepository)
		{
			_blogEntryRepository = blogEntryRepository;
			_tagRepository = tagRepository;
		}        

		public ActionResult Index(int? month = null, int? year = null)
		{
			var monthFilter = month ?? DateTime.Now.Month;
			var yearFilter = year ?? DateTime.Now.Year;

			var entries = _blogEntryRepository.GetBlogEntriesByMonthAndYear(monthFilter, yearFilter)
											.OrderByDescending(c => c.PostedDate).ToList();

			if (entries.Count == 0)
			{
				DateTime mostRecentPost = _blogEntryRepository.All()
											.OrderByDescending(b => b.PostedDate)
											.Take(1).Single().PostedDate;

				entries = _blogEntryRepository.GetBlogEntriesByMonthAndYear(mostRecentPost.Month, mostRecentPost.Year)
											.OrderByDescending(c => c.PostedDate).ToList();
			}

			return View(new HomeViewModel { BlogEntries = entries });
		}

		public ActionResult IndexByID(int id)
		{
			var entry = _blogEntryRepository.Get(id);
			return View("Index", new HomeViewModel { BlogEntries = new List<IBlogEntryModel> { entry } });
		}

        public ActionResult IndexByTag(string tag)
        {
            var entries = _blogEntryRepository.GetBlogEntriesByTag(tag);
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
            return PartialView("Tags", new TagsViewModel { Tags = _tagRepository.All().ToList() });
		}
	}
}
