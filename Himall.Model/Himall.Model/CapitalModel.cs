using System;

namespace Himall.Model
{
	public class CapitalModel
	{
		public long Id
		{
			get;
			set;
		}

		public long UserId
		{
			get;
			set;
		}

		public string UserCode
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public decimal Balance
		{
			get;
			set;
		}

		public decimal FreezeAmount
		{
			get;
			set;
		}

		public decimal ChargeAmount
		{
			get;
			set;
		}
	}
}
