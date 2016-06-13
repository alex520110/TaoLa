using System;

namespace Himall.Model
{
	public class FloorTablDetailsInfo : BaseModel
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

		public long TabId
		{
			get;
			set;
		}

		public long ProductId
		{
			get;
			set;
		}

		public virtual ProductInfo Himall_Products
		{
			get;
			set;
		}

		public virtual FloorTablsInfo Himall_FloorTabls
		{
			get;
			set;
		}
	}
}
