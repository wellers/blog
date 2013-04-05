using System;
using System.Linq;
using Blog.Data.CodeFirst.Persistence;
using Blog.Interfaces.Models;
using Blog.Interfaces.Repositories;
using Blog.Models;

namespace Blog.Data
{
	public class BlogEntryRepository : IBlogEntryRepository
	{
		private readonly Context _context = new Context();

		public IQueryable<IBlogEntryModel> All()
		{
			return _context.BlogEntries.Select(b => new BlogEntryModel
			{
				Key = b.Id,
				Title = b.Title,
				Entry = b.Entry,
				PostedDate = b.PostedDate,
				Tags = _context.BlogEntryTags.Where(x => x.BlogEntryId == b.Id).Select(y => y.Tag)
						.Select(z => new TagModel 
						{
							Key = z.Id,
							LookupID = z.LookupID,
							Name = z.Name
						})
			});
		}

		public IBlogEntryModel Get(int id)
		{
			return All().Where(b => b.Key == id).SingleOrDefault();
		}

		public IQueryable<IBlogEntryModel> GetBlogEntriesByMonthAndYear(int month, int year)
		{
			return All().Where(b => b.PostedDate.Month == month && b.PostedDate.Year == year);
		}

		public IQueryable<IBlogEntryModel> GetBlogEntriesByTag(string tag)
		{
			if (string.IsNullOrEmpty(tag))
				throw new ArgumentException("Cannot be null or empty", "tag");

			var tagID = _context.Tags.Where(x => x.LookupID == tag).Select(y => y.Id).Single();
			return _context.BlogEntryTags.Where(b => b.TagId == tagID).Select(c => c.BlogEntry)
					.Select(b => new BlogEntryModel
					{
						Key = b.Id,
						Title = b.Title,
						Entry = b.Entry,
						PostedDate = b.PostedDate,
						Tags = _context.BlogEntryTags.Where(x => x.BlogEntryId == b.Id).Select(y => y.Tag)
								.Select(z => new TagModel
								{
									Key = z.Id,
									LookupID = z.LookupID,
									Name = z.Name
								})
					});
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
