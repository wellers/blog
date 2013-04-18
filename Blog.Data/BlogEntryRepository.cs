using System;
using System.Linq;
using Blog.Data.Dao;
using Blog.Interfaces;
using Blog.Interfaces.Models;
using Blog.Interfaces.Repositories;

namespace Blog.Data
{
	public class BlogEntryRepository : IBlogEntryRepository
	{
        private IDao<IBlogEntryModel> _blogEntryDao;
		private IDao<ITagModel> _tagDao;
		private IDao<IBlogEntryTagModel> _blogEntryTagDao;
        
        public BlogEntryRepository(IDao<IBlogEntryModel> blogEntryDao, IDao<ITagModel> tagDao, IDao<IBlogEntryTagModel> blogEntryTagDao)
        {
            _blogEntryDao = blogEntryDao;
            _tagDao = tagDao;
            _blogEntryTagDao = blogEntryTagDao;
        }

		public IQueryable<IBlogEntryModel> All()
		{
			return _blogEntryDao.Get();
		}

		public IBlogEntryModel Get(int id)
		{
			return All().SingleOrDefault(b => b.Key == id);
		}

		public IQueryable<IBlogEntryModel> GetBlogEntriesByMonthAndYear(int month, int year)
		{
			return All().Where(b => b.PostedDate.Month == month && b.PostedDate.Year == year);
		}

        public IQueryable<IBlogEntryModel> GetBlogEntriesByYear(int year)
        {
            return All().Where(b => b.PostedDate.Year == year);
        }

		public IQueryable<IBlogEntryModel> GetBlogEntriesByTag(string tag)
		{
			if (string.IsNullOrEmpty(tag))
				throw new ArgumentException("Cannot be null or empty", "tag");

			var tagID = _tagDao.Get().Where(x => x.LookupID == tag).Select(y => y.Key).Single();
			var blogEntryKeys = _blogEntryTagDao.Get().Where(b => b.TagKey == tagID).Select(c => c.BlogEntryKey).ToList();
			return All().Where(x => blogEntryKeys.Contains(x.Key));
		}

		public IBlogEntryModel GetMostRecentBlogEntry()
		{
			const int numberOfEntries = 1;
			return GetTopMostRecentBlogEntries(numberOfEntries).Single();
		}


		public IQueryable<IBlogEntryModel> GetTopMostRecentBlogEntries(int numberOfEntries)
		{
			return All().OrderByDescending(b => b.PostedDate).Take(numberOfEntries);
		}	
	}
}
