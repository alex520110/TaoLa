using System;
using System.Collections.Generic;

namespace TaoLa.IServices.QueryModel
{
	public class SellerQuery : QueryBase
	{
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

		public int? RegionId
		{
			get;
			set;
		}

		public int? NextRegionId
		{
			get;
			set;
		}
	}
}
