
namespace Blog.Interfaces.Models
{
	public interface ITagModel : IBaseModel
	{
		string LookupID { get; set; }
		string Name { get; set; }
	}
}
