using System;

namespace Himall.Model
{
	public class ShopBrandsInfo : BaseModel
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

		public long BrandId
		{
			get;
			set;
		}

		public virtual BrandInfo Himall_Brands
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
