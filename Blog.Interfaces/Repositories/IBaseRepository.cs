using Blog.Interfaces.Models;

namespace Blog.Interfaces.Repositories
{
	public interface IBaseRepository<out T> where T : IBaseModel
	{
		T Get(int id);
	}
}