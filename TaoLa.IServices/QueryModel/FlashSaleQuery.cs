using Himall.Model;
using System;

namespace TaoLa.IServices.QueryModel
{
	public class FlashSaleQuery : QueryBase
	{
		public FlashSaleInfo.FlashSaleStatus? AuditStatus
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

		public int IsStart
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
