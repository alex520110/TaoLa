using System;
using System.ComponentModel;

namespace Himall.Model
{
	public class ApplyWithDrawInfo : BaseModel
	{
		public enum ApplyWithDrawStatus
		{
			[Description("待处理")]
			WaitConfirm = 1,
			[Description("付款失败")]
			PayFail,
			[Description("提现成功")]
			WithDrawSuccess,
			[Description("已拒绝")]
			Refuse
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

		public long MemId
		{
			get;
			set;
		}

		public string NickName
		{
			get;
			set;
		}

		public string OpenId
		{
			get;
			set;
		}

		public ApplyWithDrawInfo.ApplyWithDrawStatus ApplyStatus
		{
			get;
			set;
		}

		public decimal ApplyAmount
		{
			get;
			set;
		}

		public DateTime ApplyTime
		{
			get;
			set;
		}

		public DateTime? ConfirmTime
		{
			get;
			set;
		}

		public DateTime? PayTime
		{
			get;
			set;
		}

		public string PayNo
		{
			get;
			set;
		}

		public string OpUser
		{
			get;
			set;
		}

		public string Remark
		{
			get;
			set;
		}
	}
}
