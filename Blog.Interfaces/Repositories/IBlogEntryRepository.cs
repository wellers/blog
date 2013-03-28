using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Interfaces.Models;

namespace Blog.Interfaces.Repositories
{
	public interface IBlogEntryRepository : IBaseRepository<IBlogEntryModel>
	{
	}
}
