using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class ShoppingCartInfo
	{
		public IEnumerable<ShoppingCartItem> Items
		{
			get;
			set;
		}

		public long MemberId
		{
			get;
			set;
		}

		public ShoppingCartInfo()
		{
			this.Items = new ShoppingCartItem[0];
		}
	}
}
