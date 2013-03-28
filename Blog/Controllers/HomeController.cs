using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System.Linq;
using System.Xml.Linq;
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

		public ActionResult Index()
		{
			var entries = _repository.All().ToList();
			return View(new HomeViewModel { BlogEntries = entries });
		}

		public ActionResult About()
		{
			return View();
		}
	}
}
