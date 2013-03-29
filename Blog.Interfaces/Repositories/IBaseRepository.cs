using System.Linq;
using Blog.Interfaces.Models;

namespace Blog.Interfaces.Repositories
{
	public interface IBaseRepository<T> where T : IBaseModel
	{
		T Get(int id);
		IQueryable<T> All();
	}
}