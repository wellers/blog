using System.Linq;

namespace Blog.Interfaces
{
	public interface IDao<out T>
	{
		IQueryable<T> Get();
	}
}
