using System;
using System.ComponentModel;

namespace Himall.Model
{
	public class CapitalDetailInfo : BaseModel
	{
		public enum CapitalDetailType
		{
			[Description("领取红包")]
			RedPacket = 1,
			[Description("充值")]
			ChargeAmount,
			[Description("提现")]
			WithDraw,
			[Description("消费")]
			Consume,
			[Description("退款")]
			Refund,
			[Description("佣金收入")]
			Brokerage
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

		public long CapitalID
		{
			get;
			set;
		}

		public CapitalDetailInfo.CapitalDetailType SourceType
		{
			get;
			set;
		}

		public decimal Amount
		{
			get;
			set;
		}

		public string SourceData
		{
			get;
			set;
		}

		public DateTime? CreateTime
		{
			get;
			set;
		}

		public string Remark
		{
			get;
			set;
		}

		public virtual CapitalInfo Himall_Capital
		{
			get;
			set;
		}
	}
}
