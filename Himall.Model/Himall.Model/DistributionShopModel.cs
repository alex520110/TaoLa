using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class DistributionShopModel
	{
		public long Id
		{
			get;
			set;
		}

		public long ShopId
		{
			get;
			set;
		}

		public long GradeId
		{
			get;
			set;
		}

		public string ShopName
		{
			get;
			set;
		}

		public string SubDomains
		{
			get;
			set;
		}

		public string Theme
		{
			get;
			set;
		}

		public bool IsSelf
		{
			get;
			set;
		}

		public ShopInfo.ShopAuditStatus ShopStatus
		{
			get;
			set;
		}

		public DateTime CreateDate
		{
			get;
			set;
		}

		public DateTime? EndDate
		{
			get;
			set;
		}

		public string CompanyName
		{
			get;
			set;
		}

		public int CompanyRegionId
		{
			get;
			set;
		}

		public string CompanyAddress
		{
			get;
			set;
		}

		public string CompanyPhone
		{
			get;
			set;
		}

		public long VShopId
		{
			get;
			set;
		}

		public int? SaleSum
		{
			get;
			set;
		}

		public int? ProductCount
		{
			get;
			set;
		}

		[NotMapped]
		public List<DistributionProductModel> ProductList
		{
			get;
			set;
		}
	}
}
