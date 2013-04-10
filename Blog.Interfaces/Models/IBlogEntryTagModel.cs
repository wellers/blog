
namespace Blog.Interfaces.Models
{
	public interface IBlogEntryTagModel : IBaseModel
	{
		int BlogEntryKey { get; set; }
		int TagKey { get; set; }
	}
}
