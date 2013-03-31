using System;
using System.Linq;
using System.Web.Mvc;
using Blog.Interfaces.Repositories;
using Blog.Models;

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
			int monthFilter = DateTime.Now.Month;
			if (month != null)
				monthFilter = (int)month;
			
			int yearFilter = DateTime.Now.Year;
			if (year != null)
				yearFilter = (int)year;

			var entries = _repository.All().Where(b => b.PostedDate.Month == monthFilter 
														&& b.PostedDate.Year == yearFilter)
                                            .OrderByDescending(c => c.PostedDate).ToList();

			if (entries.Count == 0)
			{
				DateTime mostRecentPost = _repository.All().OrderByDescending(b => b.PostedDate)
                                            .Take(1).Single().PostedDate;
				entries = _repository.All().Where(b => b.PostedDate.Month == mostRecentPost.Month
														&& b.PostedDate.Year == mostRecentPost.Year)
                                            .OrderByDescending(c => c.PostedDate).ToList();
			}

			return View(new HomeViewModel { BlogEntries = entries });
		}

		public ActionResult About()
		{
			return View();
		}
	}
}
