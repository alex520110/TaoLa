using System;

namespace Himall.Model
{
	public class AccountMetaInfo : BaseModel
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

		public long AccountId
		{
			get;
			set;
		}

		public string MetaKey
		{
			get;
			set;
		}

		public string MetaValue
		{
			get;
			set;
		}

		public DateTime ServiceStartTime
		{
			get;
			set;
		}

		public DateTime ServiceEndTime
		{
			get;
			set;
		}
	}
}
