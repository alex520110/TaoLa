using System;

namespace Himall.Model
{
	public class FlashSaleConfigInfo : BaseModel
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

		public int Preheat
		{
			get;
			set;
		}

		public bool IsNormalPurchase
		{
			get;
			set;
		}
	}
}
