using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Interfaces.Models;
using Blog.Interfaces.Repositories;
using Blog.Models;

namespace Blog.Data.Mock
{
	public class BlogEntryRepository : IBlogEntryRepository
	{
		private readonly Dictionary<int, IBlogEntryModel> _blogEntries = new Dictionary<int, IBlogEntryModel>
		{
			{
				1,
				new BlogEntryModel
				   {
					   Key = 1, 
					   Entry = HttpUtility.HtmlEncode(@"<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p></div><div><p>Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p></div>
<div><p>Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>"), 
					   Title = "This is an amazing title #1", 
					   PostedDate = DateTime.Now.AddDays(-2)
				   }
			},
			{
				2,
				new BlogEntryModel
				   {
					   Key = 2, 
					   Entry = HttpUtility.HtmlEncode(@"<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p></div><div><p>Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>"), 
					   Title = "This is an amazing title #2", 
					   PostedDate = DateTime.Now.AddDays(-1)
				   }
			}
		};

		
		public IBlogEntryModel Get(int id)
		{
			if (!_blogEntries.ContainsKey(id))
				throw new KeyNotFoundException();
			
			return _blogEntries[id];
		}
		
		public IQueryable<IBlogEntryModel> All()
		{
			return _blogEntries.Values.AsQueryable();
		}
	}
}
