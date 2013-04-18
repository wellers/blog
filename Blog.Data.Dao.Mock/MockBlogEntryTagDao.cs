using System.Collections.Generic;
using System.Linq;
using Blog.Interfaces;
using Blog.Interfaces.Models;
using Blog.Models;

namespace Blog.Data.Dao.Mock
{
    public class MockBlogEntryTagDao : IDao<IBlogEntryTagModel>
    {
        private readonly Dictionary<int, IBlogEntryTagModel> _blogEntryTags = new Dictionary<int, IBlogEntryTagModel>
		{
			{ 1, new BlogEntryTagModel { Key = 1, BlogEntryKey = MockBlogEntryDao.Entry1.Key, TagKey = MockTagDao.Tag1.Key } },
            { 2, new BlogEntryTagModel { Key = 2, BlogEntryKey = MockBlogEntryDao.Entry1.Key, TagKey = MockTagDao.Tag2.Key } },

            { 3, new BlogEntryTagModel { Key = 3, BlogEntryKey = MockBlogEntryDao.Entry2.Key, TagKey = MockTagDao.Tag1.Key } },
			{ 4, new BlogEntryTagModel { Key = 4, BlogEntryKey = MockBlogEntryDao.Entry2.Key, TagKey = MockTagDao.Tag3.Key } },
			
            { 5, new BlogEntryTagModel { Key = 5, BlogEntryKey = MockBlogEntryDao.Entry3.Key, TagKey = MockTagDao.Tag2.Key } },

            { 6, new BlogEntryTagModel { Key = 6, BlogEntryKey = MockBlogEntryDao.Entry4.Key, TagKey = MockTagDao.Tag3.Key } },

            { 7, new BlogEntryTagModel { Key = 7, BlogEntryKey = MockBlogEntryDao.Entry5.Key, TagKey = MockTagDao.Tag4.Key } },
            { 8, new BlogEntryTagModel { Key = 8, BlogEntryKey = MockBlogEntryDao.Entry5.Key, TagKey = MockTagDao.Tag5.Key } },
            { 9, new BlogEntryTagModel { Key = 9, BlogEntryKey = MockBlogEntryDao.Entry5.Key, TagKey = MockTagDao.Tag6.Key } }
		};

        public IQueryable<IBlogEntryTagModel> Get()
        {
            return _blogEntryTags.Values.AsQueryable();
        }
    }
}
