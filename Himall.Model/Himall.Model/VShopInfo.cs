using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Himall.Model
{
	public class VShopInfo : BaseModel
	{
		public enum VshopStates
		{
			[Description("未审核")]
			NotAudit = 1,
			[Description("审核通过")]
			Normal,
			[Description("审核拒绝")]
			Refused,
			[Description("开启微店第一步")]
			Step1,
			[Description("开启微店第二步")]
			Step2,
			[Description("开启微店第三步")]
			Step3,
			[Description("已关闭")]
			Close = 99
		}

		private long _id;

		public string Logo
		{
			get
			{
				return this.ImageServerUrl + this.logo;
			}
			set
			{
				if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(this.ImageServerUrl))
				{
					this.logo = value.Replace(this.ImageServerUrl, "");
				}
				else
				{
					this.logo = value;
				}
			}
		}

		public string BackgroundImage
		{
			get
			{
				return this.ImageServerUrl + this.backgroundImage;
			}
			set
			{
				if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(this.ImageServerUrl))
				{
					this.backgroundImage = value.Replace(this.ImageServerUrl, "");
				}
				else
				{
					this.backgroundImage = value;
				}
			}
		}

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

		public string Name
		{
			get;
			set;
		}

		public long ShopId
		{
			get;
			set;
		}

		public DateTime CreateTime
		{
			get;
			set;
		}

		public int VisitNum
		{
			get;
			set;
		}

		public int buyNum
		{
			get;
			set;
		}

		public VShopInfo.VshopStates State
		{
			get;
			set;
		}

		private string logo
		{
			get;
			set;
		}

		private string backgroundImage
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public string Tags
		{
			get;
			set;
		}

		public string HomePageTitle
		{
			get;
			set;
		}

		public string WXLogo
		{
			get;
			set;
		}

		public virtual ShopInfo Himall_Shops
		{
			get;
			set;
		}

		public virtual ICollection<VShopExtendInfo> VShopExtendInfo
		{
			get;
			set;
		}

		public VShopInfo()
		{
			this.VShopExtendInfo = new HashSet<VShopExtendInfo>();
		}
	}
}
