using System;
using System.ComponentModel;

namespace Himall.Model
{
	public class ChargeDetailInfo : BaseModel
	{
		public enum ChargeDetailStatus
		{
			[Description("未付款")]
			WaitPay = 1,
			[Description("充值成功")]
			ChargeSuccess
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

		public DateTime? ChargeTime
		{
			get;
			set;
		}

		public decimal ChargeAmount
		{
			get;
			set;
		}

		public string ChargeWay
		{
			get;
			set;
		}

		public ChargeDetailInfo.ChargeDetailStatus ChargeStatus
		{
			get;
			set;
		}

		public DateTime? CreateTime
		{
			get;
			set;
		}
	}
}
