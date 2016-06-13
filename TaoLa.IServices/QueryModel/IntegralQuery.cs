using System;

namespace TaoLa.IServices.QueryModel
{
	public class IntegralQuery : QueryBase
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
	}
}
