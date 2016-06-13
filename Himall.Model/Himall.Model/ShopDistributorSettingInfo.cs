using System;

namespace Himall.Model
{
	public class ShopDistributorSettingInfo : BaseModel
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

		public decimal DistributorDefaultRate
		{
			get;
			set;
		}

		public string DistributorShareName
		{
			get;
			set;
		}

		public string DistributorShareContent
		{
			get;
			set;
		}

		public string DistributorShareLogo
		{
			get;
			set;
		}
	}
}
