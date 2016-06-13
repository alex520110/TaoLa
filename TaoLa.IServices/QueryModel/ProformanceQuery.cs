using System;

namespace TaoLa.IServices.QueryModel
{
	public class ProformanceQuery : QueryBase
	{
		public string UserName
		{
			get;
			set;
		}

		public long? UserId
		{
			get;
			set;
		}

		public DateTime? startTime
		{
			get;
			set;
		}

		public DateTime? endTime
		{
			get;
			set;
		}
	}
}
