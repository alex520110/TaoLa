using System;

namespace Himall.Model
{
	public class MarketServiceRecordInfo : BaseModel
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

		public long MarketServiceId
		{
			get;
			set;
		}

		public DateTime StartTime
		{
			get;
			set;
		}

		public DateTime EndTime
		{
			get;
			set;
		}

		public long SettlementFlag
		{
			get;
			set;
		}

		public virtual ActiveMarketServiceInfo ActiveMarketServiceInfo
		{
			get;
			set;
		}
	}
}
