using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class ActiveMarketServiceInfo : BaseModel
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

		public MarketType TypeId
		{
			get;
			set;
		}

		public long ShopId
		{
			get;
			set;
		}

		public string ShopName
		{
			get;
			set;
		}

		public virtual ICollection<MarketServiceRecordInfo> MarketServiceRecordInfo
		{
			get;
			set;
		}

		public ActiveMarketServiceInfo()
		{
			this.MarketServiceRecordInfo = new HashSet<MarketServiceRecordInfo>();
		}
	}
}
