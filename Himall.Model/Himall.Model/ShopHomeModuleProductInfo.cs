using System;

namespace Himall.Model
{
	public class ShopHomeModuleProductInfo : BaseModel
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

		public long HomeModuleId
		{
			get;
			set;
		}

		public long ProductId
		{
			get;
			set;
		}

		public int DisplaySequence
		{
			get;
			set;
		}

		public virtual ProductInfo ProductInfo
		{
			get;
			set;
		}

		public virtual ShopHomeModuleInfo ShopHomeModuleInfo
		{
			get;
			set;
		}
	}
}
