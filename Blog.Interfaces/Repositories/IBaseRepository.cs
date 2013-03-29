using System.Collections.Generic;
using Blog.Interfaces.Models;
using System.Linq;

namespace Blog.Interfaces.Repositories
{
	public interface IBaseRepository<T> where T : IBaseModel
	{
		T Get(int id);
		IQueryable<T> All();
	}
}