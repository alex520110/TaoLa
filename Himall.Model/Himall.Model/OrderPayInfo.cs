using System;

namespace Himall.Model
{
	public class OrderPayInfo : BaseModel
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

		public long OrderId
		{
			get;
			set;
		}

		public long PayId
		{
			get;
			set;
		}

		public bool PayState
		{
			get;
			set;
		}

		public DateTime? PayTime
		{
			get;
			set;
		}
	}
}
