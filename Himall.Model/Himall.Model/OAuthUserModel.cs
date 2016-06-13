using System;

namespace Himall.Model
{
	public class OAuthUserModel
	{
		public long UserId
		{
			get;
			set;
		}

		public MemberOpenIdInfo.AppIdTypeEnum AppIdType
		{
			get;
			set;
		}

		public string OpenId
		{
			get;
			set;
		}

		public string UnionId
		{
			get;
			set;
		}

		public string NickName
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}

		public long? introducer
		{
			get;
			set;
		}

		public string RealName
		{
			get;
			set;
		}

		public string Headimgurl
		{
			get;
			set;
		}

		public string LoginProvider
		{
			get;
			set;
		}

		public string Sex
		{
			get;
			set;
		}

		public string Province
		{
			get;
			set;
		}

		public string City
		{
			get;
			set;
		}

		public string Country
		{
			get;
			set;
		}
	}
}
