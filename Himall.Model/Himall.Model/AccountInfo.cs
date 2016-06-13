using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class AccountInfo : BaseModel
	{
		public enum AccountStatus
		{
			[Description("未结算")]
			UnAccount,
			[Description("已结算")]
			Accounted
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

		public long ShopId
		{
			get;
			set;
		}

		public string ShopName
		{
			get;
			set;
		}

		public DateTime AccountDate
		{
			get;
			set;
		}

		public DateTime StartDate
		{
			get;
			set;
		}

		public DateTime EndDate
		{
			get;
			set;
		}

		public AccountInfo.AccountStatus Status
		{
			get;
			set;
		}

		public decimal CommissionAmount
		{
			get;
			set;
		}

		public decimal RefundAmount
		{
			get;
			set;
		}

		public string Remark
		{
			get;
			set;
		}

		public decimal FreightAmount
		{
			get;
			set;
		}

		public decimal RefundCommissionAmount
		{
			get;
			set;
		}

		public decimal AdvancePaymentAmount
		{
			get;
			set;
		}

		public decimal PeriodSettlement
		{
			get;
			set;
		}

		public decimal ProductActualPaidAmount
		{
			get;
			set;
		}

		public decimal Brokerage
		{
			get;
			set;
		}

		public decimal ReturnBrokerage
		{
			get;
			set;
		}

		public virtual ICollection<AccountPurchaseAgreementInfo> Himall_AccountPurchaseAgreement
		{
			get;
			set;
		}

		public virtual ICollection<AccountDetailInfo> Himall_AccountDetails
		{
			get;
			set;
		}

		[NotMapped]
		public decimal AccountAmount
		{
			get
			{
				return 0m;
			}
		}

		public AccountInfo()
		{
			this.Himall_AccountPurchaseAgreement = new HashSet<AccountPurchaseAgreementInfo>();
			this.Himall_AccountDetails = new HashSet<AccountDetailInfo>();
		}
	}
}
