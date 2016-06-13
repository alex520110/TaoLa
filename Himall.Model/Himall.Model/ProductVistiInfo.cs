using System;

namespace Himall.Model
{
	public class ProductVistiInfo : BaseModel
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

		public DateTime Date
		{
			get;
			set;
		}

		public long VistiCounts
		{
			get;
			set;
		}

		public long SaleCounts
		{
			get;
			set;
		}

		public decimal SaleAmounts
		{
			get;
			set;
		}

		public long? OrderCounts
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
