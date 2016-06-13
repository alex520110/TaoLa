using Himall.Model;
using System;

namespace TaoLa.IServices.QueryModel
{
	public class ProductBrokerageQuery : QueryBase
	{
		public enum EnumProductSort
		{
			Default,
			SalesNumber,
			AgentNum,
			Brokerage,
			PriceAsc,
			PriceDesc
		}

		public string skey
		{
			get;
			set;
		}

		public long? CategoryId
		{
			get;
			set;
		}

		public long? ShopId
		{
			get;
			set;
		}

		public long? AgentUserId
		{
			get;
			set;
		}

		public ProductBrokerageInfo.ProductBrokerageStatus? ProductBrokerageState
		{
			get;
			set;
		}

		public bool? OnlyShowNormal
		{
			get;
			set;
		}

		public new ProductBrokerageQuery.EnumProductSort Sort
		{
			get;
			set;
		}
	}
}
