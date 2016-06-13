using System;

namespace Himall.Model
{
	public class FloorCategoryInfo : BaseModel
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

		public long CategoryId
		{
			get;
			set;
		}

		public int Depth
		{
			get;
			set;
		}

		public virtual CategoryInfo CategoryInfo
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
