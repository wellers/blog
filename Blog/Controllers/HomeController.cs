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
		private readonly IBlogEntryRepository _repository;

		public HomeController(IBlogEntryRepository repository)
		{
			_repository = repository;
		}        

		public ActionResult Index(int? month = null, int? year = null)
		{
			var monthFilter = month ?? DateTime.Now.Month;
			var yearFilter = year ?? DateTime.Now.Year;

			var entries = _repository.GetBlogEntriesByMonthAndYear(monthFilter, yearFilter)
											.OrderByDescending(c => c.PostedDate).ToList();

			if (entries.Count == 0)
			{
				DateTime mostRecentPost = _repository.All()
											.OrderByDescending(b => b.PostedDate)
											.Take(1).Single().PostedDate;

				entries = _repository.GetBlogEntriesByMonthAndYear(mostRecentPost.Month, mostRecentPost.Year)
											.OrderByDescending(c => c.PostedDate).ToList();
			}

			return View(new HomeViewModel { BlogEntries = entries });
		}

		public ActionResult IndexByID(int id)
		{
			var entry = _repository.Get(id);
			return View("Index", new HomeViewModel { BlogEntries = new List<IBlogEntryModel> { entry } });
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
			var recentBlogEntries = _repository.All()
									.OrderByDescending(b => b.PostedDate)
									.Take(top).ToList();
			return PartialView("RecentPosts", recentBlogEntries);
		}
	}
}
