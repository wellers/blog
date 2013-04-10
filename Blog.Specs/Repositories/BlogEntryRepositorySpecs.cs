using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Data;
using Blog.Interfaces;
using Blog.Interfaces.Models;
using Blog.Interfaces.Repositories;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Blog.Specs.Repositories
{
	public class BlogEntryRepositorySpecs
	{
		protected static Mock<IDao<IBlogEntryModel>> BlogEntryDao;
		protected static IBlogEntryRepository Repository;
		protected static IQueryable<IBlogEntryModel> AllEntries;

		Establish context = () =>
		{
			AllEntries = new List<IBlogEntryModel>
					    {
						    Data.Mock.BlogEntryRepository.Entry1,
						    Data.Mock.BlogEntryRepository.Entry2,
						    Data.Mock.BlogEntryRepository.Entry3,
						    Data.Mock.BlogEntryRepository.Entry4
					    }.AsQueryable();

			BlogEntryDao = new Mock<IDao<IBlogEntryModel>>();
			BlogEntryDao.Setup(x => x.Get()).Returns(AllEntries);
			Repository = new BlogEntryRepository();
		};
	}

	public class when_calling_All : BlogEntryRepositorySpecs
	{
		private static IQueryable<IBlogEntryModel> _result;

		Because of = () =>
		{
			_result = Repository.All();
		};

		It should_contain_all_blog_entries = () => _result.ShouldEqual(AllEntries);
	}
}