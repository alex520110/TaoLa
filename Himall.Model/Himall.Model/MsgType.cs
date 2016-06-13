using System;
using System.ComponentModel;

namespace Himall.Model
{
	public enum MsgType
	{
		[Description("微信")]
		WeiXin,
		[Description("邮件")]
		Email
	}
}
