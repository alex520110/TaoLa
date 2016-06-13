using System;
using System.ComponentModel;

namespace Himall.Model
{
	public class AgreementInfo : BaseModel
	{
		public enum AgreementTypes
		{
			[Description("买家")]
			Buyers,
			[Description("卖家")]
			Seller
		}

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

		public int AgreementType
		{
			get;
			set;
		}

		public string AgreementContent
		{
			get;
			set;
		}

		public DateTime LastUpdateTime
		{
			get;
			set;
		}
	}
}
