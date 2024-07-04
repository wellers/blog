using System.Collections.Generic;
using System.Linq;
using Blog.Data;
using Blog.Data.Dao.Mock;
using Blog.Interfaces;
using Blog.Interfaces.Models;
using Blog.Interfaces.Repositories;
using Machine.Specifications;
using Moq;

namespace Blog.Specs.Repositories
{
	[Subject("TagRepository")]
	public class TagRepositorySpecs
	{
		protected static ITagRepository Repository;
		protected static Mock<IDao<ITagModel>> TagDao;
		protected static IQueryable<ITagModel> AllTags;

		Establish context = () =>
		{
			AllTags = new List<ITagModel>
						{
							MockTagDao.Tag1,
							MockTagDao.Tag2,
							MockTagDao.Tag3,
							MockTagDao.Tag4,
							MockTagDao.Tag5,
							MockTagDao.Tag6
						}.AsQueryable();

			TagDao = new Mock<IDao<ITagModel>>();
			TagDao.Setup(x => x.Get()).Returns(AllTags);

			Repository = new TagRepository(TagDao.Object);
		};
	}

	public class when_requesting_All_tags : TagRepositorySpecs
	{
		private static IList<ITagModel> _actual;

		Because of = () =>
		{
			_actual = Repository.GetAll();
		};

		Machine.Specifications.It should_return_all_tags = () =>
		{
			_actual.ShouldEqual(AllTags.ToList());
		};
	}
}
