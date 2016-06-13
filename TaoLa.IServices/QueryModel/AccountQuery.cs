using Himall.Model;
using System;
using TaoLa.IServices.QueryModel;

namespace Himall.IServices.QueryModel
{
	public class AccountQuery : QueryBase
	{
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

		public AccountInfo.AccountStatus? Status
		{
			get;
			set;
		}

		public AccountDetailInfo.EnumOrderType EnumOrderType
		{
			get;
			set;
		}

		public long? ShopId
		{
			get;
			set;
		}

		public string ShopName
		{
			get;
			set;
		}

		public long AccountId
		{
			get;
			set;
		}
	}
}
