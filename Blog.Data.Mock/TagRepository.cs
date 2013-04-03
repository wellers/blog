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
                Key = 1,
                LookupID = "CSHARP",
                Name = "C#"
            },
            new TagModel
            {
                Key = 1,
                LookupID = "WCF",
                Name = "WCF"
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
