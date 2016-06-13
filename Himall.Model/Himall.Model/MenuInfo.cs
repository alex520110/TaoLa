using Himall.Core;
using System;
using System.ComponentModel;

namespace Himall.Model
{
	public class MenuInfo : BaseModel
	{
		public enum UrlTypes
		{
			[Description("")]
			Nothing,
			[Description("首页")]
			ShopHome,
			[Description("微店")]
			WeiStore,
			[Description("分类")]
			ShopCategory,
			[Description("个人中心")]
			MemberCenter,
			[Description("购物车")]
			ShopCart,
			[Description("")]
			Linkage
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

		public long ParentId
		{
			get;
			set;
		}

		public long ShopId
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public string Url
		{
			get;
			set;
		}

		public short Depth
		{
			get;
			set;
		}

		public short Sequence
		{
			get;
			set;
		}

		public string FullIdPath
		{
			get;
			set;
		}

		public PlatformType Platform
		{
			get;
			set;
		}

		public MenuInfo.UrlTypes? UrlType
		{
			get;
			set;
		}

		public virtual ShopInfo Shop
		{
			get;
			set;
		}
	}
}
