using System;

namespace Himall.Model
{
	public class MemberGrade : BaseModel
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

		public string GradeName
		{
			get;
			set;
		}

		public int Integral
		{
			get;
			set;
		}

		public string Remark
		{
			get;
			set;
		}

		public bool IsNoDelete
		{
			get;
			set;
		}
	}
}
