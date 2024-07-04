using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Interfaces;
using Blog.Interfaces.Models;
using Blog.Interfaces.Repositories;

namespace Blog.Data
{
	public class TagRepository : ITagRepository
	{
		private IDao<ITagModel> _tagDao;
		
		public TagRepository(IDao<ITagModel> tagDao)
		{
			_tagDao = tagDao;
		}

		public ITagModel Get(int id)
		{
			throw new NotImplementedException();
		}

		public IList<ITagModel> GetAll()
		{
			return All().OrderBy(t => t.Name).ToList();
		}

		private IQueryable<ITagModel> All()
		{
			return _tagDao.Get();
		}
	}
}
