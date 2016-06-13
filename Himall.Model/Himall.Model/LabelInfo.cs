using System;

namespace Himall.Model
{
	public class LabelInfo : BaseModel
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

		public string LabelName
		{
			get;
			set;
		}
	}
}
