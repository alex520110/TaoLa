using System;

namespace Himall.Model
{
	public class FloorProductInfo : BaseModel
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

		public int Tab
		{
			get;
			set;
		}

		public long ProductId
		{
			get;
			set;
		}

		public virtual HomeFloorInfo HomeFloorInfo
		{
			get;
			set;
		}

		public virtual ProductInfo ProductInfo
		{
			get;
			set;
		}
	}
}
