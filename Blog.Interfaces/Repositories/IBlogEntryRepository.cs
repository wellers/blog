using Blog.Interfaces.Models;

namespace Blog.Interfaces.Repositories;

public interface IBlogEntryRepository : IBaseRepository<IBlogEntryModel>
{
	IEnumerable<IBlogEntryModel> GetBlogEntriesByYear(int year);
	IEnumerable<IBlogEntryModel> GetBlogEntriesByMonthAndYear(int month, int year);
	IEnumerable<IBlogEntryModel> GetBlogEntriesByTag(string tag);
	IBlogEntryModel GetMostRecentBlogEntry();
	IEnumerable<IBlogEntryModel> GetTopMostRecentBlogEntries(int numberOfEntries);
}
