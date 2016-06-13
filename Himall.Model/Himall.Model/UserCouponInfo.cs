using System;

namespace Himall.Model
{
	public class UserCouponInfo : IBaseCoupon
	{
		public long UserId
		{
			get;
			set;
		}

		public long CouponId
		{
			get;
			set;
		}

		public long ShopId
		{
			get;
			set;
		}

		public long? VShopId
		{
			get;
			set;
		}

		public string ShopName
		{
			get;
			set;
		}

		public string ShopLogo
		{
			get;
			set;
		}

		public decimal Price
		{
			get;
			set;
		}

		public int PerMax
		{
			get;
			set;
		}

		public decimal OrderAmount
		{
			get;
			set;
		}

		public int Num
		{
			get;
			set;
		}

		public DateTime StartTime
		{
			get;
			set;
		}

		public DateTime EndTime
		{
			get;
			set;
		}

		public string CouponName
		{
			get;
			set;
		}

		public DateTime CreateTime
		{
			get;
			set;
		}

		public DateTime? UseTime
		{
			get;
			set;
		}

		public CouponRecordInfo.CounponStatuses UseStatus
		{
			get;
			set;
		}

		public long? OrderId
		{
			get;
			set;
		}

		public VShopInfo VShop
		{
			get;
			set;
		}

		public long BaseId
		{
			get
			{
				return this.CouponId;
			}
		}

		public decimal BasePrice
		{
			get
			{
				return this.Price;
			}
		}

		public string BaseName
		{
			get
			{
				return this.CouponName;
			}
		}

		public CouponType BaseType
		{
			get
			{
				return CouponType.Coupon;
			}
		}

		public string BaseShopName
		{
			get
			{
				return this.ShopName;
			}
		}

		public DateTime BaseEndTime
		{
			get
			{
				return this.EndTime;
			}
		}

		public long BaseShopId
		{
			get
			{
				return this.ShopId;
			}
		}
	}
}
