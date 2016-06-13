using Himall.Model;
using System;
using System.Collections.Generic;

namespace TaoLa.IServices.QueryModel
{
	public class ProductQuery : QueryBase
	{
		public long? CategoryId
		{
			get;
			set;
		}

		public string BrandNameKeyword
		{
			get;
			set;
		}

		public IEnumerable<ProductInfo.ProductAuditStatus> AuditStatus
		{
			get;
			set;
		}

		public ProductInfo.ProductSaleStatus? SaleStatus
		{
			get;
			set;
		}

		public string KeyWords
		{
			get;
			set;
		}

		public IEnumerable<long> Ids
		{
			get;
			set;
		}

		public string ShopName
		{
			get;
			set;
		}

		public long? ShopId
		{
			get;
			set;
		}

		public DateTime? StartDate
		{
			get;
			set;
		}

		public DateTime? EndDate
		{
			get;
			set;
		}

		public long? ShopCategoryId
		{
			get;
			set;
		}

		public bool IsLimitTimeBuy
		{
			get;
			set;
		}

		public string ProductCode
		{
			get;
			set;
		}

		public bool NotIncludedInDraft
		{
			get;
			set;
		}
	}
}
