using System;

namespace Himall.Model
{
	public class MemberIntegralRule : BaseModel
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

		public int TypeId
		{
			get;
			set;
		}

		public int Integral
		{
			get;
			set;
		}
	}
}
