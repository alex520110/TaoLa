using TaoLa.Core;
using System;

namespace Himall.Model
{
	public class DistributionFeatModel
	{
		public long Id
		{
			get;
			set;
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

		public long? ShopId
		{
			get;
			set;
		}

		public long BuyUserId
		{
			get;
			set;
		}

		public long ProductId
		{
			get;
			set;
		}

		public string ProductName
		{
			get;
			set;
		}

		public string SkuId
		{
			get;
			set;
		}

		public string SkuInfo
		{
			get;
			set;
		}

		public string ProductImage
		{
			get;
			set;
		}

		public decimal Brokerage
		{
			get;
			set;
		}

		public decimal OrderItemPrice
		{
			get;
			set;
		}

		public BrokerageIncomeInfo.BrokerageStatus SettleState
		{
			get;
			set;
		}

		public string ShowSettleState
		{
			get
			{
				return this.SettleState.ToDescription();
			}
		}

		public bool IsSettled
		{
			get
			{
				return this.SettleState == BrokerageIncomeInfo.BrokerageStatus.Settled;
			}
		}

		public DateTime? CreateTime
		{
			get;
			set;
		}

		public DateTime? LastRightsTime
		{
			get;
			set;
		}

		public DateTime? ShippingDate
		{
			get;
			set;
		}

		public DateTime? SettleTime
		{
			get;
			set;
		}

		public string SalesName
		{
			get;
			set;
		}

		public long SalesUserId
		{
			get;
			set;
		}

		public OrderInfo.OrderOperateStatus OrderState
		{
			get;
			set;
		}

		public string ShowOrderState
		{
			get
			{
				return this.OrderState.ToDescription();
			}
		}

		public DateTime OrderTime
		{
			get;
			set;
		}

		public bool IsHaveRefund
		{
			get
			{
				return this.RefundPrice > 0m;
			}
		}

		public decimal? RefundPrice
		{
			get;
			set;
		}

		public decimal? RefundBrokerage
		{
			get;
			set;
		}

		public DateTime? RefundTime
		{
			get;
			set;
		}

		public decimal CanBrokerage
		{
			get
			{
				decimal num = this.Brokerage;
				if (this.RefundBrokerage.HasValue)
				{
					num -= this.RefundBrokerage.Value;
				}
				return num;
			}
		}
	}
}
