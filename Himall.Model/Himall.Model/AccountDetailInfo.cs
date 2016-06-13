using System;
using System.ComponentModel;

namespace Himall.Model
{
	public class AccountDetailInfo : BaseModel
	{
		public enum EnumOrderType
		{
			[Description("退单列表")]
			ReturnOrder,
			[Description("订单列表")]
			FinishedOrder
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

		public DateTime Date
		{
			get;
			set;
		}

		public long OrderId
		{
			get;
			set;
		}

		public decimal CommissionAmount
		{
			get;
			set;
		}

		public decimal RefundTotalAmount
		{
			get;
			set;
		}

		public decimal RefundCommisAmount
		{
			get;
			set;
		}

		public AccountDetailInfo.EnumOrderType OrderType
		{
			get;
			set;
		}

		public decimal FreightAmount
		{
			get;
			set;
		}

		public decimal ProductActualPaidAmount
		{
			get;
			set;
		}

		public long AccountId
		{
			get;
			set;
		}

		public DateTime OrderDate
		{
			get;
			set;
		}

		public string OrderRefundsDates
		{
			get;
			set;
		}

		public decimal BrokerageAmount
		{
			get;
			set;
		}

		public decimal ReturnBrokerageAmount
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
