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
		public static IBlogEntryModel Entry1 = new BlogEntryModel
		{
			Key = 1,
			Entry = @"<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p></div><div><p>Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p></div>
<div><p>Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>
<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p></div><div><p>Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p></div>
<div><p>Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>
<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p></div><div><p>Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p></div>
<div><p>Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>
<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p></div><div><p>Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p></div>
<div><p>Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>",
			Title = "This is a title.",
			PostedDate = DateTime.Now,
		};

		public static IBlogEntryModel Entry2 = new BlogEntryModel
		{
			Key = 2, 
			Entry = @"<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p></div><div><p>Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>
<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p></div><div><p>Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>
<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p></div><div><p>Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>
<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p></div><div><p>Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>", 
			Title = "This is an another amazing title that is also really long.", 
			PostedDate = DateTime.Now.AddHours(-12)
		};

		public static IBlogEntryModel Entry3 = new BlogEntryModel
		{
			Key = 3, 
			Entry = @"<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>
<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>
<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>
<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>", 
			Title = "Here is a really long and drawn-out title setup by me.", 
			PostedDate = DateTime.Now.AddDays(-1)
		};

		public static IBlogEntryModel Entry4 = new BlogEntryModel
		{
			Key = 4, 
			Entry = @"<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p></div><div><p>Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>
<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p></div><div><p>Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>
<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p></div><div><p>Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>
<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p></div><div><p>Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>", 
			Title = "This is an amazing title!", 
			PostedDate = DateTime.Now.AddMonths(-1)

		};

        public static IBlogEntryModel Entry5 = new BlogEntryModel
        {
            Key = 5,
            Entry = @"<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p></div><div><p>Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>
<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p></div><div><p>Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>
<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p></div><div><p>Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>
<div><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p></div><div><p>Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute 
irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p></div>",
            Title = "This is an amazing title #2!",
            PostedDate = DateTime.Now.AddMonths(-1).AddDays(-1)

        };  

		private readonly Dictionary<int, IBlogEntryModel> _blogEntries = new Dictionary<int, IBlogEntryModel>
		{
			{ Entry1.Key, Entry1 },
			{ Entry2.Key, Entry2 },
			{ Entry3.Key, Entry3 }, 
			{ Entry4.Key, Entry4 },
            { Entry5.Key, Entry5 }
		};

		private readonly TagRepository _tagRepository;
		private readonly Dictionary<string, List<int>> _blogEntryTags;

		public BlogEntryRepository()
		{
			_tagRepository = new TagRepository();
			_blogEntryTags = new Dictionary<string, List<int>>
				                 {
					                 {_tagRepository.Tags[0].LookupID, new List<int> {Entry1.Key, Entry2.Key}},
					                 {_tagRepository.Tags[1].LookupID, new List<int> {Entry1.Key, Entry3.Key}},
					                 {_tagRepository.Tags[2].LookupID, new List<int> {Entry4.Key, Entry2.Key}},
                                     {_tagRepository.Tags[3].LookupID, new List<int> {Entry5.Key}},
                                     {_tagRepository.Tags[4].LookupID, new List<int> {Entry5.Key}},
                                     {_tagRepository.Tags[5].LookupID, new List<int> {Entry5.Key}},
				                 };
            Entry1.Tags = new List<ITagModel> { _tagRepository.Tags[0], _tagRepository.Tags[1] }.AsQueryable();
            Entry2.Tags = new List<ITagModel> { _tagRepository.Tags[0], _tagRepository.Tags[2] }.AsQueryable();
            Entry3.Tags = new List<ITagModel> { _tagRepository.Tags[1] }.AsQueryable();
            Entry4.Tags = new List<ITagModel> { _tagRepository.Tags[2] }.AsQueryable();
            Entry5.Tags = new List<ITagModel> { _tagRepository.Tags[3], _tagRepository.Tags[4], _tagRepository.Tags[5] }.AsQueryable();
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

        public IQueryable<IBlogEntryModel> GetBlogEntriesByYear(int year)
        {
            return _blogEntries.Values.Where(b => b.PostedDate.Year == year).AsQueryable();
        }

		public IQueryable<IBlogEntryModel> GetBlogEntriesByTag(string tag)
		{			
			if (string.IsNullOrEmpty(tag))
				throw new ArgumentException("Cannot be null or empty", "tag");

			var blogEntryIDs = _blogEntryTags[tag];
			return _blogEntries.Where(x => blogEntryIDs.Contains(x.Key))
                .Select(y => y.Value).AsQueryable();
		}

		public IBlogEntryModel GetMostRecentBlogEntry()
		{
			return _blogEntries.Values.OrderByDescending(x => x.PostedDate).Take(1).Single();
		}


        public IQueryable<IBlogEntryModel> GetTopMostRecentBlogEntries(int numberOfEntries)
        {
            return _blogEntries.Values.OrderByDescending(x => x.PostedDate).Take(numberOfEntries).AsQueryable();
        }
    }
}
