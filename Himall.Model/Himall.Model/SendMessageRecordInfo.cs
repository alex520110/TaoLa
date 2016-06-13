using System;

namespace Himall.Model
{
	public class SendMessageRecordInfo : BaseModel
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

		public MsgType MessageType
		{
			get;
			set;
		}

		public WXMsgType ContentType
		{
			get;
			set;
		}

		public string SendContent
		{
			get;
			set;
		}

		public string ToUserLabel
		{
			get;
			set;
		}

		public int? SendState
		{
			get;
			set;
		}

		public DateTime? SendTime
		{
			get;
			set;
		}
	}
}
