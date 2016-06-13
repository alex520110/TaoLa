using System;

namespace Himall.Model
{
	public class PaymentType
	{
		public string Id
		{
			get;
			set;
		}

		public string DisplayName
		{
			get;
			set;
		}

		public PaymentType()
		{
		}

		public PaymentType(string id, string name)
		{
			this.Id = id;
			this.DisplayName = name;
		}
	}
}
