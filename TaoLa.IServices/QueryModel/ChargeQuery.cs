using Himall.Model;
using System;

namespace TaoLa.IServices.QueryModel
{
	public class ChargeQuery : QueryBase
	{
		public ChargeDetailInfo.ChargeDetailStatus? ChargeStatus
		{
			get;
			set;
		}

		public long? memberId
		{
			get;
			set;
		}

		public long? ChargeNo
		{
			get;
			set;
		}
	}
}
