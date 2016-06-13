using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Himall.Model
{
	public class BrokerageIncomeInfo : BaseModel
	{
		public enum BrokerageStatus
		{
			[Description("不可结算")]
			NotAvailable = -1,
			[Description("未结算")]
			NotSettled,
			[Description("已结算")]
			Settled
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

		public long? OrderId
		{
			get;
			set;
		}

		public long? OrderItemId
		{
			get;
			set;
		}

		public string SkuID
		{
			get;
			set;
		}

		public long ProductID
		{
			get;
			set;
		}

		public string ProductName
		{
			get;
			set;
		}

		public string SkuInfo
		{
			get;
			set;
		}

		public decimal Brokerage
		{
			get;
			set;
		}

		public long? ShopId
		{
			get;
			set;
		}

		public DateTime? CreateTime
		{
			get;
			set;
		}

		public long BuyerUserId
		{
			get;
			set;
		}

		public BrokerageIncomeInfo.BrokerageStatus Status
		{
			get;
			set;
		}

		public DateTime? SettlementTime
		{
			get;
			set;
		}

		public long UserId
		{
			get;
			set;
		}

		public decimal? TotalPrice
		{
			get;
			set;
		}

		public DateTime OrderTime
		{
			get;
			set;
		}

		public virtual ICollection<BrokerageRefundInfo> Himall_BrokerageRefund
		{
			get;
			set;
		}

		public BrokerageIncomeInfo()
		{
			this.Himall_BrokerageRefund = new HashSet<BrokerageRefundInfo>();
		}
	}
}
