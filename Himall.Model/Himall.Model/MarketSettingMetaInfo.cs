using System;

namespace Himall.Model
{
	public class MarketSettingMetaInfo : BaseModel
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

		public int MarketId
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

		public virtual MarketSettingInfo Himall_MarketSetting
		{
			get;
			set;
		}
	}
}
