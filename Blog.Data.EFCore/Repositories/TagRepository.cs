using Blog.Interfaces.Models;
using Blog.Interfaces.Repositories;
using Blog.Models;

namespace Blog.Data.EFCore.Repositories;

public class TagRepository(BlogDbContext context) : ITagRepository
{
	public ITagModel Get(int id)
    {
        var entity = context.Tags.SingleOrDefault(t => t.Id == id);
        if (entity == null) return null;

        return new TagModel
        {
            Key = entity.Id,
            LookupID = entity.LookupID,
            Name = entity.Name
        };
    }

    public IList<ITagModel> GetAll()
    {
        return context.Tags
            .OrderBy(t => t.Name)
            .Select(t => new TagModel
            {
                Key = t.Id,
                LookupID = t.LookupID,
                Name = t.Name
            })
            .Cast<ITagModel>()
            .ToList();
    }
}
