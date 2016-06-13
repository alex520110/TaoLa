using System;

namespace Himall.Model
{
	public class ReceivingAddressInfo : BaseModel
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

		public string AddressId_City
		{
			get;
			set;
		}

		public string AddressId
		{
			get;
			set;
		}

		public long ShopId
		{
			get;
			set;
		}

		public virtual ShopInfo Himall_Shops
		{
			get;
			set;
		}
	}
}
