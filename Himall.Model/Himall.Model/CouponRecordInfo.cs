using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class CouponRecordInfo : BaseModel, IBaseCoupon
	{
		public enum CounponStatuses
		{
			[Description("未使用")]
			Unuse,
			[Description("已使用")]
			Used
		}

		private long _id;

		public new long Id
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
				base.Id = value;
			}
		}

		public long CouponId
		{
			get;
			set;
		}

		public string CounponSN
		{
			get;
			set;
		}

		public DateTime CounponTime
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public long UserId
		{
			get;
			set;
		}

		public DateTime? UsedTime
		{
			get;
			set;
		}

		public long? OrderId
		{
			get;
			set;
		}

		public long ShopId
		{
			get;
			set;
		}

		public string ShopName
		{
			get;
			set;
		}

		public CouponRecordInfo.CounponStatuses CounponStatus
		{
			get;
			set;
		}

		public long? WXCodeId
		{
			get;
			set;
		}

		public virtual CouponInfo Himall_Coupon
		{
			get;
			set;
		}

		public virtual ShopInfo Himall_Shops
		{
			get;
			set;
		}

		[NotMapped]
		public WXCardCodeLogInfo WXCardCodeInfo
		{
			get;
			set;
		}

		[NotMapped]
		public long BaseId
		{
			get
			{
				return this.Id;
			}
		}

		[NotMapped]
		public decimal BasePrice
		{
			get
			{
				return this.Himall_Coupon.Price;
			}
		}

		[NotMapped]
		public string BaseName
		{
			get
			{
				return this.Himall_Coupon.CouponName;
			}
		}

		[NotMapped]
		public CouponType BaseType
		{
			get
			{
				return CouponType.Coupon;
			}
		}

		[NotMapped]
		public string BaseShopName
		{
			get
			{
				return this.ShopName;
			}
		}

		[NotMapped]
		public DateTime BaseEndTime
		{
			get
			{
				return this.Himall_Coupon.EndTime;
			}
		}

		public long BaseShopId
		{
			get
			{
				return this.Himall_Coupon.ShopId;
			}
		}
	}
}
