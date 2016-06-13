using System;

namespace TaoLa.IServices.QueryModel
{
	public class CashDepositDetailQuery : QueryBase
	{
		public long CashDepositId
		{
			get;
			set;
		}

		public string Operator
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
	}
}
