using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class DistributionProductModel
	{
		public long Id
		{
			get;
			set;
		}

		public long? ProductId
		{
			get;
			set;
		}

		public decimal rate
		{
			get;
			set;
		}

		public int? SaleNum
		{
			get;
			set;
		}

		public int? AgentNum
		{
			get;
			set;
		}

		public int? ForwardNum
		{
			get;
			set;
		}

		public ProductBrokerageInfo.ProductBrokerageStatus Status
		{
			get;
			set;
		}

		public int? Sort
		{
			get;
			set;
		}

		public decimal saleAmount
		{
			get;
			set;
		}

		public decimal BrokerageAmount
		{
			get;
			set;
		}

		public decimal BrokerageTotal
		{
			get;
			set;
		}

		public string ProductName
		{
			get;
			set;
		}

		public string Image
		{
			get;
			set;
		}

		public decimal MinSalePrice
		{
			get;
			set;
		}

		[NotMapped]
		public decimal Commission
		{
			get
			{
				decimal num = 0m;
				decimal rate = this.rate;
				if (rate > 0m)
				{
					num = this.MinSalePrice * rate / 100m;
					int value = (int)(num * 100m);
					num = value / 100m;
				}
				return num;
			}
		}
	}
}
