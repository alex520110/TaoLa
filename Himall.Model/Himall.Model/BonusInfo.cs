using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Himall.Model
{
	public class BonusInfo : BaseModel
	{
		public enum BonusType
		{
			[Description("活动红包")]
			Activity = 1,
			[Description("关注红包")]
			Attention
		}

		public enum BonusStyle
		{
			[Description("模板1")]
			TempletOne = 1,
			[Description("模板2")]
			TempletTwo
		}

		public enum BonusPriceType
		{
			[Description("固定")]
			Fixed = 1,
			[Description("随机")]
			Random
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

		public BonusInfo.BonusType Type
		{
			get;
			set;
		}

		public BonusInfo.BonusStyle Style
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string MerchantsName
		{
			get;
			set;
		}

		public string Remark
		{
			get;
			set;
		}

		public string Blessing
		{
			get;
			set;
		}

		public decimal TotalPrice
		{
			get;
			set;
		}

		public DateTime StartTime
		{
			get;
			set;
		}

		public DateTime EndTime
		{
			get;
			set;
		}

		public string QRPath
		{
			get;
			set;
		}

		public decimal? FixedAmount
		{
			get;
			set;
		}

		public decimal? RandomAmountStart
		{
			get;
			set;
		}

		public decimal? RandomAmountEnd
		{
			get;
			set;
		}

		public int ReceiveCount
		{
			get;
			set;
		}

		public string ImagePath
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public bool IsInvalid
		{
			get;
			set;
		}

		public BonusInfo.BonusPriceType? PriceType
		{
			get;
			set;
		}

		public decimal ReceivePrice
		{
			get;
			set;
		}

		public string ReceiveHref
		{
			get;
			set;
		}

		public bool IsAttention
		{
			get;
			set;
		}

		public bool IsGuideShare
		{
			get;
			set;
		}

		public virtual ICollection<BonusReceiveInfo> Himall_BonusReceive
		{
			get;
			set;
		}

		public string TypeStr
		{
			get;
			set;
		}

		public string StartTimeStr
		{
			get;
			set;
		}

		public string EndTimeStr
		{
			get;
			set;
		}

		public BonusInfo()
		{
			this.Himall_BonusReceive = new HashSet<BonusReceiveInfo>();
		}
	}
}
