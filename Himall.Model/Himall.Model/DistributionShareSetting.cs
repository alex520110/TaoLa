using System;

namespace Himall.Model
{
	public class DistributionShareSetting : BaseModel
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

		public string ProShareLogo
		{
			get;
			set;
		}

		public string ShopShareLogo
		{
			get;
			set;
		}

		public string ProShareTitle
		{
			get;
			set;
		}

		public string ShopShareTitle
		{
			get;
			set;
		}

		public string ProShareDesc
		{
			get;
			set;
		}

		public string ShopShareDesc
		{
			get;
			set;
		}
	}
}
