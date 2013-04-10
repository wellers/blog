using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Interfaces.Models;
using Blog.Interfaces.Repositories;
using Blog.Models;

namespace Blog.Data.Mock
{
	public class TagRepository : ITagRepository
	{
		public static ITagModel Tag1 = new TagModel
		{
			Key = 1,
			LookupID = "DOTNET",
			Name = ".NET"
		};

		public static ITagModel Tag2 = new TagModel
		{
			Key = 2,
			LookupID = "CSHARP",
			Name = "C#"
		};

		public static ITagModel Tag3 = new TagModel
		{
			Key = 3,
			LookupID = "WCF",
			Name = "WCF"
		};

		public static ITagModel Tag4 = new TagModel
		{
			Key = 4,
			LookupID = "MISC",
			Name = "Misc"
		};

		public static ITagModel Tag5 = new TagModel
		{
			Key = 5,
			LookupID = "BDD",
			Name = "BDD"
		};

		public static ITagModel Tag6 = new TagModel
		{
			Key = 6,
			LookupID = "TDD",
			Name = "TDD"
		};

		public List<ITagModel> Tags = new List<ITagModel>
		{
			Tag1, Tag2, Tag3, Tag4, Tag5, Tag6
		};

		public ITagModel Get(int id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<ITagModel> All()
		{
			return Tags.AsQueryable();
		}
	}
}
