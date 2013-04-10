using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Data.CodeFirst.Models;
using Blog.Data.CodeFirst.Persistence;
using Blog.Interfaces;
using Blog.Interfaces.Models;
using Blog.Models;

namespace Blog.Data.Dao
{
	public class BlogEntryTagDao : IDao<IBlogEntryTagModel>
	{
		private readonly Context _context = new Context();

		public IQueryable<IBlogEntryTagModel> Get()
		{
			return _context.BlogEntryTags.Select(x => new BlogEntryTagModel
														{
															Key = x.Id,
															BlogEntryKey = x.BlogEntryId,
															TagKey = x.TagId
														});
		}
	}
}
