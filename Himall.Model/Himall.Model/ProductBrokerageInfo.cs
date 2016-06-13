using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class ProductBrokerageInfo : BaseModel
	{
		public enum ProductBrokerageStatus
		{
			[Description("推广中")]
			Normal,
			[Description("已清退")]
			Removed
		}

		private long _id;

		[NotMapped]
		public ProductInfo Product
		{
			get;
			set;
		}

		[NotMapped]
		public string CategoryName
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
					if (this.Product != null)
					{
						num = this.Product.MinSalePrice * rate / 100m;
						int value = (int)(num * 100m);
						num = value / 100m;
					}
				}
				return num;
			}
		}

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

		public long? ShopId
		{
			get;
			set;
		}

		public DateTime? CreateTime
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

		public virtual ProductInfo Himall_Products
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
