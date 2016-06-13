using System;

namespace TaoLa.IServices.QueryModel
{
	public class CouponRecordQuery : QueryBase
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

		public long? ShopId
		{
			get;
			set;
		}

		public int? Status
		{
			get;
			set;
		}

		public long? CouponId
		{
			get;
			set;
		}
	}
}
