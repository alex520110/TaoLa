using System;

namespace Himall.Model
{
	public class RolePrivilegeInfo : BaseModel
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

		public int Privilege
		{
			get;
			set;
		}

		public long RoleId
		{
			get;
			set;
		}

		public virtual RoleInfo RoleInfo
		{
			get;
			set;
		}
	}
}
