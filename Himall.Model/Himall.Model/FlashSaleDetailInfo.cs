using System;

namespace Himall.Model
{
	public class FlashSaleDetailInfo : BaseModel
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

		public string SkuId
		{
			get;
			set;
		}

		public decimal? Price
		{
			get;
			set;
		}

		public long FlashSaleId
		{
			get;
			set;
		}
	}
}
