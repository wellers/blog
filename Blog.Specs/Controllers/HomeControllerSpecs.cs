using System.Collections.Generic;
using System.Linq;
using Blog.Controllers;
using Blog.Interfaces.Models;
using Blog.Interfaces.Repositories;
using Blog.Models;
using Machine.Specifications;
using Moq;
using Blog.Data.Dao.Mock;
using System.Web.Mvc;

namespace Blog.Specs.Controllers
{
	[Subject("HomeController")]
	public class HomeControllerSpecs
	{
		protected static ActionResult Result;

		protected static Mock<IBlogEntryRepository> BlogEntryRepository;
		protected static Mock<ITagRepository> TagRepository;
		protected static HomeController Controller;

		Establish context = () =>
		{
			BlogEntryRepository = new Mock<IBlogEntryRepository>();
			TagRepository = new Mock<ITagRepository>();
			Controller = new HomeController(BlogEntryRepository.Object, TagRepository.Object);
		};
	}

	#region Index
	public class when_calling_Index : HomeControllerSpecs
	{
		private static List<IBlogEntryModel> _expected;

		Establish context = () =>
		{
			var entries = new List<IBlogEntryModel>
						{
							MockBlogEntryDao.Entry1,
							MockBlogEntryDao.Entry2,
							MockBlogEntryDao.Entry3,
							MockBlogEntryDao.Entry4
						}.AsQueryable();
			_expected = entries.ToList();

			BlogEntryRepository.Setup(x => x.GetTopMostRecentBlogEntries(Moq.It.IsAny<int>())).Returns(entries);
		};

		Because of = () =>
		{
			Result = Controller.Index();
		};

		Machine.Specifications.It should_return_a_view = () => Result.ShouldBeOfType(typeof(ViewResult));

		Machine.Specifications.It should_return_home_view_model = () =>
		{
			var actual = (ViewResult)Result;
			actual.Model.ShouldBeOfType(typeof(HomeViewModel));
		};

		Machine.Specifications.It should_return_expected_entries = () =>
		{
			var actual = (ViewResult)Result;
			var model = (HomeViewModel)actual.Model;
			model.BlogEntries.ShouldEqual(_expected);
		};
	}
	#endregion

	#region Archive
	public class when_calling_Archive_when_blog_entries_exist_for_the_provided_month_and_year : HomeControllerSpecs
	{
		private static List<IBlogEntryModel> _expected;

		Establish context = () =>
		{
			var entries = new List<IBlogEntryModel>
						{
							MockBlogEntryDao.Entry1, //mocked entries that are always set to this year
						    MockBlogEntryDao.Entry2
						}.AsQueryable();
			_expected = entries.ToList();

			BlogEntryRepository.Setup(x => x.GetBlogEntriesByMonthAndYear(Moq.It.IsAny<int>(), Moq.It.IsAny<int>())).Returns(entries);
		};

		Because of = () =>
		{
			Result = Controller.Archive(Moq.It.IsAny<int>(), Moq.It.IsAny<int>());
		};

		Machine.Specifications.It should_return_a_view = () => Result.ShouldBeOfType(typeof(ViewResult));

		Machine.Specifications.It should_return_home_view_model = () =>
		{
			var actual = (ViewResult)Result;
			actual.Model.ShouldBeOfType(typeof(HomeViewModel));
		};

		Machine.Specifications.It should_return_expected_entries = () =>
		{
			var actual = (ViewResult)Result;
			var model = (HomeViewModel)actual.Model;
			model.BlogEntries.ShouldEqual(_expected);
		};
	}

	public class when_calling_Archive_and_blog_entries_do_not_exist_for_the_provided_month_and_year : HomeControllerSpecs
	{
		private static List<IBlogEntryModel> _expected;

		Establish context = () =>
		{
			var entries = new List<IBlogEntryModel>
						{
							MockBlogEntryDao.Entry1, //mocked entries that are always set to this year
						    MockBlogEntryDao.Entry2
						}.AsQueryable();
			_expected = entries.ToList();

			BlogEntryRepository.Setup(x => x.GetMostRecentBlogEntry()).Returns(MockBlogEntryDao.Entry1);

			IQueryable<IBlogEntryModel> response = new List<IBlogEntryModel>().AsQueryable();
			BlogEntryRepository.Setup(x => x.GetBlogEntriesByMonthAndYear(Moq.It.IsAny<int>(), Moq.It.IsAny<int>()))
				.Returns(() => response) // setup first call to respond with an empty collection and callback to set response for the second call
				.Callback(() => response = entries);
		};

		Because of = () =>
		{
			Result = Controller.Archive(Moq.It.IsAny<int>(), Moq.It.IsAny<int>());
		};

		Machine.Specifications.It should_return_view = () => Result.ShouldBeOfType(typeof(ViewResult));

		Machine.Specifications.It should_return_home_view_model = () =>
		{
			var actual = (ViewResult)Result;
			actual.Model.ShouldBeOfType(typeof(HomeViewModel));
		};

		Machine.Specifications.It should_return_entries_for_most_recent_month = () =>
		{
			var actual = (ViewResult)Result;
			var model = (HomeViewModel)actual.Model;
			model.BlogEntries.ShouldEqual(_expected);
		};
	}
	#endregion

	#region BlogEntry
	public class when_calling_BlogEntry_and_the_provided_blog_entry_exists : HomeControllerSpecs
	{
		private static IBlogEntryModel _expected;

		Establish context = () =>
		{
			_expected = MockBlogEntryDao.Entry1;
			BlogEntryRepository.Setup(x => x.Get(Moq.It.IsAny<int>())).Returns(_expected);
		};

		Because of = () =>
		{
			Result = Controller.BlogEntry(Moq.It.IsAny<int>());
		};

		Machine.Specifications.It should_return_a_view = () => Result.ShouldBeOfType(typeof(ViewResult));

		Machine.Specifications.It should_return_IBlogEntryModel = () =>
		{
			var actual = (ViewResult)Result;
			actual.Model.ShouldBeOfType(typeof(IBlogEntryModel));
		};

		Machine.Specifications.It should_return_expected_entry = () =>
		{
			var actual = (ViewResult)Result;
			var model = (IBlogEntryModel)actual.Model;
			model.ShouldEqual(_expected);
		};
	}

	public class when_calling_BlogEntry_and_the_provided_blog_entry_does_not_exist : HomeControllerSpecs
	{
		private static IBlogEntryModel _expected;

		Establish context = () =>
		{
			_expected = new BlogEntryModel();
			BlogEntryRepository.Setup(x => x.Get(Moq.It.IsAny<int>())).Returns(_expected);
		};

		Because of = () =>
		{
			Result = Controller.BlogEntry(Moq.It.IsAny<int>());
		};

		Machine.Specifications.It should_return_a_view = () => Result.ShouldBeOfType(typeof(ViewResult));

		Machine.Specifications.It should_return_IBlogEntryModel = () =>
		{
			var actual = (ViewResult)Result;
			actual.Model.ShouldBeOfType(typeof(IBlogEntryModel));
		};

		Machine.Specifications.It should_return_no_entries = () =>
		{
			var actual = (ViewResult)Result;
			var model = (IBlogEntryModel)actual.Model;
			model.ShouldEqual(_expected);
		};
	}
	#endregion

	#region Tag
	public class when_calling_Tag_and_blog_entries_exist_for_the_provided_tag : HomeControllerSpecs
	{
		private static List<IBlogEntryModel> _expected;

		Establish context = () =>
		{
			var entries = new List<IBlogEntryModel> { MockBlogEntryDao.Entry1 }.AsQueryable();
			_expected = entries.ToList();
			BlogEntryRepository.Setup(x => x.GetBlogEntriesByTag(Moq.It.IsAny<string>())).Returns(entries);
		};

		Because of = () =>
		{
			Result = Controller.Tag(Moq.It.IsAny<string>());
		};

		Machine.Specifications.It should_return_a_view = () => Result.ShouldBeOfType(typeof(ViewResult));

		Machine.Specifications.It should_return_home_view_model = () =>
		{
			var actual = (ViewResult)Result;
			actual.Model.ShouldBeOfType(typeof(HomeViewModel));
		};

		Machine.Specifications.It should_return_entries_for_the_provided_tag = () =>
		{
			var actual = (ViewResult)Result;
			var model = (HomeViewModel)actual.Model;
			model.BlogEntries.ShouldEqual(_expected);
		};
	}

	public class when_calling_Tag_and_blog_entries_do_not_exist_for_the_provided_tag : HomeControllerSpecs
	{
		private static List<IBlogEntryModel> _expected;

		Establish context = () =>
		{
			var entries = new List<IBlogEntryModel>().AsQueryable();
			_expected = entries.ToList();
			BlogEntryRepository.Setup(x => x.GetBlogEntriesByTag(Moq.It.IsAny<string>())).Returns(entries);
		};

		Because of = () =>
		{
			Result = Controller.Tag(Moq.It.IsAny<string>());
		};

		Machine.Specifications.It should_return_view = () => Result.ShouldBeOfType(typeof(ViewResult));

		Machine.Specifications.It should_return_home_view_model = () =>
		{
			var actual = (ViewResult)Result;
			actual.Model.ShouldBeOfType(typeof(HomeViewModel));
		};

		Machine.Specifications.It should_return_no_entries = () =>
		{
			var actual = (ViewResult)Result;
			var model = (HomeViewModel)actual.Model;
			model.BlogEntries.ShouldEqual(_expected);
		};
	}
	#endregion

	#region About
	public class when_calling_About : HomeControllerSpecs
	{
		Because of = () =>
		{
			Result = Controller.About();
		};

		Machine.Specifications.It should_return_a_view = () => Result.ShouldBeOfType(typeof(ViewResult));
	}
	#endregion

	#region Contact
	public class when_calling_Contact : HomeControllerSpecs
	{
		Because of = () =>
		{
			Result = Controller.Contact();
		};

		Machine.Specifications.It should_return_a_view = () => Result.ShouldBeOfType(typeof(ViewResult));
	}
	#endregion

	#region Tags
	public class when_calling_Tags : HomeControllerSpecs
	{
		private static List<ITagModel> _expected;

		Establish context = () =>
		{
			var tags = new List<ITagModel>
						{
							MockTagDao.Tag1,
							MockTagDao.Tag2,
							MockTagDao.Tag3,
							MockTagDao.Tag4,
							MockTagDao.Tag5,
							MockTagDao.Tag6
						}.AsQueryable().OrderBy(x => x.Name);
			_expected = tags.ToList();
			TagRepository.Setup(x => x.All()).Returns(tags);
		};

		Because of = () =>
		{
			Result = Controller.Tags();
		};

		Machine.Specifications.It should_return_a_partial_view = () => Result.ShouldBeOfType(typeof(PartialViewResult));

		Machine.Specifications.It should_return_tags_view_model = () =>
		{
			var actual = (PartialViewResult)Result;
			actual.Model.ShouldBeOfType(typeof(TagsViewModel));
		};

		Machine.Specifications.It should_return_all_tags = () =>
		{
			var actual = (PartialViewResult)Result;
			var model = (TagsViewModel)actual.Model;
			model.Tags.ShouldEqual(_expected);
		};
	}
	#endregion
}
