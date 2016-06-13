using System;
using System.ComponentModel;

namespace Himall.Model
{
	public class MemberContactsInfo : BaseModel
	{
		public enum UserTypes
		{
			[Description("普通用户")]
			General,
			[Description("店铺用户")]
			ShopManager
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

		public string ServiceProvider
		{
			get;
			set;
		}

		public string Contact
		{
			get;
			set;
		}

		public MemberContactsInfo.UserTypes UserType
		{
			get;
			set;
		}
	}
}
