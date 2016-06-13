using System;
using System.ComponentModel;

namespace Himall.Model
{
	public class SlideAdInfo : BaseModel
	{
		public enum SlideAdType
		{
			[Description("平台首页轮播图")]
			PlatformHome = 1,
			[Description("平台限时购轮播图")]
			PlatformLimitTime,
			[Description("店铺首页轮播图")]
			ShopHome,
			[Description("微店轮播图")]
			VShopHome,
			[Description("微信首页轮播图")]
			WeixinHome,
			[Description("触屏版首页轮播图")]
			WapHome,
			[Description("触屏版微店首页轮播图")]
			WapShopHome,
			[Description("APP首页轮播图")]
			IOSShopHome
		}

		private long _id;

		public string ImageUrl
		{
			get
			{
				return this.ImageServerUrl + this.imageUrl;
			}
			set
			{
				if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(this.ImageServerUrl))
				{
					this.imageUrl = value.Replace(this.ImageServerUrl, "");
				}
				else
				{
					this.imageUrl = value;
				}
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

		public long ShopId
		{
			get;
			set;
		}

		private string imageUrl
		{
			get;
			set;
		}

		public string Url
		{
			get;
			set;
		}

		public long DisplaySequence
		{
			get;
			set;
		}

		public SlideAdInfo.SlideAdType TypeId
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}
	}
}
