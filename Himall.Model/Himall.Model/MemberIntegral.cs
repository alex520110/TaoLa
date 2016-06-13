using System;
using System.ComponentModel;

namespace Himall.Model
{
	public class MemberIntegral : BaseModel
	{
		public enum IntegralType
		{
			[Description("交易获得")]
			Consumption = 1,
			[Description("积分抵扣")]
			Exchange,
			[Description("会员邀请")]
			InvitationMemberRegiste,
			[Description("每日登录")]
			Login = 5,
			[Description("绑定微信")]
			BindWX,
			[Description("订单评价")]
			Comment,
			[Description("管理员操作")]
			SystemOper,
			[Description("完善用户信息")]
			Reg,
			[Description("取消订单")]
			Cancel,
			[Description("其他")]
			Others,
			[Description("签到")]
			SignIn
		}

		public enum VirtualItemType
		{
			[Description("兑换")]
			Exchange = 1,
			[Description("邀请会员")]
			InvitationMember,
			[Description("返利消费")]
			ProportionRebate,
			[Description("评论")]
			Comment,
			[Description("交易获得")]
			Consumption,
			[Description("取消订单")]
			Cancel
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

		public long? MemberId
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public int HistoryIntegrals
		{
			get;
			set;
		}

		public int AvailableIntegrals
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
