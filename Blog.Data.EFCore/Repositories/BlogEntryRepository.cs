using Blog.Interfaces.Models;
using Blog.Interfaces.Repositories;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.EFCore.Repositories;

public class BlogEntryRepository(MongoDbContext context) : IBlogEntryRepository
{
	private IQueryable<IBlogEntryModel> All()
    {
        return context.BlogEntries
            .AsEnumerable()
            .Select(b => new BlogEntryModel
            {
                Key = b.Id,
                Title = b.Title,
                Entry = b.Entry,
                PostedDate = b.PostedDate,
                Tags = b.Tags.Select(t => new TagModel
                    {
                        LookupID = t,
                        Name = t
                    })
                    .ToList()
			})
            .AsQueryable();
    }

	public IBlogEntryModel Get(object id) => All().SingleOrDefault(b => b.Key.Equals(id));

	public IList<IBlogEntryModel> GetBlogEntriesByYear(int year)
    {
        return All()
            .Where(b => b.PostedDate.Year == year)
            .OrderByDescending(b => b.PostedDate)
            .ToList();
    }

    public IList<IBlogEntryModel> GetBlogEntriesByMonthAndYear(int month, int year)
    {
        return All()
            .Where(b => b.PostedDate.Month == month && b.PostedDate.Year == year)
            .OrderByDescending(b => b.PostedDate)
            .ToList();
    }

    public IList<IBlogEntryModel> GetBlogEntriesByTag(string tag)
    {
        if (string.IsNullOrEmpty(tag))
            throw new ArgumentException("Cannot be null or empty", nameof(tag));

        return All()
            .Where(b => b.Tags.Select(t => t.LookupID).Contains(tag))
            .OrderByDescending(b => b.PostedDate)
            .ToList();
    }

    public IBlogEntryModel GetMostRecentBlogEntry() => GetTopMostRecentBlogEntries(1).Single();

    public IList<IBlogEntryModel> GetTopMostRecentBlogEntries(int numberOfEntries)
    {
        return All()
            .OrderByDescending(b => b.PostedDate)
            .Take(numberOfEntries)
            .ToList();
    }
}
