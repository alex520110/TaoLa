using System;

namespace Himall.Model
{
	public class MemberAccountSafety
	{
		public bool PayPassword
		{
			get;
			set;
		}

		public bool BindEmail
		{
			get;
			set;
		}

		public bool BindPhone
		{
			get;
			set;
		}

		public int AccountSafetyLevel
		{
			get;
			set;
		}
	}
}
