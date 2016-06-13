using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class SiteSettingsInfo : BaseModel
	{
		private long _id;

		[NotMapped]
		public string SiteName
		{
			get;
			set;
		}

		[NotMapped]
		public string ICPNubmer
		{
			get;
			set;
		}

		[NotMapped]
		public string CustomerTel
		{
			get;
			set;
		}

		[NotMapped]
		public bool SiteIsClose
		{
			get;
			set;
		}

		[NotMapped]
		public bool MobileVerifOpen
		{
			get;
			set;
		}

		[NotMapped]
		public string Logo
		{
			get;
			set;
		}

		[NotMapped]
		public string WXLogo
		{
			get;
			set;
		}

		[NotMapped]
		public string PCLoginPic
		{
			get;
			set;
		}

		[NotMapped]
		public string PCBottomPic
		{
			get;
			set;
		}

		[NotMapped]
		public string Keyword
		{
			get;
			set;
		}

		[NotMapped]
		public string Hotkeywords
		{
			get;
			set;
		}

		[NotMapped]
		public string PageFoot
		{
			get;
			set;
		}

		[NotMapped]
		public string WeixinAppId
		{
			get;
			set;
		}

		[NotMapped]
		public string WeixinAppSecret
		{
			get;
			set;
		}

		[NotMapped]
		public string WeixinToken
		{
			get;
			set;
		}

		[NotMapped]
		public string WeixinPartnerID
		{
			get;
			set;
		}

		[NotMapped]
		public string WeixinPartnerKey
		{
			get;
			set;
		}

		[NotMapped]
		public string WeixinLoginUrl
		{
			get;
			set;
		}

		[NotMapped]
		public bool WeixinIsValidationService
		{
			get;
			set;
		}

		[NotMapped]
		public string UserCookieKey
		{
			get;
			set;
		}

		public string SellerAdminAgreement
		{
			get;
			set;
		}

		[NotMapped]
		public decimal AdvancePaymentPercent
		{
			get;
			set;
		}

		[NotMapped]
		public decimal AdvancePaymentLimit
		{
			get;
			set;
		}

		[NotMapped]
		public int WeekSettlement
		{
			get;
			set;
		}

		[NotMapped]
		public string MemberLogo
		{
			get;
			set;
		}

		[NotMapped]
		public string QRCode
		{
			get;
			set;
		}

		[NotMapped]
		public string FlowScript
		{
			get;
			set;
		}

		[NotMapped]
		public string Site_SEOTitle
		{
			get;
			set;
		}

		[NotMapped]
		public string Site_SEOKeywords
		{
			get;
			set;
		}

		[NotMapped]
		public string Site_SEODescription
		{
			get;
			set;
		}

		public int UnpaidTimeout
		{
			get;
			set;
		}

		public int NoReceivingTimeout
		{
			get;
			set;
		}

		public int SalesReturnTimeout
		{
			get;
			set;
		}

		public int ProdutAuditOnOff
		{
			get;
			set;
		}

		[NotMapped]
		public string WX_MSGGetCouponTemplateId
		{
			get;
			set;
		}

		[NotMapped]
		public string AndriodDownLoad
		{
			get;
			set;
		}

		[NotMapped]
		public string IOSDownLoad
		{
			get;
			set;
		}

		[NotMapped]
		public bool CanDownload
		{
			get;
			set;
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

        public string Key
		{
			get;
			set;
		}

        public string Value
		{
			get;
			set;
		}
	}
}
