using System;

namespace Himall.Model
{
	public class ProductConsultationInfo : BaseModel
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

		public long ProductId
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

		public string Email
		{
			get;
			set;
		}

		public string ConsultationContent
		{
			get;
			set;
		}

		public DateTime ConsultationDate
		{
			get;
			set;
		}

		public string ReplyContent
		{
			get;
			set;
		}

		public DateTime? ReplyDate
		{
			get;
			set;
		}

		public virtual ProductInfo ProductInfo
		{
			get;
			set;
		}
	}
}
