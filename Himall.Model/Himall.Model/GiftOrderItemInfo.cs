using System;

namespace Himall.Model
{
	public class GiftOrderItemInfo : BaseModel
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

		public long? OrderId
		{
			get;
			set;
		}

		public long GiftId
		{
			get;
			set;
		}

		public int Quantity
		{
			get;
			set;
		}

		public int? SaleIntegral
		{
			get;
			set;
		}

		public string GiftName
		{
			get;
			set;
		}

		public decimal? GiftValue
		{
			get;
			set;
		}

		public string ImagePath
		{
			get;
			set;
		}

		public virtual GiftOrderInfo Himall_GiftsOrder
		{
			get;
			set;
		}
	}
}
