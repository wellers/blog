using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Data;
using Blog.Interfaces;
using Blog.Interfaces.Models;
using Blog.Interfaces.Repositories;
using Blog.Models;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;
using Blog.Data.Dao.Mock;

namespace Blog.Specs.Repositories
{
    [Subject("BlogEntryRepository")]
	public class BlogEntryRepositorySpecs
	{        
		protected static IBlogEntryRepository Repository;
		protected static Mock<IDao<IBlogEntryModel>> BlogEntryDao;
		protected static Mock<IDao<ITagModel>> TagDao;
		protected static Mock<IDao<IBlogEntryTagModel>> BlogEntryTagDao;

		protected static IQueryable<IBlogEntryModel> AllEntries;

		Establish context = () =>
		{
			#region BlogEntryDao Setup
			AllEntries = new List<IBlogEntryModel>
						{
							MockBlogEntryDao.Entry1,
							MockBlogEntryDao.Entry2,
							MockBlogEntryDao.Entry3,
							MockBlogEntryDao.Entry4
						}.AsQueryable();

			BlogEntryDao = new Mock<IDao<IBlogEntryModel>>();
			BlogEntryDao.Setup(x => x.Get()).Returns(AllEntries);
			#endregion

			#region TagDao Setup
			var tags = new List<ITagModel>
						{
							MockTagDao.Tag1,
							MockTagDao.Tag2,
							MockTagDao.Tag3,
							MockTagDao.Tag4,
							MockTagDao.Tag5,
							MockTagDao.Tag6
						}.AsQueryable();

			TagDao = new Mock<IDao<ITagModel>>();
			TagDao.Setup(x => x.Get()).Returns(tags);
			#endregion

			#region BlogEntryTagsDao Setup
			var blogEntryTags = new List<IBlogEntryTagModel>
			{
				new BlogEntryTagModel { Key = 1, BlogEntryKey = 1, TagKey = 1 },
				new BlogEntryTagModel { Key = 2, BlogEntryKey = 1, TagKey = 2 },
				new BlogEntryTagModel { Key = 3, BlogEntryKey = 2, TagKey = 1 },
				new BlogEntryTagModel { Key = 4, BlogEntryKey = 2, TagKey = 3 },
				new BlogEntryTagModel { Key = 5, BlogEntryKey = 3, TagKey = 2 },
				new BlogEntryTagModel { Key = 6, BlogEntryKey = 4, TagKey = 3 },
				new BlogEntryTagModel { Key = 7, BlogEntryKey = 5, TagKey = 4 },
				new BlogEntryTagModel { Key = 8, BlogEntryKey = 5, TagKey = 5 },
				new BlogEntryTagModel { Key = 9, BlogEntryKey = 5, TagKey = 6 },
			}.AsQueryable();

			BlogEntryTagDao = new Mock<IDao<IBlogEntryTagModel>>();
			BlogEntryTagDao.Setup(x => x.Get()).Returns(blogEntryTags);
			#endregion

			Repository = new BlogEntryRepository(BlogEntryDao.Object, TagDao.Object, BlogEntryTagDao.Object);
		};
	}

	#region All
	public class when_calling_All : BlogEntryRepositorySpecs
	{
		private static IQueryable<IBlogEntryModel> _actual;

		Because of = () =>
		{
			_actual = Repository.All();
		};

		It should_contain_all_blog_entries = () => _actual.ShouldEqual(AllEntries);
	}
	#endregion

	#region Get
	public class when_calling_Get_for_a_blog_entry_that_exists : BlogEntryRepositorySpecs
	{
		private static IBlogEntryModel _actual;
		private static IBlogEntryModel _expected;

		Because of = () =>
		{
			_expected = AllEntries.ToList()[0];
			_actual = Repository.Get(_expected.Key);
		};

		It should_contain_expected_blog_entries = () => _actual.ShouldEqual(_expected);
	}
	#endregion

	#region GetBlogEntriesByMonthAndYear
	public class when_calling_GetBlogEntriesByMonthAndYear : BlogEntryRepositorySpecs
	{
		private static IQueryable<IBlogEntryModel> _actual;
		private static IQueryable<IBlogEntryModel> _expected;

		Because of = () =>
		{
			_expected = (new List<IBlogEntryModel> 
			{ 
				AllEntries.ToList()[0], 
				AllEntries.ToList()[1], 
				AllEntries.ToList()[2] 
			}).AsQueryable();
			_actual = Repository.GetBlogEntriesByMonthAndYear(DateTime.Now.Month, DateTime.Now.Year);
		};

		It should_contain_expected_blog_entries = () => _actual.ShouldEqual(_expected);
	}
	#endregion

	#region GetBlogEntriesByTag
	public class when_calling_GetBlogEntriesByTag : BlogEntryRepositorySpecs
	{
		private static IQueryable<IBlogEntryModel> _actual;
		private static IQueryable<IBlogEntryModel> _expected;

		Because of = () =>
		{
			_expected = (new List<IBlogEntryModel> 
			{ 
				AllEntries.ToList()[0], 
				AllEntries.ToList()[1], 
			}).AsQueryable();
			_actual = Repository.GetBlogEntriesByTag("DOTNET");
		};

		It should_contain_expected_blog_entries = () => _actual.ShouldEqual(_expected);
	}
	#endregion

	#region GetMostRecentBlogEntry
	public class when_calling_GetMostRecentBlogEntry : BlogEntryRepositorySpecs
	{
		private static IBlogEntryModel _actual;
		private static IBlogEntryModel _expected;

		Because of = () =>
		{
			_expected = AllEntries.ToList()[0];
			_actual = Repository.GetMostRecentBlogEntry();
		};

		It should_contain_expected_blog_entries = () => _actual.ShouldEqual(_expected);
	}
	#endregion

	#region GetTopMostRecentBlogEntries
	public class when_calling_GetTopMostRecentBlogEntries : BlogEntryRepositorySpecs
	{
		private static IQueryable<IBlogEntryModel> _actual;
		private static IQueryable<IBlogEntryModel> _expected;
		private static int _expectedCount = 3;

		Because of = () =>
		{
			_expected = (new List<IBlogEntryModel> 
			{ 
				AllEntries.ToList()[0], 
				AllEntries.ToList()[1], 
				AllEntries.ToList()[2] 
			}).AsQueryable();
			_actual = Repository.GetTopMostRecentBlogEntries(_expectedCount);
		};

		It should_not_be_empty = () => _actual.ShouldNotBeEmpty();

		It should_contain_only_three_items = () => _actual.ToList().Count().ShouldEqual(_expectedCount);

		It should_contain_expected_blog_entries = () => _actual.ShouldContainOnly(_expected);
	}
	#endregion
}