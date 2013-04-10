using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Blog.Interfaces.Models;
using Blog.Interfaces;
using Moq;
using Blog.Interfaces.Repositories;
using Blog.Data;

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
							Data.Mock.TagRepository.Tag1,
							Data.Mock.TagRepository.Tag2,
							Data.Mock.TagRepository.Tag3,
							Data.Mock.TagRepository.Tag4,
							Data.Mock.TagRepository.Tag5,
							Data.Mock.TagRepository.Tag6
						}.AsQueryable();

            TagDao = new Mock<IDao<ITagModel>>();
            TagDao.Setup(x => x.Get()).Returns(AllTags);

            Repository = new TagRepository(TagDao.Object);
        };
    }

    public class when_requesting_All_tags : TagRepositorySpecs
    {
        private static IQueryable<ITagModel> _actual;

        Because of = () =>
        {
            _actual = Repository.All();
        };

        Machine.Specifications.It should_return_all_tags = () =>
        {
            _actual.ShouldEqual(AllTags);
        };
    }
}
