using System;

namespace TaoLa.IServices.QueryModel
{
	public class UserProformanceQuery : QueryBase
	{
		public long? UserId
		{
			get;
			set;
		}

		public long? OrderId
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
