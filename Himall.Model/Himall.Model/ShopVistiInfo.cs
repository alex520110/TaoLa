using System;

namespace Himall.Model
{
	public class ShopVistiInfo : BaseModel
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
	}
}
