using TaoLa.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class GiftOrderInfo : BaseModel
	{
		public enum GiftOrderStatus
		{
			[Description("待发货")]
			WaitDelivery = 2,
			[Description("待收货")]
			WaitReceiving,
			[Description("已完成")]
			Finish = 5
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

		public GiftOrderInfo.GiftOrderStatus OrderStatus
		{
			get;
			set;
		}

		public long UserId
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

		public int? TopRegionId
		{
			get;
			set;
		}

		public int? RegionId
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

		public DateTime OrderDate
		{
			get;
			set;
		}

		public DateTime? FinishDate
		{
			get;
			set;
		}

		public int? TotalIntegral
		{
			get;
			set;
		}

		public string CloseReason
		{
			get;
			set;
		}

		public virtual ICollection<GiftOrderItemInfo> Himall_GiftOrderItem
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		[NotMapped]
		public string ShowOrderStatus
		{
			get
			{
				return this.OrderStatus.ToDescription();
			}
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

		public GiftOrderInfo()
		{
			this.Himall_GiftOrderItem = new HashSet<GiftOrderItemInfo>();
		}
	}
}
