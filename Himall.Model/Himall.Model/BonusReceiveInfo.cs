using System;

namespace Himall.Model
{
	public class BonusReceiveInfo : BaseModel
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

		public long BonusId
		{
			get;
			set;
		}

		public string OpenId
		{
			get;
			set;
		}

		public DateTime? ReceiveTime
		{
			get;
			set;
		}

		public decimal Price
		{
			get;
			set;
		}

		public bool? IsShare
		{
			get;
			set;
		}

		public bool IsTransformedDeposit
		{
			get;
			set;
		}

		public long? UserId
		{
			get;
			set;
		}

		public virtual BonusInfo Himall_Bonus
		{
			get;
			set;
		}

		public virtual UserMemberInfo Himall_Members
		{
			get;
			set;
		}
	}
}
