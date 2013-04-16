using System;
using System.Linq;
using System.Web;
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

		public ActionResult Index()
		{           
			const int numberOfEntries = 4;
			var entries = _blogEntryRepository.GetTopMostRecentBlogEntries(numberOfEntries).ToList();

			return View(new HomeViewModel { BlogEntries = entries });
		}

		public ActionResult Archive(int year, int? month)
		{
            List<IBlogEntryModel> entries;
            if (month.HasValue)
            {
                entries = _blogEntryRepository.GetBlogEntriesByMonthAndYear((int)month, year)
                                                .OrderByDescending(c => c.PostedDate).ToList();
            }
            else
            {
                entries = _blogEntryRepository.GetBlogEntriesByYear(year)
                                                .OrderByDescending(c => c.PostedDate).ToList();
            }

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
			const int numberOfEntries = 5;
			var entries = _blogEntryRepository.GetTopMostRecentBlogEntries(numberOfEntries).ToList();

			return PartialView("RecentPosts", entries);
		}

		public ActionResult Tags()
		{
			var allTags = _tagRepository.All().OrderBy(t => t.Name).ToList();
			return PartialView("Tags", new TagsViewModel { Tags = allTags });
		}

		public ActionResult SetTheme(SetThemeViewModel model)
		{
            var cookie = new HttpCookie("PromptTheme", model.SelectedTheme) { Expires = DateTime.Now.AddYears(1) };
			Response.Cookies.Add(cookie);
			if (Request.UrlReferrer != null)
			{
				return new RedirectResult(Request.UrlReferrer.ToString());
			}
			return new RedirectResult("Index");
		}
	}
}
