using System;

namespace Himall.Model
{
	public abstract class BaseModel
	{
		protected string ImageServerUrl = "";

		public object Id
		{
			get;
			set;
		}
	}
}
