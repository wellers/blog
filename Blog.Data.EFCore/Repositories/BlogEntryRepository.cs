using Blog.Interfaces.Models;
using Blog.Interfaces.Repositories;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.EFCore.Repositories;

public class BlogEntryRepository(BlogDbContext context) : IBlogEntryRepository
{
	private IQueryable<IBlogEntryModel> All()
    {
        return context.BlogEntries
            .Include(b => b.BlogEntryTags)
            .ThenInclude(bt => bt.Tag)
            .Select(b => new BlogEntryModel
            {
                Key = b.Id,
                Title = b.Title,
                Entry = b.Entry,
                PostedDate = b.PostedDate,
                Tags = b.BlogEntryTags
                    .Select(bt => bt.Tag)
                    .Select(t => new TagModel
                    {
                        Key = t.Id,
                        LookupID = t.LookupID,
                        Name = t.Name
                    })
                    .ToList()
            });
    }

	public IBlogEntryModel Get(int id) => All().SingleOrDefault(b => b.Key == id);

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

        var normalized = tag;

        var tagId = context.Tags
            .Where(t => t.LookupID == normalized)
            .Select(t => t.Id)
            .Single();

        var blogEntryIds = context.BlogEntryTags
            .Where(bt => bt.TagId == tagId)
            .Select(bt => bt.BlogEntryId)
            .ToList();

        return All()
            .Where(b => blogEntryIds.Contains(b.Key))
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
