using System;

namespace Himall.Model
{
	public class MemberOpenIdInfo : BaseModel
	{
		public enum AppIdTypeEnum
		{
			Payment,
			Normal
		}

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

		public long UserId
		{
			get;
			set;
		}

		public string OpenId
		{
			get;
			set;
		}

		public string ServiceProvider
		{
			get;
			set;
		}

		public MemberOpenIdInfo.AppIdTypeEnum AppIdType
		{
			get;
			set;
		}

		public string UnionId
		{
			get;
			set;
		}

		public string UnionOpenId
		{
			get;
			set;
		}

		public virtual UserMemberInfo MemberInfo
		{
			get;
			set;
		}
	}
}
