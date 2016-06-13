using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class CouponInfo : BaseModel
	{
		public enum CouponReceiveType
		{
			[Description("店铺首页")]
			ShopIndex,
			[Description("积分兑换")]
			IntegralExchange,
			[Description("主动发放")]
			DirectHair
		}

		public enum CouponReceiveStatus
		{
			Success = 1,
			HasExpired,
			HasLimitOver,
			HasReceiveOver,
			IntegralLess
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

		public CouponInfo.CouponReceiveType ReceiveType
		{
			get;
			set;
		}

		public int NeedIntegral
		{
			get;
			set;
		}

		public DateTime? EndIntegralExchange
		{
			get;
			set;
		}

		public string IntegralCover
		{
			get;
			set;
		}

		public int IsSyncWeiXin
		{
			get;
			set;
		}

		public int WXAuditStatus
		{
			get;
			set;
		}

		public long? CardLogId
		{
			get;
			set;
		}

		public virtual ShopInfo Himall_Shops
		{
			get;
			set;
		}

		public virtual ICollection<CouponRecordInfo> Himall_CouponRecord
		{
			get;
			set;
		}

		public virtual ICollection<CouponSettingInfo> Himall_CouponSetting
		{
			get;
			set;
		}

		public string ShowIntegralCover
		{
			get
			{
				string text = "";
				if (this != null)
				{
					text = this.IntegralCover;
					if (string.IsNullOrWhiteSpace(text))
					{
						if (this.Himall_Shops != null)
						{
							text = this.Himall_Shops.Logo;
						}
					}
				}
				return text;
			}
		}

		[NotMapped]
		public WXCardLogInfo WXCardInfo
		{
			get;
			set;
		}

		[NotMapped]
		public bool FormIsSyncWeiXin
		{
			get;
			set;
		}

		[NotMapped]
		public string FormWXColor
		{
			get;
			set;
		}

		[NotMapped]
		public string FormWXCTit
		{
			get;
			set;
		}

		[NotMapped]
		public string FormWXCSubTit
		{
			get;
			set;
		}

		[NotMapped]
		public bool CanVshopIndex
		{
			get;
			set;
		}

		public CouponInfo()
		{
			this.Himall_CouponRecord = new HashSet<CouponRecordInfo>();
			this.Himall_CouponSetting = new HashSet<CouponSettingInfo>();
		}
	}
}
