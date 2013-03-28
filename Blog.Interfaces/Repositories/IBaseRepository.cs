using System.Collections.Generic;
using Blog.Interfaces.Models;

namespace Blog.Interfaces.Repositories
{
	public interface IBaseRepository<T> where T : IBaseModel
	{
		T Get(int id);
		IEnumerable<T> All();
	}
}