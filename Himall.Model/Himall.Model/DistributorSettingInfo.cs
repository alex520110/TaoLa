using System;

namespace Himall.Model
{
	public class DistributorSettingInfo : BaseModel
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

		public string SellerRule
		{
			get;
			set;
		}

		public string PromoterRule
		{
			get;
			set;
		}

		public bool Enable
		{
			get;
			set;
		}
	}
}
