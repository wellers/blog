using Blog.Interfaces.Models;

namespace Blog.Models;

public class BlogEntryModel : BaseModel, IBlogEntryModel
{
	public string Title { get; set; } = string.Empty;
	public string Entry { get; set; } = string.Empty;
	public DateTime PostedDate { get; set; }
	public IEnumerable<ITagModel> Tags { get; set; } = [];
}
