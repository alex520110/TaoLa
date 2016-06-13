using System;

namespace Himall.Model
{
	public class MemberLabelInfo : BaseModel
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

		public long MemId
		{
			get;
			set;
		}

		public long LabelId
		{
			get;
			set;
		}
	}
}
