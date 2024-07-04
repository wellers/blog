using System.Collections.Generic;
using Blog.Interfaces.Models;

namespace Blog.Interfaces.Repositories
{
	public interface ITagRepository : IBaseRepository<ITagModel>
	{
		IList<ITagModel> GetAll();
	}
}
