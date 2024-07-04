using System.Linq;
using Blog.Data.CodeFirst.Persistence;
using Blog.Interfaces;
using Blog.Interfaces.Models;
using Blog.Models;

namespace Blog.Data.Dao
{
	public class BlogEntryDao : IDao<IBlogEntryModel>
	{
		private readonly Context _context = new Context();

		public IQueryable<IBlogEntryModel> Get()
		{
			return _context.BlogEntries.Select(b => new BlogEntryModel
			{
				Key = b.Id,
				Title = b.Title,
				Entry = b.Entry,
				PostedDate = b.PostedDate,
				Tags = b.BlogEntryTags.Where(x => x.BlogEntryId == b.Id)
							.Select(y => y.Tag)
							.Select(z => new TagModel
							{
								Key = z.Id,
								LookupID = z.LookupID,
								Name = z.Name
							}).AsQueryable()
			});
		}
	}
}
