using System;

namespace Himall.Model
{
	public class RecruitPlanInfo : BaseModel
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

		public string Title
		{
			get;
			set;
		}

		public string Content
		{
			get;
			set;
		}
	}
}
