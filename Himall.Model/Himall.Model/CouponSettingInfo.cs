using TaoLa.Core;
using System;

namespace Himall.Model
{
	public class CouponSettingInfo : BaseModel
	{
		private int _id;

		public new int Id
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

		public PlatformType PlatForm
		{
			get;
			set;
		}

		public long CouponID
		{
			get;
			set;
		}

		public int? Display
		{
			get;
			set;
		}

		public virtual CouponInfo Himall_Coupon
		{
			get;
			set;
		}
	}
}
