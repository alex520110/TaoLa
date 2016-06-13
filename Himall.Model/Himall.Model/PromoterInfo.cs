using System;
using System.ComponentModel;

namespace Himall.Model
{
	public class PromoterInfo : BaseModel
	{
		public enum PromoterStatus
		{
			[Description("未审核")]
			UnAudit,
			[Description("已审核")]
			Audited,
			[Description("已拒绝")]
			Refused,
			[Description("已清退")]
			NotAvailable
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

		public long? UserId
		{
			get;
			set;
		}

		public string ShopName
		{
			get;
			set;
		}

		public PromoterInfo.PromoterStatus Status
		{
			get;
			set;
		}

		public DateTime? ApplyTime
		{
			get;
			set;
		}

		public DateTime? PassTime
		{
			get;
			set;
		}

		public string Remark
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
