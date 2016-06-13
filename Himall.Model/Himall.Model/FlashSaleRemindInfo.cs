using System;

namespace Himall.Model
{
	public class FlashSaleRemindInfo : BaseModel
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

		public DateTime RecordDate
		{
			get;
			set;
		}

		public long FlashSaleId
		{
			get;
			set;
		}
	}
}
