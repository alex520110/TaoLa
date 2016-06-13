using System;

namespace Himall.Model
{
	public class CategoryCashDepositInfo : BaseModel
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

		public long CategoryId
		{
			get;
			set;
		}

		public decimal NeedPayCashDeposit
		{
			get;
			set;
		}

		public bool EnableNoReasonReturn
		{
			get;
			set;
		}

		public virtual CategoryInfo CategoriesInfo
		{
			get;
			set;
		}
	}
}
