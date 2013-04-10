using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Data.CodeFirst.Persistence;
using Blog.Interfaces;
using Blog.Interfaces.Models;
using Blog.Models;

namespace Blog.Data.Dao
{
	public class TagDao : IDao<ITagModel>
	{
		private readonly Context _context = new Context();
		
		public IQueryable<ITagModel> Get()
		{
			return _context.Tags.Select(t => new TagModel
			{
				Key = t.Id,
				LookupID = t.LookupID,
				Name = t.Name
			});
		}
	}
}
