using TaoLa.Core;
using System;

namespace TaoLa.IServices.QueryModel
{
	public class CouponQuery : QueryBase
	{
		public string CouponName
		{
			get;
			set;
		}

		public long? ShopId
		{
			get;
			set;
		}

		public PlatformType? ShowPlatform
		{
			get;
			set;
		}

		public bool? IsOnlyShowNormal
		{
			get;
			set;
		}

		public bool? IsShowAll
		{
			get;
			set;
		}
	}
}
