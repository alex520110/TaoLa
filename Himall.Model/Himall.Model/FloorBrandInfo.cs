using System;

namespace Himall.Model
{
	public class FloorBrandInfo : BaseModel
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

		public long FloorId
		{
			get;
			set;
		}

		public long BrandId
		{
			get;
			set;
		}

		public virtual BrandInfo BrandInfo
		{
			get;
			set;
		}

		public virtual HomeFloorInfo HomeFloorInfo
		{
			get;
			set;
		}
	}
}
