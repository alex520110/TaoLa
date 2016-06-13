using System;

namespace Himall.Model
{
	internal class ShoppingCartItemInfo : BaseModel
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

		public long UserId
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

		public int Quantity
		{
			get;
			set;
		}

		public DateTime AddTime
		{
			get;
			set;
		}

		public virtual UserMemberInfo MemberInfo
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
