using System;

namespace TaoLa.IServices.QueryModel
{
	public class CollocationQuery : QueryBase
	{
		public string Title
		{
			get;
			set;
		}

		public long? ShopId
		{
			get;
			set;
		}
	}
}
