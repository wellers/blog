using System;
using System.Web;
using System.Web.Mvc;
using Blog.Interfaces.Repositories;
using Blog.Models;

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
			var entries = _blogEntryRepository.GetTopMostRecentBlogEntries(numberOfEntries);

			return View(new HomeViewModel { BlogEntries = entries });
		}

		public ActionResult Archive(int year, int? month)
		{
			var entries = month.HasValue 
				? _blogEntryRepository.GetBlogEntriesByMonthAndYear((int)month, year) 
				: _blogEntryRepository.GetBlogEntriesByYear(year);

			if (entries.Count != 0) 
				return View("Index", new HomeViewModel { BlogEntries = entries });
			
			var mostRecentPostDate = _blogEntryRepository.GetMostRecentBlogEntry().PostedDate;

			entries = _blogEntryRepository.GetBlogEntriesByMonthAndYear(mostRecentPostDate.Month, mostRecentPostDate.Year);

			return View("Index", new HomeViewModel { BlogEntries = entries });
		}

		public ActionResult BlogEntry(int id)
		{
			var entry = _blogEntryRepository.Get(id);
			return View("BlogEntry", entry);
		}

		public ActionResult Tag(string tag)
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
			const int numberOfEntries = 5;
			var entries = _blogEntryRepository.GetTopMostRecentBlogEntries(numberOfEntries);

			return PartialView("RecentPosts", entries);
		}

		public ActionResult Tags()
		{
			var allTags = _tagRepository.GetAll();
			
			return PartialView("Tags", new TagsViewModel { Tags = allTags });
		}

		public ActionResult SetTheme(SetThemeViewModel model)
		{
			var cookie = new HttpCookie("PromptTheme", model.SelectedTheme) { Expires = DateTime.Now.AddYears(1) };
			
			Response.Cookies.Add(cookie);
			
			return Request.UrlReferrer != null 
				? new RedirectResult(Request.UrlReferrer.ToString()) 
				: new RedirectResult("Index");
		}

		public ActionResult PostFeed(string type)
		{
			if (!type.ToLower().Equals("rss")) 
				return RedirectToAction("Index");
			
			const int numberOfEntries = 5;
			return View("PostRss", new PostRssViewModel { BlogEntries = _blogEntryRepository.GetTopMostRecentBlogEntries(numberOfEntries) });
		}
	}
}
