﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System.Linq;
using System.Xml.Linq;
using Blog.Interfaces.Repositories;
using Blog.Models;
using Blog.Interfaces.Models;

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
														&& b.PostedDate.Year == yearFilter).ToList();

			if (entries.Count == 0)
			{
				DateTime mostRecentPost = _repository.All().OrderByDescending(b => b.PostedDate).Take(1).Single().PostedDate;
				entries = _repository.All().Where(b => b.PostedDate.Month == mostRecentPost.Month
														&& b.PostedDate.Year == mostRecentPost.Year).ToList();
			}

			return View(new HomeViewModel { BlogEntries = entries });
		}

		public ActionResult About()
		{
			return View();
		}
	}
}
