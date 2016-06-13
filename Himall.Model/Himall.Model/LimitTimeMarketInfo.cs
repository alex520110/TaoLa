using System;
using System.ComponentModel;

namespace Himall.Model
{
	public class LimitTimeMarketInfo : BaseModel
	{
		public enum LimitTimeMarketAuditStatus : short
		{
			[Description("待审核")]
			WaitForAuditing = 1,
			[Description("进行中")]
			Ongoing,
			[Description("未通过")]
			AuditFailed,
			[Description("已结束")]
			Ended,
			[Description("已取消")]
			Cancelled
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

		public string Title
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

		public string CategoryName
		{
			get;
			set;
		}

		public LimitTimeMarketInfo.LimitTimeMarketAuditStatus AuditStatus
		{
			get;
			set;
		}

		public DateTime AuditTime
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

		public decimal Price
		{
			get;
			set;
		}

		public decimal RecentMonthPrice
		{
			get;
			set;
		}

		public DateTime StartTime
		{
			get;
			set;
		}

		public DateTime EndTime
		{
			get;
			set;
		}

		public int Stock
		{
			get;
			set;
		}

		public int SaleCount
		{
			get;
			set;
		}

		public string CancelReson
		{
			get;
			set;
		}

		public int MaxSaleCount
		{
			get;
			set;
		}

		public string ProductAd
		{
			get;
			set;
		}

		public decimal MinPrice
		{
			get;
			set;
		}

		public string ImagePath
		{
			get;
			set;
		}
	}
}
