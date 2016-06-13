using Himall.Model;
using System;

namespace TaoLa.IServices.QueryModel
{
	public class LimitTimeQuery : QueryBase
	{
		public LimitTimeMarketInfo.LimitTimeMarketAuditStatus? AuditStatus
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

		public string ItemName
		{
			get;
			set;
		}

		public string CategoryName
		{
			get;
			set;
		}

		public int OrderType
		{
			get;
			set;
		}

		public int OrderKey
		{
			get;
			set;
		}

		public bool CheckProductStatus
		{
			get;
			set;
		}
	}
}
