using System;

namespace Himall.Model
{
	public class WeiXinBasicInfo : BaseModel
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

		public string Ticket
		{
			get;
			set;
		}

		public DateTime TicketOutTime
		{
			get;
			set;
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
	}
}
