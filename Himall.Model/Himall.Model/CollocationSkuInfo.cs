using System;

namespace Himall.Model
{
	public class CollocationSkuInfo : BaseModel
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

		public string SkuID
		{
			get;
			set;
		}

		public long ColloProductId
		{
			get;
			set;
		}

		public decimal Price
		{
			get;
			set;
		}

		public decimal? SkuPirce
		{
			get;
			set;
		}

		public virtual CollocationPoruductInfo Himall_CollocationPoruducts
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
