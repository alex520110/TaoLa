using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class FlashSaleModel
	{
		public long Id
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public long ShopId
		{
			get;
			set;
		}

		public string ShopName
		{
			get;
			set;
		}

		public long ProductId
		{
			get;
			set;
		}

		public string ProductName
		{
			get;
			set;
		}

		public FlashSaleInfo.FlashSaleStatus Status
		{
			get;
			set;
		}

		public string StatusStr
		{
			get;
			set;
		}

		public int StatusNum
		{
			get;
			set;
		}

		public string BeginDate
		{
			get;
			set;
		}

		public string EndDate
		{
			get;
			set;
		}

		public int LimitCountOfThePeople
		{
			get;
			set;
		}

		public int SaleCount
		{
			get;
			set;
		}

		public List<FlashSaleDetailModel> Details
		{
			get;
			set;
		}

		public string CategoryName
		{
			get;
			set;
		}

		public string ProductImg
		{
			get;
			set;
		}

		public decimal MinPrice
		{
			get;
			set;
		}

		public decimal MarketPrice
		{
			get;
			set;
		}
	}
}
