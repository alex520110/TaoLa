using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class ShopCategoryInfo : BaseModel
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

		public long ParentCategoryId
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public long DisplaySequence
		{
			get;
			set;
		}

		public bool IsShow
		{
			get;
			set;
		}

		public virtual ICollection<ProductShopCategoryInfo> ProductShopCategoryInfo
		{
			get;
			set;
		}

		public ShopCategoryInfo()
		{
			this.ProductShopCategoryInfo = new HashSet<ProductShopCategoryInfo>();
		}
	}
}
