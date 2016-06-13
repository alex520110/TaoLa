using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class OrderCreateAdditional
	{
		public DateTime CreateDate
		{
			get;
			set;
		}

		public ShippingAddressInfo Address
		{
			get;
			set;
		}

		public IEnumerable<CouponRecordInfo> Coupons
		{
			get;
			set;
		}

		public IEnumerable<BaseAdditionalCoupon> BaseCoupons
		{
			get;
			set;
		}

		public decimal IntegralTotal
		{
			get;
			set;
		}

		public bool IsEnableDistribution
		{
			get;
			set;
		}
	}
}
