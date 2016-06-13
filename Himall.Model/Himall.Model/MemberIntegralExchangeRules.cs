using System;

namespace Himall.Model
{
	public class MemberIntegralExchangeRules : BaseModel
	{
		private long _id;

		public new long Id
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
				base.Id = value;
			}
		}

		public int IntegralPerMoney
		{
			get;
			set;
		}

		public int MoneyPerIntegral
		{
			get;
			set;
		}
	}
}
