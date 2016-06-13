using System;

namespace Himall.Model
{
	public class SendToUserLabel
	{
		public long[] LabelIds
		{
			get;
			set;
		}

		public UserMemberInfo.SexType? Sex
		{
			get;
			set;
		}

		public long? ProvinceId
		{
			get;
			set;
		}
	}
}
