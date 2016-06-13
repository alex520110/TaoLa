using System;
using System.ComponentModel;

namespace Himall.Model
{
	public class ShopBrandApplysInfo : BaseModel
	{
		public enum BrandAuditStatus
		{
			[Description("未审核")]
			UnAudit,
			[Description("通过审核")]
			Audited,
			[Description("拒绝通过")]
			Refused
		}

		public enum BrandApplyMode
		{
			[Description("平台已有品牌")]
			Exist = 1,
			[Description("新品牌")]
			New
		}

		private int _id;

		public new int Id
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

		public long ShopId
		{
			get;
			set;
		}

		public long? BrandId
		{
			get;
			set;
		}

		public string BrandName
		{
			get;
			set;
		}

		public string Logo
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public string AuthCertificate
		{
			get;
			set;
		}

		public int ApplyMode
		{
			get;
			set;
		}

		public string Remark
		{
			get;
			set;
		}

		public int AuditStatus
		{
			get;
			set;
		}

		public DateTime ApplyTime
		{
			get;
			set;
		}

		public virtual BrandInfo Himall_Brands
		{
			get;
			set;
		}

		public virtual ShopInfo Himall_Shops
		{
			get;
			set;
		}
	}
}
