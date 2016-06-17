using TaoLa.Core;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class OrderRefundInfo : BaseModel
	{
		public enum OrderRefundAuditStatus
		{
			[Description("待商家审核")]
			WaitAudit = 1,
			[Description("待买家寄货")]
			WaitDelivery,
			[Description("待商家收货")]
			WaitReceiving,
			[Description("商家拒绝")]
			UnAudit,
			[Description("商家通过审核")]
			Audited
		}

		public enum OrderRefundConfirmStatus
		{
			[Description("待平台确认")]
			UnConfirm = 6,
			[Description("退款成功")]
			Confirmed
		}

		public enum OrderRefundMode
		{
			[Description("订单退款")]
			OrderRefund = 1,
			[Description("货品退款")]
			OrderItemRefund,
			[Description("退货退款")]
			ReturnGoodsRefund
		}

		public enum OrderRefundPayStatus
		{
			[Description("支付成功")]
			PaySuccess = 1,
			[Description("支付失败")]
			PayFail = -1,
			[Description("己支付")]
			Payed
		}

		public enum OrderRefundPayType
		{
			[Description("原路返回")]
			BackOut = 1,
			[Description("线下支付")]
			OffLine,
			[Description("退到预付款")]
			BackCapital
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

		public long OrderId
		{
			get;
			set;
		}

		public long OrderItemId
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

		public long UserId
		{
			get;
			set;
		}

		public string Applicant
		{
			get;
			set;
		}

		public string Reason
		{
			get;
			set;
		}

		public string ContactPerson
		{
			get;
			set;
		}

		public string ContactCellPhone
		{
			get;
			set;
		}

		public string RefundAccount
		{
			get;
			set;
		}

		public DateTime ApplyDate
		{
			get;
			set;
		}

		public decimal Amount
		{
			get;
			set;
		}

		public OrderRefundInfo.OrderRefundAuditStatus SellerAuditStatus
		{
			get;
			set;
		}

		public DateTime SellerAuditDate
		{
			get;
			set;
		}

		public string SellerRemark
		{
			get;
			set;
		}

		public OrderRefundInfo.OrderRefundConfirmStatus ManagerConfirmStatus
		{
			get;
			set;
		}

		public DateTime ManagerConfirmDate
		{
			get;
			set;
		}

		public string ManagerRemark
		{
			get;
			set;
		}

		public bool IsReturn
		{
			get;
			set;
		}

		public string ExpressCompanyName
		{
			get;
			set;
		}

		public string ShipOrderNumber
		{
			get;
			set;
		}

		public string Payee
		{
			get;
			set;
		}

		public string PayeeAccount
		{
			get;
			set;
		}

		public OrderRefundInfo.OrderRefundMode RefundMode
		{
			get;
			set;
		}

		public DateTime? BuyerDeliverDate
		{
			get;
			set;
		}

		public DateTime? SellerConfirmArrivalDate
		{
			get;
			set;
		}

		public OrderRefundInfo.OrderRefundPayStatus? RefundPayStatus
		{
			get;
			set;
		}

		public OrderRefundInfo.OrderRefundPayType? RefundPayType
		{
			get;
			set;
		}

		public string RefundBatchNo
		{
			get;
			set;
		}

		public DateTime? RefundPostTime
		{
			get;
			set;
		}

		public long? ReturnQuantity
		{
			get;
			set;
		}

		public decimal ReturnBrokerage
		{
			get;
			set;
		}

		public virtual OrderItemInfo OrderItemInfo
		{
			get;
			set;
		}

		[NotMapped]
		public long ShowReturnQuantity
		{
			get
			{
				long result = 0L;
				if (this != null)
				{
					if (this.ReturnQuantity.HasValue)
					{
						result = this.ReturnQuantity.Value;
					}
				}
				return result;
			}
		}

		[NotMapped]
		public int RefundType
		{
			get;
			set;
		}

		public string RefundStatus
		{
			get
			{
				string result = this.SellerAuditStatus.ToDescription();
				if (this.SellerAuditStatus == OrderRefundInfo.OrderRefundAuditStatus.Audited)
				{
					result = this.ManagerConfirmStatus.ToDescription();
				}
				return result;
			}
		}

		public decimal EnabledRefundAmount
		{
			get;
			set;
		}
	}
}
