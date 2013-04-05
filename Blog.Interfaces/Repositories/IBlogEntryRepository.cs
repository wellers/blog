using System.Linq;
using Blog.Interfaces.Models;

namespace Blog.Interfaces.Repositories
{
	public interface IBlogEntryRepository : IBaseRepository<IBlogEntryModel>
	{
		IQueryable<IBlogEntryModel> GetBlogEntriesByMonthAndYear(int month, int year);
        IQueryable<IBlogEntryModel> GetBlogEntriesByTag(string tag);
		IBlogEntryModel GetMostRecentBlogEntry();
        IQueryable<IBlogEntryModel> GetTopMostRecentBlogEntries(int numberOfEntries);
	}
}
