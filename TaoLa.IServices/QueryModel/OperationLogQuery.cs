using System;

namespace TaoLa.IServices.QueryModel
{
	public class OperationLogQuery : QueryBase
	{
		public DateTime? StartDate
		{
			get;
			set;
		}

		public DateTime? EndDate
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public long ShopId
		{
			get;
			set;
		}
	}
}
