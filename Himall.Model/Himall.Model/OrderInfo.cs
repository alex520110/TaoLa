using Himall.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class OrderInfo : BaseModel
	{
		public enum OrderTypes
		{
			[Description("组合购")]
			Collocation = 1,
			[Description("限时购")]
			LimitBuy
		}

		public enum PaymentTypes
		{
			[Description("")]
			None,
			[Description("线上支付")]
			Online,
			[Description("线下支付")]
			Offline,
			[Description("货到付款")]
			CashOnDelivery
		}

		public enum OrderOperateStatus
		{
			[Description("待付款")]
			WaitPay = 1,
			[Description("待发货")]
			WaitDelivery,
			[Description("待收货")]
			WaitReceiving,
			[Description("已关闭")]
			Close,
			[Description("已完成")]
			Finish,
			[Description("申请取消")]
			CloseByUser
		}

		public enum ActiveTypes
		{
			[Description("无活动")]
			None
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

		public OrderInfo.OrderOperateStatus OrderStatus
		{
			get;
			set;
		}

		public DateTime OrderDate
		{
			get;
			set;
		}

		public string CloseReason
		{
			get;
			set;
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

		public string SellerPhone
		{
			get;
			set;
		}

		public string SellerAddress
		{
			get;
			set;
		}

		public string SellerRemark
		{
			get;
			set;
		}

		public long UserId
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public string UserRemark
		{
			get;
			set;
		}

		public string ShipTo
		{
			get;
			set;
		}

		public string CellPhone
		{
			get;
			set;
		}

		public int TopRegionId
		{
			get;
			set;
		}

		public int RegionId
		{
			get;
			set;
		}

		public string RegionFullName
		{
			get;
			set;
		}

		public string Address
		{
			get;
			set;
		}

		public string ExpressCompanyName
		{
			get;
			set;
		}

		public decimal Freight
		{
			get;
			set;
		}

		public string ShipOrderNumber
		{
			get;
			set;
		}

		public DateTime? ShippingDate
		{
			get;
			set;
		}

		public bool IsPrinted
		{
			get;
			set;
		}

		public string PaymentTypeName
		{
			get;
			set;
		}

		public string PaymentTypeGateway
		{
			get;
			set;
		}

		public string GatewayOrderId
		{
			get;
			set;
		}

		public string PayRemark
		{
			get;
			set;
		}

		public DateTime? PayDate
		{
			get;
			set;
		}

		public string InvoiceTitle
		{
			get;
			set;
		}

		public decimal Tax
		{
			get;
			set;
		}

		public DateTime? FinishDate
		{
			get;
			set;
		}

		public decimal ProductTotalAmount
		{
			get;
			set;
		}

		public decimal RefundTotalAmount
		{
			get;
			set;
		}

		public decimal CommisTotalAmount
		{
			get;
			set;
		}

		public decimal RefundCommisAmount
		{
			get;
			set;
		}

		public OrderInfo.ActiveTypes ActiveType
		{
			get;
			set;
		}

		public PlatformType Platform
		{
			get;
			set;
		}

		public decimal DiscountAmount
		{
			get;
			set;
		}

		public InvoiceType InvoiceType
		{
			get;
			set;
		}

		public decimal IntegralDiscount
		{
			get;
			set;
		}

		public string InvoiceContext
		{
			get;
			set;
		}

		public OrderInfo.OrderTypes? OrderType
		{
			get;
			set;
		}

		public OrderInfo.PaymentTypes PaymentType
		{
			get;
			set;
		}

		public long? ShareUserId
		{
			get;
			set;
		}

		public virtual ICollection<OrderComplaintInfo> OrderComplaintInfo
		{
			get;
			set;
		}

		public virtual ICollection<OrderItemInfo> OrderItemInfo
		{
			get;
			set;
		}

		public virtual ICollection<OrderOperationLogInfo> OrderOperationLogInfo
		{
			get;
			set;
		}

		public virtual ICollection<OrderCommentInfo> OrderCommentInfo
		{
			get;
			set;
		}

		[NotMapped]
		public long OrderProductQuantity
		{
			get
			{
				long num = 0L;
				foreach (OrderItemInfo current in this.OrderItemInfo)
				{
					num += current.Quantity;
				}
				return num;
			}
		}

		[NotMapped]
		public long OrderReturnQuantity
		{
			get
			{
				long num = 0L;
				foreach (OrderItemInfo current in this.OrderItemInfo)
				{
					num += current.ReturnQuantity;
				}
				return num;
			}
		}

		[NotMapped]
		public decimal OrderTotalAmount
		{
			get
			{
				return this.ProductTotalAmount + this.Freight + this.Tax - this.IntegralDiscount - this.DiscountAmount;
			}
		}

		[NotMapped]
		public decimal OrderEnabledRefundAmount
		{
			get
			{
				decimal result = 0m;
				switch (this.OrderStatus)
				{
				case OrderInfo.OrderOperateStatus.WaitDelivery:
					result = this.ProductTotalAmount + this.Freight - this.DiscountAmount;
					break;
				case OrderInfo.OrderOperateStatus.WaitReceiving:
				case OrderInfo.OrderOperateStatus.Finish:
					result = this.ProductTotalAmount - this.DiscountAmount - this.RefundTotalAmount;
					break;
				}
				return result;
			}
		}

		[NotMapped]
		public decimal CommisAmount
		{
			get
			{
				return this.CommisTotalAmount - this.RefundCommisAmount;
			}
		}

		[NotMapped]
		public decimal ShopAccountAmount
		{
			get
			{
				return this.OrderTotalAmount - this.RefundTotalAmount - this.CommisAmount;
			}
		}

		[NotMapped]
		public int? RefundStats
		{
			get;
			set;
		}

		[NotMapped]
		public bool HaveDelProduct
		{
			get;
			set;
		}

		[NotMapped]
		public string ShowExpressCompanyName
		{
			get
			{
				string text = this.ExpressCompanyName;
				if (text == "-1")
				{
					text = "其他";
				}
				return text;
			}
		}

		public OrderInfo()
		{
			this.OrderComplaintInfo = new HashSet<OrderComplaintInfo>();
			this.OrderItemInfo = new HashSet<OrderItemInfo>();
			this.OrderOperationLogInfo = new HashSet<OrderOperationLogInfo>();
			this.OrderCommentInfo = new HashSet<OrderCommentInfo>();
		}
	}
}
