using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Interfaces;
using Blog.Interfaces.Models;
using Blog.Models;

namespace Blog.Data.Dao.Mock
{
    public class MockBlogEntryDao : IDao<IBlogEntryModel>
    {
        #region Mock Blog Entries
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
            Tags = new List<ITagModel> { MockTagDao.Tag1, MockTagDao.Tag2 }.AsQueryable()
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
            PostedDate = DateTime.Now.AddHours(-12),
            Tags = new List<ITagModel> { MockTagDao.Tag1, MockTagDao.Tag3 }.AsQueryable()
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
            PostedDate = DateTime.Now.AddDays(-1),
            Tags = new List<ITagModel> { MockTagDao.Tag2 }.AsQueryable()
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
            PostedDate = DateTime.Now.AddMonths(-1),
            Tags = new List<ITagModel> { MockTagDao.Tag3 }.AsQueryable()
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
            PostedDate = DateTime.Now.AddMonths(-1).AddDays(-1),
            Tags = new List<ITagModel> { MockTagDao.Tag4, MockTagDao.Tag5, MockTagDao.Tag6 }.AsQueryable()
        };          
        #endregion

        private readonly Dictionary<int, IBlogEntryModel> _blogEntries = new Dictionary<int, IBlogEntryModel>
		{
			{ Entry1.Key, Entry1 },
			{ Entry2.Key, Entry2 },
			{ Entry3.Key, Entry3 }, 
			{ Entry4.Key, Entry4 },
            { Entry5.Key, Entry5 }
		};

        public IQueryable<IBlogEntryModel> Get()
        {
            return _blogEntries.Values.AsQueryable();
        }
    }
}
