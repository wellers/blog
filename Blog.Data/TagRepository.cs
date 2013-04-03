using System;
using System.Linq;
using Blog.Data.CodeFirst.Persistence;
using Blog.Interfaces.Models;
using Blog.Interfaces.Repositories;
using Blog.Models;

namespace Blog.Data
{
    public class TagRepository : ITagRepository
    {
        private readonly Context _context = new Context();

        public ITagModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ITagModel> All()
        {
            return _context.Tags.Select(t => new TagModel
            {
                Key = t.Id,
                LookupID = t.LookupID,
                Name = t.Name
            });
        }
    }
}
