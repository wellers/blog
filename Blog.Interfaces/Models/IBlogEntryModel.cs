using System;

namespace Blog.Interfaces.Models
{
	public interface IBlogEntryModel : IBaseModel
	{
		string Title { get; set; }

		// TODO : Possibly change this for XML
		string Entry { get; set; }
		DateTime PostedDate { get; set; }
	}
}
