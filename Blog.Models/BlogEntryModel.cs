using System;
using Blog.Interfaces.Models;

namespace Blog.Models
{
	public class BlogEntryModel : BaseModel, IBlogEntryModel
	{
		new public string KeyName { get { return "Id"; } }
        new public string TableName { get { return "[BlogEntries]"; } }

		public string Title { get; set; }
		public string Entry { get; set; }
		public DateTime PostedDate { get; set; }
	}
}
