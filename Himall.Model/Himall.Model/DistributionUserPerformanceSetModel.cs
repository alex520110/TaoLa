using System;

namespace Himall.Model
{
	public class DistributionUserPerformanceSetModel
	{
		public long UserId
		{
			get;
			set;
		}

		public decimal Day7SumIncome
		{
			get;
			set;
		}

		public decimal Day7Settled
		{
			get;
			set;
		}

		public decimal Day7NoSettled
		{
			get;
			set;
		}

		public decimal SumIncome
		{
			get;
			set;
		}

		public decimal SumSettled
		{
			get;
			set;
		}

		public decimal SumNoSettled
		{
			get;
			set;
		}

		public decimal MonthSumIncome
		{
			get;
			set;
		}

		public decimal MonthSumSettled
		{
			get;
			set;
		}

		public decimal MonthSumNoSettled
		{
			get;
			set;
		}

		public int SumOrderCount
		{
			get;
			set;
		}

		public int MonthSumOrderCount
		{
			get;
			set;
		}

		public int SumCustomer
		{
			get;
			set;
		}

		public int MonthNewCustomer
		{
			get;
			set;
		}
	}
}
