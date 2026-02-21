using Blog.Interfaces.Models;

namespace Blog.Interfaces.Repositories;

public interface IBlogEntryRepository : IBaseRepository<IBlogEntryModel>
{
	IReadOnlyList<IBlogEntryModel> GetBlogEntriesByYear(int year);
	IReadOnlyList<IBlogEntryModel> GetBlogEntriesByMonthAndYear(int month, int year);
	IReadOnlyList<IBlogEntryModel> GetBlogEntriesByTag(string tag);
	IBlogEntryModel? GetMostRecentBlogEntry();
	IReadOnlyList<IBlogEntryModel> GetTopMostRecentBlogEntries(int numberOfEntries);
}
