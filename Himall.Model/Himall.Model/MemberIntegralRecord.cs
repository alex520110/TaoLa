using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class MemberIntegralRecord : BaseModel
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

		public string UserName
		{
			get;
			set;
		}

		public MemberIntegral.IntegralType TypeId
		{
			get;
			set;
		}

		public int Integral
		{
			get;
			set;
		}

		public DateTime? RecordDate
		{
			get;
			set;
		}

		public string ReMark
		{
			get;
			set;
		}

		public virtual UserMemberInfo Himall_Members
		{
			get;
			set;
		}

		public virtual ICollection<MemberIntegralRecordAction> Himall_MemberIntegralRecordAction
		{
			get;
			set;
		}

		public MemberIntegralRecord()
		{
			this.Himall_MemberIntegralRecordAction = new HashSet<MemberIntegralRecordAction>();
		}
	}
}
