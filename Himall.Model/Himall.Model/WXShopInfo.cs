using System;

namespace Himall.Model
{
	public class WXShopInfo : BaseModel
	{
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

		public string AppId
		{
			get;
			set;
		}

		public string AppSecret
		{
			get;
			set;
		}

		public string Token
		{
			get;
			set;
		}

		public string FollowUrl
		{
			get;
			set;
		}
	}
}
