using System;

namespace Himall.Model
{
	public class BrokerageRefundInfo : BaseModel
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

		public long? IncomeId
		{
			get;
			set;
		}

		public decimal Brokerage
		{
			get;
			set;
		}

		public DateTime? RefundTime
		{
			get;
			set;
		}

		public decimal? RefundAmount
		{
			get;
			set;
		}

		public long RefundId
		{
			get;
			set;
		}

		public virtual BrokerageIncomeInfo Himall_BrokerageIncome
		{
			get;
			set;
		}
	}
}
