using System;

namespace Himall.Model
{
	public class MemberIntegralRecordAction : BaseModel
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

		public long IntegralRecordId
		{
			get;
			set;
		}

		public MemberIntegral.VirtualItemType? VirtualItemTypeId
		{
			get;
			set;
		}

		public long VirtualItemId
		{
			get;
			set;
		}

		public virtual MemberIntegralRecord Himall_MemberIntegralRecord
		{
			get;
			set;
		}
	}
}
