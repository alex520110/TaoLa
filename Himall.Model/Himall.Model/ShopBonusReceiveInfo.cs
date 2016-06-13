using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class ShopBonusReceiveInfo : BaseModel, IBaseCoupon
	{
		public enum ReceiveState
		{
			[Description("未使用")]
			NotUse = 1,
			[Description("已使用")]
			Use,
			[Description("已过期")]
			Expired
		}

		private long _id;

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
				return this.Price.Value;
			}
		}

		[NotMapped]
		public string BaseName
		{
			get
			{
				return this.Himall_ShopBonusGrant.Himall_ShopBonus.Name;
			}
		}

		[NotMapped]
		public CouponType BaseType
		{
			get
			{
				return CouponType.ShopBonus;
			}
		}

		[NotMapped]
		public string BaseShopName
		{
			get
			{
				return this.Himall_ShopBonusGrant.Himall_ShopBonus.Himall_Shops.ShopName;
			}
		}

		[NotMapped]
		public DateTime BaseEndTime
		{
			get
			{
				return this.Himall_ShopBonusGrant.Himall_ShopBonus.BonusDateEnd;
			}
		}

		public long BaseShopId
		{
			get
			{
				return this.Himall_ShopBonusGrant.Himall_ShopBonus.ShopId;
			}
		}

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

		public long BonusGrantId
		{
			get;
			set;
		}

		public string OpenId
		{
			get;
			set;
		}

		public decimal? Price
		{
			get;
			set;
		}

		public ShopBonusReceiveInfo.ReceiveState State
		{
			get;
			set;
		}

		public DateTime? ReceiveTime
		{
			get;
			set;
		}

		public DateTime? UsedTime
		{
			get;
			set;
		}

		public long? UserId
		{
			get;
			set;
		}

		public long? UsedOrderId
		{
			get;
			set;
		}

		public string WXName
		{
			get;
			set;
		}

		public string WXHead
		{
			get;
			set;
		}

		public virtual UserMemberInfo Himall_Members
		{
			get;
			set;
		}

		public virtual ShopBonusGrantInfo Himall_ShopBonusGrant
		{
			get;
			set;
		}
	}
}
