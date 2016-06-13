using Himall.Core;
using System;

namespace Himall.Model
{
	public class ProductsDistributionModel
	{
		public long Id
		{
			get;
			set;
		}

		public string ProductName
		{
			get;
			set;
		}

		public ProductBrokerageInfo.ProductBrokerageStatus Status
		{
			get;
			set;
		}

		public string ShopName
		{
			get;
			set;
		}

		public int AgentNum
		{
			get;
			set;
		}

		public int ForwardNum
		{
			get;
			set;
		}

		public int DistributionSaleNum
		{
			get;
			set;
		}

		public decimal DistributionSaleAmount
		{
			get;
			set;
		}

		public decimal SaleNum
		{
			get;
			set;
		}

		public decimal SaleAmount
		{
			get;
			set;
		}

		public decimal Brokerage
		{
			get;
			set;
		}

		public decimal NoSettledBrokerage
		{
			get;
			set;
		}

		public int Sort
		{
			get;
			set;
		}

		public string ProDisStatus
		{
			get
			{
				return this.Status.ToDescription();
			}
		}
	}
}
