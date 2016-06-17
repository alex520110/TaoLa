using TaoLa.Core;
using System;
using System.ComponentModel;

namespace Himall.Model
{
	public class BannerInfo : BaseModel
	{
		public enum BannerUrltypes
		{
			[Description("链接")]
			Link,
			[Description("全部商品")]
			AllProducts,
			[Description("商品分类")]
			Category,
			[Description("店铺简介")]
			VShopIntroduce
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

		public string Name
		{
			get;
			set;
		}

		public int Position
		{
			get;
			set;
		}

		public long DisplaySequence
		{
			get;
			set;
		}

		public string Url
		{
			get;
			set;
		}

		public PlatformType Platform
		{
			get;
			set;
		}

		public BannerInfo.BannerUrltypes UrlType
		{
			get;
			set;
		}
	}
}
