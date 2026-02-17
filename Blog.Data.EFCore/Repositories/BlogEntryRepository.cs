using Blog.Interfaces.Models;
using Blog.Interfaces.Repositories;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.EFCore.Repositories;

public class BlogEntryRepository(MongoDbContext context) : IBlogEntryRepository
{
	private IQueryable<Entities.BlogEntryEntity> Query() => context.BlogEntries.AsNoTracking();

	public IBlogEntryModel? Get(object id)
	{
		return Query()
			.Where(b => b.Id.Equals(id))
			.AsEnumerable()
			.Select(Map)
			.SingleOrDefault();
	}

	public IEnumerable<IBlogEntryModel> GetTopMostRecentBlogEntries(int numberOfEntries)
	{
		return Query()
			.OrderByDescending(b => b.PostedDate)
			.Take(numberOfEntries)
			.AsEnumerable()
			.Select(Map)
			.ToList();
	}

	public IBlogEntryModel? GetMostRecentBlogEntry()
	{
		return Query()
			.OrderByDescending(b => b.PostedDate)
			.Take(1)
			.AsEnumerable()
			.Select(Map)
			.FirstOrDefault();
	}

	public IEnumerable<IBlogEntryModel> GetBlogEntriesByYear(int year)
	{
		var start = new DateTime(year, 1, 1);
		var end = start.AddYears(1);

		return Query()
			.Where(b => b.PostedDate >= start && b.PostedDate < end)
			.OrderByDescending(b => b.PostedDate)
			.AsEnumerable()
			.Select(Map)
			.ToList();
	}

	public IEnumerable<IBlogEntryModel> GetBlogEntriesByMonthAndYear(int month, int year)
	{
		var start = new DateTime(year, month, 1);
		var end = start.AddMonths(1);

		return Query()
			.Where(b => b.PostedDate >= start && b.PostedDate < end)
			.OrderByDescending(b => b.PostedDate)
			.AsEnumerable()
			.Select(Map)
			.ToList();
	}

	public IEnumerable<IBlogEntryModel> GetBlogEntriesByTag(string tag)
	{
		if (string.IsNullOrWhiteSpace(tag))
			throw new ArgumentException("Cannot be null or empty", nameof(tag));

		return Query()
			.Where(b => b.Tags.Contains(tag))
			.OrderByDescending(b => b.PostedDate)
			.AsEnumerable()
			.Select(Map)
			.ToList();
	}

	private static BlogEntryModel Map(Entities.BlogEntryEntity b)
	{
		return new BlogEntryModel
		{
			Key = b.Id,
			Title = b.Title,
			Entry = b.Entry,
			PostedDate = b.PostedDate,
			Tags = b.Tags.Select(t => new TagModel
			{
				LookupID = t,
				Name = t
			}).ToList()
		};
	}
}