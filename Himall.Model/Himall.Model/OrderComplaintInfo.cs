using System;
using System.ComponentModel;

namespace Himall.Model
{
	public class OrderComplaintInfo : BaseModel
	{
		public enum ComplaintStatus
		{
			[Description("等待商家处理")]
			WaitDeal = 1,
			[Description("商家处理完成")]
			Dealed,
			[Description("等待平台介入")]
			Dispute,
			[Description("已结束")]
			End
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

		public OrderComplaintInfo.ComplaintStatus Status
		{
			get;
			set;
		}

		public string ComplaintReason
		{
			get;
			set;
		}

		public string SellerReply
		{
			get;
			set;
		}

		public DateTime ComplaintDate
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

		public string ShopPhone
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

		public string UserPhone
		{
			get;
			set;
		}

		public virtual OrderInfo OrderInfo
		{
			get;
			set;
		}
	}
}
