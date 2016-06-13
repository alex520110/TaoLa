using System;

namespace TaoLa.IServices.QueryModel
{
	public class CashDepositQuery : QueryBase
	{
		public string ShopName
		{
			get;
			set;
		}

		public bool? Type
		{
			get;
			set;
		}
	}
}
