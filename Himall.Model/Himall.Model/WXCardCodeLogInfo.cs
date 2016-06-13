using System;

namespace Himall.Model
{
	public class WXCardCodeLogInfo : BaseModel
	{
		public enum CodeStatusEnum
		{
			Normal = 1,
			WaitReceive = 0,
			HasFailed = -1,
			HasConsume = 2,
			HasDelete
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

		public long? CardLogId
		{
			get;
			set;
		}

		public string CardId
		{
			get;
			set;
		}

		public string Code
		{
			get;
			set;
		}

		public DateTime? SendTime
		{
			get;
			set;
		}

		public int CodeStatus
		{
			get;
			set;
		}

		public DateTime? UsedTime
		{
			get;
			set;
		}

		public WXCardLogInfo.CouponTypeEnum? CouponType
		{
			get;
			set;
		}

		public long? CouponCodeId
		{
			get;
			set;
		}

		public string OpenId
		{
			get;
			set;
		}

		public virtual WXCardLogInfo Himall_WXCardLog
		{
			get;
			set;
		}
	}
}
