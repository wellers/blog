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
        public List<ITagModel> Tags = new List<ITagModel>
        {
            new TagModel
            {
                Key = 1,
                LookupID = "DOTNET",
                Name = ".NET"
            },
            new TagModel
            {
                Key = 2,
                LookupID = "CSHARP",
                Name = "C#"
            },
            new TagModel
            {
                Key = 3,
                LookupID = "WCF",
                Name = "WCF"
            },
            new TagModel
            {
                Key = 4,
                LookupID = "MISC",
                Name = "Misc"
            },
            new TagModel
            {
                Key = 5,
                LookupID = "BDD",
                Name = "BDD"
            },
            new TagModel
            {
                Key = 6,
                LookupID = "TDD",
                Name = "TDD"
            }
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
