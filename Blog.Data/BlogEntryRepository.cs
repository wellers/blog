using System.Collections.Generic;
using System.Linq;
using Blog.Data.CodeFirst.Persistence;
using Blog.Interfaces.Models;
using Blog.Interfaces.Repositories;
using Blog.Models;

namespace Blog.Data
{
	public class BlogEntryRepository : IBaseRepository<IBlogEntryModel>, IBlogEntryRepository
	{
		private readonly Context _context = new Context();

		public IBlogEntryModel Get(int id)
		{
			return _context.BlogEntries.Where(b => b.Id == id).Select(b => new BlogEntryModel
			{
				Key = b.Id,
				Title = b.Title,
				Entry = b.Entry,
				PostedDate = b.PostedDate
			}).SingleOrDefault();
		}

		public IQueryable<IBlogEntryModel> All()
		{
			return _context.BlogEntries.Select(b => new BlogEntryModel
			{
				Key = b.Id,
				Title = b.Title,
				Entry = b.Entry,
				PostedDate = b.PostedDate
			});
		}
	}
}
