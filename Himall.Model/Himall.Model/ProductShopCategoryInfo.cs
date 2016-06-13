using System;

namespace Himall.Model
{
	public class ProductShopCategoryInfo : BaseModel
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

		public long ProductId
		{
			get;
			set;
		}

		public long ShopCategoryId
		{
			get;
			set;
		}

		public virtual ProductInfo ProductInfo
		{
			get;
			set;
		}

		public virtual ShopCategoryInfo ShopCategoryInfo
		{
			get;
			set;
		}
	}
}
