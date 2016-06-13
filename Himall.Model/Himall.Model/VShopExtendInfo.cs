using System;
using System.ComponentModel;

namespace Himall.Model
{
	public class VShopExtendInfo : BaseModel
	{
		public enum VShopExtendType
		{
			[Description("主推微店")]
			TopShow = 1,
			[Description("热门微店")]
			HotVShop
		}

		public enum VShopExtendState
		{
			[Description("未审核")]
			NotAudit = 1,
			[Description("审核通过")]
			Through,
			[Description("审核拒绝")]
			Refused,
			[Description("微店已关闭")]
			Close
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

		public long VShopId
		{
			get;
			set;
		}

		public int? Sequence
		{
			get;
			set;
		}

		public VShopExtendInfo.VShopExtendType Type
		{
			get;
			set;
		}

		public DateTime AddTime
		{
			get;
			set;
		}

		public int State
		{
			get;
			set;
		}

		public virtual VShopInfo VShopInfo
		{
			get;
			set;
		}
	}
}
