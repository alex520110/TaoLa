using Himall.Model;
using System;

namespace TaoLa.IServices.QueryModel
{
	public class CapitalDetailQuery : QueryBase
	{
		public CapitalDetailInfo.CapitalDetailType? capitalType
		{
			get;
			set;
		}

		public long memberId
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
