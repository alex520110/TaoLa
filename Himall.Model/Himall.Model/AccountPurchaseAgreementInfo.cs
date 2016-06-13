using System;

namespace Himall.Model
{
	public class AccountPurchaseAgreementInfo : BaseModel
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

		public long? AccountId
		{
			get;
			set;
		}

		public long ShopId
		{
			get;
			set;
		}

		public DateTime Date
		{
			get;
			set;
		}

		public long PurchaseAgreementId
		{
			get;
			set;
		}

		public decimal AdvancePayment
		{
			get;
			set;
		}

		public DateTime FinishDate
		{
			get;
			set;
		}

		public DateTime? ApplyDate
		{
			get;
			set;
		}

		public virtual AccountInfo Himall_Accounts
		{
			get;
			set;
		}
	}
}
