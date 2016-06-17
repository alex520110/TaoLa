using TaoLa.Core;
using System;

namespace Himall.Model
{
	public class MobileHomeProductsInfo : BaseModel
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

		public long ShopId
		{
			get;
			set;
		}

		public PlatformType PlatFormType
		{
			get;
			set;
		}

		public short Sequence
		{
			get;
			set;
		}

		public long ProductId
		{
			get;
			set;
		}

		public virtual ProductInfo Himall_Products
		{
			get;
			set;
		}
	}
}
