using System;

namespace Himall.Model
{
	public class DistributionUserLinkInfo : BaseModel
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

		public long PartnerId
		{
			get;
			set;
		}

		public long ShopId
		{
			get;
			set;
		}

		public DateTime? LinkTime
		{
			get;
			set;
		}

		public long BuyUserId
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
