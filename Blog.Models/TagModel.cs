using Blog.Interfaces.Models;

namespace Blog.Models;

public class TagModel : BaseModel, ITagModel
{
	public string LookupID { get; set; } = string.Empty;
	public string Name { get; set; } = string.Empty;
}
