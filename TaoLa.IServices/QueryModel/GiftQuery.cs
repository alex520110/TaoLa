using Himall.Model;
using System;

namespace TaoLa.IServices.QueryModel
{
	public class GiftQuery : QueryBase
	{
		public enum GiftSortEnum
		{
			Default,
			SalesNumber,
			RealSalesNumber
		}

		public string skey
		{
			get;
			set;
		}

		public GiftInfo.GiftSalesStatus? status
		{
			get;
			set;
		}

		public bool? isShowAll
		{
			get;
			set;
		}

		public new GiftQuery.GiftSortEnum Sort
		{
			get;
			set;
		}
	}
}
