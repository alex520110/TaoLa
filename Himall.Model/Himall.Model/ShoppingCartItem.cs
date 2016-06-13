using System;

namespace Himall.Model
{
	public class ShoppingCartItem
	{
		public long Id
		{
			get;
			set;
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

		public int Quantity
		{
			get;
			set;
		}

		public DateTime AddTime
		{
			get;
			set;
		}
	}
}
