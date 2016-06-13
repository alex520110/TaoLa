using Himall.Model;
using System;

namespace TaoLa.IServices.QueryModel
{
	public class DistributionQuery : QueryBase
	{
		public string ProductName
		{
			get;
			set;
		}

		public ProductBrokerageInfo.ProductBrokerageStatus? Status
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
	}
}
