using System;

namespace Himall.Model
{
	public class ShopFooterInfo : BaseModel
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

		public string Footer
		{
			get;
			set;
		}
	}
}
