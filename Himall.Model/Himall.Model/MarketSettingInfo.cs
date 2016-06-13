using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class MarketSettingInfo : BaseModel
	{
		private int _id;

		public new int Id
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

		public decimal Price
		{
			get;
			set;
		}

		public virtual ICollection<MarketSettingMetaInfo> Himall_MarketSettingMeta
		{
			get;
			set;
		}

		public MarketSettingInfo()
		{
			this.Himall_MarketSettingMeta = new HashSet<MarketSettingMetaInfo>();
		}
	}
}
