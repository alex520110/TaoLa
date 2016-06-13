using System;

namespace Himall.Model
{
	public interface IBaseCoupon
	{
		long BaseId
		{
			get;
		}

		decimal BasePrice
		{
			get;
		}

		string BaseName
		{
			get;
		}

		CouponType BaseType
		{
			get;
		}

		string BaseShopName
		{
			get;
		}

		DateTime BaseEndTime
		{
			get;
		}

		long BaseShopId
		{
			get;
		}
	}
}
