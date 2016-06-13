using Himall.Model;
using System;

namespace TaoLa.IServices.QueryModel
{
	public class ShopQuery : QueryBase
	{
		public long? ShopGradeId
		{
			get;
			set;
		}

		public ShopInfo.ShopAuditStatus? Status
		{
			get;
			set;
		}

		public string ShopName
		{
			get;
			set;
		}

		public string ShopAccount
		{
			get;
			set;
		}

		public long CategoryId
		{
			get;
			set;
		}

		public long BrandId
		{
			get;
			set;
		}

		public int OrderBy
		{
			get;
			set;
		}
	}
}
