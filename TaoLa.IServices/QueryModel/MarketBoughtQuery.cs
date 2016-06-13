using Himall.Model;
using System;

namespace TaoLa.IServices.QueryModel
{
	public class MarketBoughtQuery : QueryBase
	{
		public MarketType? MarketType
		{
			get;
			set;
		}

		public string ShopName
		{
			get;
			set;
		}
	}
}
