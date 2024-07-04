using System.Collections.Generic;
using Blog.Interfaces.Models;

namespace Blog.Interfaces.Repositories
{
	public interface IBlogEntryRepository : IBaseRepository<IBlogEntryModel>
	{
		IList<IBlogEntryModel> GetBlogEntriesByYear(int year);
		IList<IBlogEntryModel> GetBlogEntriesByMonthAndYear(int month, int year);
		IList<IBlogEntryModel> GetBlogEntriesByTag(string tag);
		IBlogEntryModel GetMostRecentBlogEntry();
		IList<IBlogEntryModel> GetTopMostRecentBlogEntries(int numberOfEntries);
	}
}
