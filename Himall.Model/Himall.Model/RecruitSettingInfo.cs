using System;

namespace Himall.Model
{
	public class RecruitSettingInfo : BaseModel
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

		public bool Enable
		{
			get;
			set;
		}

		public bool MustMobile
		{
			get;
			set;
		}

		public bool MustAddress
		{
			get;
			set;
		}

		public bool MustRealName
		{
			get;
			set;
		}
	}
}
