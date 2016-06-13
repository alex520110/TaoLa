using System;

namespace Himall.Model
{
	public class SiteSignInConfigInfo : BaseModel
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

		public bool IsEnable
		{
			get;
			set;
		}

		public int DayIntegral
		{
			get;
			set;
		}

		public int DurationCycle
		{
			get;
			set;
		}

		public int DurationReward
		{
			get;
			set;
		}
	}
}
