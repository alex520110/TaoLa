using System;
using System.ComponentModel;

namespace Himall.Model
{
	public class StatisticOrderCommentsInfo : BaseModel
	{
		public enum EnumCommentKey
		{
			[Description("宝贝与描述相符 商家得分")]
			ProductAndDescription = 1,
			[Description("宝贝与描述相符 同行业平均分")]
			ProductAndDescriptionPeer,
			[Description("宝贝与描述相符 同行业商家最高得分")]
			ProductAndDescriptionMax,
			[Description("宝贝与描述相符 同行业商家最低得分")]
			ProductAndDescriptionMin,
			[Description("卖家发货速度 商家得分")]
			SellerDeliverySpeed,
			[Description("卖家发货速度 同行业平均分")]
			SellerDeliverySpeedPeer,
			[Description("卖家发货速度 同行业商家最高得分")]
			SellerDeliverySpeedMax,
			[Description("卖家发货速度 同行业商家最低得分")]
			SellerDeliverySpeedMin,
			[Description("卖家服务态度 商家得分")]
			SellerServiceAttitude,
			[Description("卖家服务态度 同行业平均分")]
			SellerServiceAttitudePeer,
			[Description("卖家服务态度 同行业商家最高得分")]
			SellerServiceAttitudeMax,
			[Description("卖家服务态度 同行业商家最低得分")]
			SellerServiceAttitudeMin
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

		public StatisticOrderCommentsInfo.EnumCommentKey CommentKey
		{
			get;
			set;
		}

		public decimal CommentValue
		{
			get;
			set;
		}

		public virtual ShopInfo Himall_Shops
		{
			get;
			set;
		}
	}
}
