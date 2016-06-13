using System;

namespace Himall.Model
{
	public class BrowsingHistoryInfo : BaseModel
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

		public long MemberId
		{
			get;
			set;
		}

		public long ProductId
		{
			get;
			set;
		}

		public DateTime BrowseTime
		{
			get;
			set;
		}

		public virtual UserMemberInfo Himall_Members
		{
			get;
			set;
		}

		public virtual ProductInfo Himall_Products
		{
			get;
			set;
		}
	}
}
