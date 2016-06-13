using System;

namespace Himall.Model
{
	public class MemberSignInInfo : BaseModel
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

		public DateTime? LastSignTime
		{
			get;
			set;
		}

		public int DurationDay
		{
			get;
			set;
		}

		public int DurationDaySum
		{
			get;
			set;
		}

		public long SignDaySum
		{
			get;
			set;
		}
	}
}
