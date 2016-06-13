using Himall.Model;
using System;

namespace TaoLa.IServices.QueryModel
{
	public class ApplyWithDrawQuery : QueryBase
	{
		public ApplyWithDrawInfo.ApplyWithDrawStatus? withDrawStatus
		{
			get;
			set;
		}

		public long? memberId
		{
			get;
			set;
		}

		public long? withDrawNo
		{
			get;
			set;
		}
	}
}
