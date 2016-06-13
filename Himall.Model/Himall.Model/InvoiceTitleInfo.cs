using System;

namespace Himall.Model
{
	public class InvoiceTitleInfo : BaseModel
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

		public long UserId
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public sbyte IsDefault
		{
			get;
			set;
		}
	}
}
