using System;

namespace Himall.Model
{
	public class CashDepositDetailInfo : BaseModel
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

		public long CashDepositId
		{
			get;
			set;
		}

		public DateTime AddDate
		{
			get;
			set;
		}

		public decimal Balance
		{
			get;
			set;
		}

		public string Operator
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public int? RechargeWay
		{
			get;
			set;
		}

		public virtual CashDepositInfo Himall_CashDeposit
		{
			get;
			set;
		}
	}
}
