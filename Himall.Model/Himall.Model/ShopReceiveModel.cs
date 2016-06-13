using System;

namespace Himall.Model
{
	public class ShopReceiveModel
	{
		public ShopReceiveStatus State
		{
			get;
			set;
		}

		public decimal Price
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public long Id
		{
			get;
			set;
		}
	}
}
