using System;

namespace Himall.Model
{
	public class AgentProductsInfo : BaseModel
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

		public long UserId
		{
			get;
			set;
		}

		public DateTime AddTime
		{
			get;
			set;
		}

		public virtual ProductInfo Himall_Products
		{
			get;
			set;
		}

		public virtual UserMemberInfo Himall_Members
		{
			get;
			set;
		}
	}
}
