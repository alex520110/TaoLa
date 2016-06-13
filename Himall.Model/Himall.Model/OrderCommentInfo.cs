using System;

namespace Himall.Model
{
	public class OrderCommentInfo : BaseModel
	{
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

		public string UserName
		{
			get;
			set;
		}

		public DateTime CommentDate
		{
			get;
			set;
		}

		public int PackMark
		{
			get;
			set;
		}

		public int DeliveryMark
		{
			get;
			set;
		}

		public int ServiceMark
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
