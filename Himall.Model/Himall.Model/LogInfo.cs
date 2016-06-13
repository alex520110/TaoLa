using System;

namespace Himall.Model
{
	public class LogInfo : BaseModel
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

		public long ShopId
		{
			get;
			set;
		}

		public string PageUrl
		{
			get;
			set;
		}

		public DateTime Date
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public string IPAddress
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}
	}
}
