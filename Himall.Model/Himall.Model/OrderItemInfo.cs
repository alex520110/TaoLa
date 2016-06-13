using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class OrderItemInfo : BaseModel
	{
		private long _id;

		public string ProductCode
		{
			get;
			set;
		}

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

		public long ShopId
		{
			get;
			set;
		}

		public long ProductId
		{
			get;
			set;
		}

		public string SkuId
		{
			get;
			set;
		}

		public string SKU
		{
			get;
			set;
		}

		public long Quantity
		{
			get;
			set;
		}

		public long ReturnQuantity
		{
			get;
			set;
		}

		public decimal CostPrice
		{
			get;
			set;
		}

		public decimal SalePrice
		{
			get;
			set;
		}

		public decimal DiscountAmount
		{
			get;
			set;
		}

		public decimal RealTotalPrice
		{
			get;
			set;
		}

		public decimal RefundPrice
		{
			get;
			set;
		}

		public string ProductName
		{
			get;
			set;
		}

		public string Color
		{
			get;
			set;
		}

		public string Size
		{
			get;
			set;
		}

		public string Version
		{
			get;
			set;
		}

		public string ThumbnailsUrl
		{
			get;
			set;
		}

		public decimal CommisRate
		{
			get;
			set;
		}

		public decimal? EnabledRefundAmount
		{
			get;
			set;
		}

		public bool IsLimitBuy
		{
			get;
			set;
		}

		public decimal? DistributionRate
		{
			get;
			set;
		}

		public virtual OrderInfo OrderInfo
		{
			get;
			set;
		}

		public virtual ICollection<OrderRefundInfo> OrderRefundInfo
		{
			get;
			set;
		}

		public virtual ICollection<ProductCommentInfo> Himall_ProductComments
		{
			get;
			set;
		}

		public OrderItemInfo()
		{
			this.OrderRefundInfo = new HashSet<OrderRefundInfo>();
			this.Himall_ProductComments = new HashSet<ProductCommentInfo>();
		}
	}
}
