using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Interfaces;
using Blog.Interfaces.Models;
using Blog.Interfaces.Repositories;

namespace Blog.Data
{
	public class BlogEntryRepository : IBlogEntryRepository
	{
		private readonly IDao<IBlogEntryModel> _blogEntryDao;
		private readonly IDao<ITagModel> _tagDao;
		private readonly IDao<IBlogEntryTagModel> _blogEntryTagDao;

		public BlogEntryRepository(IDao<IBlogEntryModel> blogEntryDao, IDao<ITagModel> tagDao, IDao<IBlogEntryTagModel> blogEntryTagDao)
		{
			_blogEntryDao = blogEntryDao;
			_tagDao = tagDao;
			_blogEntryTagDao = blogEntryTagDao;
		}

		private IQueryable<IBlogEntryModel> All()
		{
			return _blogEntryDao.Get();
		}

		public IBlogEntryModel Get(int id)
		{
			return All().SingleOrDefault(b => b.Key == id);
		}

		public IList<IBlogEntryModel> GetBlogEntriesByMonthAndYear(int month, int year)
		{
			return All()
				.Where(b => b.PostedDate.Month == month && b.PostedDate.Year == year)
				.OrderByDescending(c => c.PostedDate)
				.ToList();
		}

		public IList<IBlogEntryModel> GetBlogEntriesByYear(int year)
		{
			return All()
				.Where(b => b.PostedDate.Year == year)
				.OrderByDescending(c => c.PostedDate)
				.ToList();
		}

		public IList<IBlogEntryModel> GetBlogEntriesByTag(string tag)
		{
			if (string.IsNullOrEmpty(tag))
				throw new ArgumentException("Cannot be null or empty", nameof(tag));

			var tagId = _tagDao.Get().Where(x => x.LookupID == tag).Select(y => y.Key).Single();
			var blogEntryKeys = _blogEntryTagDao.Get().Where(b => b.TagKey == tagId).Select(c => c.BlogEntryKey).ToList();
			return All()
				.Where(x => blogEntryKeys.Contains(x.Key))
				.OrderByDescending(x => x.PostedDate)
				.ToList();
		}

		public IBlogEntryModel GetMostRecentBlogEntry()
		{
			const int numberOfEntries = 1;
			return GetTopMostRecentBlogEntries(numberOfEntries).Single();
		}


		public IList<IBlogEntryModel> GetTopMostRecentBlogEntries(int numberOfEntries)
		{
			return All().OrderByDescending(b => b.PostedDate).Take(numberOfEntries).ToList();
		}
	}
}
