using System;

namespace Himall.Model
{
	public class WXAccTokenInfo : BaseModel
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

		public string AppId
		{
			get;
			set;
		}

		public string AccessToken
		{
			get;
			set;
		}

		public DateTime TokenOutTime
		{
			get;
			set;
		}
	}
}
