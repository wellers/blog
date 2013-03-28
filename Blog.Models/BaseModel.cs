using System;
using Blog.Interfaces;
using Blog.Interfaces.Models;

namespace Blog.Models
{
	public abstract class BaseModel : IHaveKey, IHaveTableName, IBaseModel
	{
		#region IHaveKey Members

		public int Key { get; set; }

		public string KeyName
		{
			get { throw new NotImplementedException(); }
		}
		
		#endregion

		#region IHaveTableName Members

		public string TableName
		{
			get { throw new NotImplementedException(); }
		}

		#endregion
	}
}
