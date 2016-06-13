using System;
using System.ComponentModel;

namespace Himall.Model
{
	public class FlashSaleInfo : BaseModel
	{
		public enum FlashSaleStatus
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

		public FlashSaleInfo.FlashSaleStatus Status
		{
			get;
			set;
		}

		public DateTime BeginDate
		{
			get;
			set;
		}

		public DateTime EndDate
		{
			get;
			set;
		}

		public int LimitCountOfThePeople
		{
			get;
			set;
		}

		public int SaleCount
		{
			get;
			set;
		}

		public string CategoryName
		{
			get;
			set;
		}

		public string ImagePath
		{
			get;
			set;
		}

		public decimal MinPrice
		{
			get;
			set;
		}

		public virtual ProductInfo Himall_Products
		{
			get;
			set;
		}

		public virtual ShopInfo Himall_Shops
		{
			get;
			set;
		}
	}
}
