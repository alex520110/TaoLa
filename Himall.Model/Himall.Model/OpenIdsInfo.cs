using System;

namespace Himall.Model
{
	public class OpenIdsInfo : BaseModel
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

		public string OpenId
		{
			get;
			set;
		}

		public DateTime SubscribeTime
		{
			get;
			set;
		}

		public bool IsSubscribe
		{
			get;
			set;
		}
	}
}
