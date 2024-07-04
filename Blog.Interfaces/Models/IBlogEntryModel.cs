using System;
using System.Linq;

namespace Blog.Interfaces.Models
{
	public interface IBlogEntryModel : IBaseModel
	{
		string Title { get; set; }
		string Entry { get; set; }
		DateTime PostedDate { get; set; }
		IQueryable<ITagModel> Tags { get; set; }
	}
}
