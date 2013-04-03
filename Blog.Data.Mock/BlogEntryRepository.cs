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
		public static IBlogEntryModel entry1 = new BlogEntryModel
				   {
					   Key = 1,
					   Entry = HttpUtility.HtmlEncode(@"<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p></div><div><p>Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p></div>
<div><p>Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>"),
					   Title = "This is a title.",
					   PostedDate = DateTime.Now
				   };

		public static IBlogEntryModel entry2 = new BlogEntryModel
				   {
					   Key = 2, 
					   Entry = HttpUtility.HtmlEncode(@"<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p></div><div><p>Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>"), 
					   Title = "This is an another amazing title that is also really long.", 
					   PostedDate = DateTime.Now.AddDays(-1)
				   };

		public static IBlogEntryModel entry3 = new BlogEntryModel
				   {
					   Key = 3, 
					   Entry = HttpUtility.HtmlEncode(@"<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>"), 
					   Title = "Here is a really long and drawn-out title setup by me.", 
					   PostedDate = DateTime.Now.AddMonths(-1)
				   };

		public static IBlogEntryModel entry4 = new BlogEntryModel
				   {
					   Key = 4, 
					   Entry = HttpUtility.HtmlEncode(@"<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p></div><div><p>Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>"), 
					   Title = "This is an amazing title!", 
					   PostedDate = DateTime.Now.AddMonths(-1).AddDays(-1)
				   };        

		private readonly Dictionary<int, IBlogEntryModel> _blogEntries = new Dictionary<int, IBlogEntryModel>
		{
			{ entry1.Key, entry1 },
			{ entry2.Key, entry2 },
			{ entry3.Key, entry3 }, 
			{ entry4.Key, entry4 }
		};

		private TagRepository _tagRepository;
		private Dictionary<string, List<int>> _blogEntryTags;

		public BlogEntryRepository()
		{
			_tagRepository = new TagRepository();
			_blogEntryTags = new Dictionary<string, List<int>>();
			_blogEntryTags.Add(_tagRepository.Tags[0].LookupID, new List<int> { entry1.Key, entry2.Key });
			_blogEntryTags.Add(_tagRepository.Tags[1].LookupID, new List<int> { entry1.Key, entry3.Key });
			_blogEntryTags.Add(_tagRepository.Tags[2].LookupID, new List<int> { entry4.Key, entry2.Key });
		}

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

		public IQueryable<IBlogEntryModel> GetBlogEntriesByMonthAndYear(int month, int year)
		{
			return _blogEntries.Values.Where(b => b.PostedDate.Month == month && b.PostedDate.Year == year).AsQueryable();
		}

		public IQueryable<IBlogEntryModel> GetBlogEntriesByTag(string tag)
		{
			var blogEntryIDs = _blogEntryTags[tag];
			return _blogEntries.Where(x => blogEntryIDs.Contains(x.Key))
				.Select(y => y.Value).AsQueryable();
		}
	}
}
