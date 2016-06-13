using System;

namespace Himall.Model
{
	public class SendMsgInfo
	{
		public string AppId
		{
			get;
			set;
		}

		public string AppSecret
		{
			get;
			set;
		}

		public string MediaId
		{
			get;
			set;
		}

		public string Content
		{
			get;
			set;
		}

		public SendToUserLabel ToUserLabel
		{
			get;
			set;
		}

		public WXMsgType MsgType
		{
			get;
			set;
		}

		public string ToUserDesc
		{
			get;
			set;
		}
	}
}
