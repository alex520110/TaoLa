using System;

namespace TaoLa.IServices.QueryModel
{
	public class DistributionShopQuery : QueryBase
	{
		public enum EnumShopSort
		{
			Default,
			SalesNumber,
			ProductNum,
			AgentNum
		}

		public string skey
		{
			get;
			set;
		}

		public new DistributionShopQuery.EnumShopSort Sort
		{
			get;
			set;
		}
	}
}
