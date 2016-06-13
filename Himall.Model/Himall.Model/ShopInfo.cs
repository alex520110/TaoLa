using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class ShopInfo : BaseModel
	{
		public enum ShopAuditStatus
		{
			[Description("不可用")]
			Unusable = 1,
			[Description("待审核")]
			WaitAudit,
			[Description("待付款")]
			WaitPay,
			[Description("被拒绝")]
			Refuse,
			[Description("待确认")]
			WaitConfirm,
			[Description("冻结")]
			Freeze,
			[Description("开启")]
			Open,
			[Description("己过期")]
			HasExpired = -1
		}

		public enum ShopStage
		{
			[Description("许可协议")]
			Agreement,
			[Description("公司信息")]
			CompanyInfo,
			[Description("财务信息")]
			FinancialInfo,
			[Description("店铺信息")]
			ShopInfo,
			[Description("上传支付凭证")]
			UploadPayOrder,
			[Description("完成")]
			Finish
		}

		public class ShopVistis
		{
			public decimal VistiCounts
			{
				get;
				set;
			}

			public decimal SaleCounts
			{
				get;
				set;
			}

			public decimal SaleAmounts
			{
				get;
				set;
			}

			public decimal OrderCounts
			{
				get;
				set;
			}
		}

		private long _id;

		[NotMapped]
		public ShopInfo.ShopAuditStatus ShowShopAuditStatus
		{
			get
			{
				ShopInfo.ShopAuditStatus result = ShopInfo.ShopAuditStatus.Unusable;
				if (this != null)
				{
					result = this.ShopStatus;
					if (this.EndDate.HasValue && this.ShopStatus == ShopInfo.ShopAuditStatus.Open)
					{
						DateTime d = this.EndDate.Value.Date.AddDays(1.0).AddSeconds(-1.0);
						if ((d - DateTime.Now).TotalSeconds < 0.0)
						{
							result = ShopInfo.ShopAuditStatus.HasExpired;
						}
					}
				}
				return result;
			}
		}

		[NotMapped]
		public string ShopAccount
		{
			get;
			set;
		}

		[NotMapped]
		public Dictionary<long, decimal> BusinessCategory
		{
			get;
			set;
		}

		[NotMapped]
		public string CompanyRegionAddress
		{
			get;
			set;
		}

		[NotMapped]
		public int Sales
		{
			get;
			set;
		}

		[NotMapped]
		public string ProductAndDescription
		{
			get;
			set;
		}

		[NotMapped]
		public string SellerServiceAttitude
		{
			get;
			set;
		}

		[NotMapped]
		public string SellerDeliverySpeed
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

		public long GradeId
		{
			get;
			set;
		}

		public string ShopName
		{
			get;
			set;
		}

		public string SubDomains
		{
			get;
			set;
		}

		public string Theme
		{
			get;
			set;
		}

		public bool IsSelf
		{
			get;
			set;
		}

		public ShopInfo.ShopAuditStatus ShopStatus
		{
			get;
			set;
		}

		public string RefuseReason
		{
			get;
			set;
		}

		public DateTime CreateDate
		{
			get;
			set;
		}

		public DateTime? EndDate
		{
			get;
			set;
		}

		public string CompanyName
		{
			get;
			set;
		}

		public int CompanyRegionId
		{
			get;
			set;
		}

		public string CompanyAddress
		{
			get;
			set;
		}

		public string CompanyPhone
		{
			get;
			set;
		}

		public CompanyEmployeeCount CompanyEmployeeCount
		{
			get;
			set;
		}

		public decimal CompanyRegisteredCapital
		{
			get;
			set;
		}

		public string ContactsName
		{
			get;
			set;
		}

		public string ContactsPhone
		{
			get;
			set;
		}

		public string ContactsEmail
		{
			get;
			set;
		}

		public string BusinessLicenceNumber
		{
			get;
			set;
		}

		public string BusinessLicenceNumberPhoto
		{
			get;
			set;
		}

		public int BusinessLicenceRegionId
		{
			get;
			set;
		}

		public DateTime? BusinessLicenceStart
		{
			get;
			set;
		}

		public DateTime? BusinessLicenceEnd
		{
			get;
			set;
		}

		public string BusinessSphere
		{
			get;
			set;
		}

		public string OrganizationCode
		{
			get;
			set;
		}

		public string OrganizationCodePhoto
		{
			get;
			set;
		}

		public string GeneralTaxpayerPhot
		{
			get;
			set;
		}

		public string BankAccountName
		{
			get;
			set;
		}

		public string BankAccountNumber
		{
			get;
			set;
		}

		public string BankName
		{
			get;
			set;
		}

		public string BankCode
		{
			get;
			set;
		}

		public int BankRegionId
		{
			get;
			set;
		}

		public string BankPhoto
		{
			get;
			set;
		}

		public string TaxRegistrationCertificate
		{
			get;
			set;
		}

		public string TaxpayerId
		{
			get;
			set;
		}

		public string TaxRegistrationCertificatePhoto
		{
			get;
			set;
		}

		public string PayPhoto
		{
			get;
			set;
		}

		public string PayRemark
		{
			get;
			set;
		}

		public string SenderName
		{
			get;
			set;
		}

		public string SenderAddress
		{
			get;
			set;
		}

		public string SenderPhone
		{
			get;
			set;
		}

		public decimal Freight
		{
			get;
			set;
		}

		public decimal FreeFreight
		{
			get;
			set;
		}

		public string Logo
		{
			get;
			set;
		}

		public ShopInfo.ShopStage? Stage
		{
			get;
			set;
		}

		public int? SenderRegionId
		{
			get;
			set;
		}

		public string BusinessLicenseCert
		{
			get;
			set;
		}

		public string ProductCert
		{
			get;
			set;
		}

		public string OtherCert
		{
			get;
			set;
		}

		public string legalPerson
		{
			get;
			set;
		}

		public DateTime? CompanyFoundingDate
		{
			get;
			set;
		}

		public virtual ICollection<FavoriteShopInfo> Himall_FavoriteShops
		{
			get;
			set;
		}

		public virtual ICollection<MenuInfo> Himall_Menus
		{
			get;
			set;
		}

		public virtual ICollection<MessageLog> Himall_MessageLog
		{
			get;
			set;
		}

		public virtual ICollection<CashDepositInfo> Himall_CashDeposit
		{
			get;
			set;
		}

		public virtual ICollection<ShopBrandApplysInfo> Himall_ShopBrandApplys
		{
			get;
			set;
		}

		public virtual ICollection<ShopBrandsInfo> Himall_ShopBrands
		{
			get;
			set;
		}

		public virtual ICollection<StatisticOrderCommentsInfo> Himall_StatisticOrderComments
		{
			get;
			set;
		}

		public virtual ICollection<ProductCommentInfo> Himall_ProductComments
		{
			get;
			set;
		}

		public virtual ICollection<CouponInfo> Himall_Coupon
		{
			get;
			set;
		}

		public virtual ICollection<CouponRecordInfo> Himall_CouponRecord
		{
			get;
			set;
		}

		public virtual ICollection<VShopInfo> Himall_VShop
		{
			get;
			set;
		}

		public virtual ICollection<ProductInfo> Himall_Products
		{
			get;
			set;
		}

		public virtual ICollection<ShopBonusInfo> Himall_ShopBonus
		{
			get;
			set;
		}

		public virtual ICollection<FlashSaleInfo> Himall_FlashSale
		{
			get;
			set;
		}

		public virtual ICollection<ProductBrokerageInfo> Himall_ProductBrokerage
		{
			get;
			set;
		}

		public virtual ICollection<ReceivingAddressInfo> Himall_ReceivingAddressConfig
		{
			get;
			set;
		}

		public ShopInfo()
		{
			this.Himall_FavoriteShops = new HashSet<FavoriteShopInfo>();
			this.Himall_Menus = new HashSet<MenuInfo>();
			this.Himall_MessageLog = new HashSet<MessageLog>();
			this.Himall_CashDeposit = new HashSet<CashDepositInfo>();
			this.Himall_ShopBrandApplys = new HashSet<ShopBrandApplysInfo>();
			this.Himall_ShopBrands = new HashSet<ShopBrandsInfo>();
			this.Himall_StatisticOrderComments = new HashSet<StatisticOrderCommentsInfo>();
			this.Himall_ProductComments = new HashSet<ProductCommentInfo>();
			this.Himall_Coupon = new HashSet<CouponInfo>();
			this.Himall_CouponRecord = new HashSet<CouponRecordInfo>();
			this.Himall_VShop = new HashSet<VShopInfo>();
			this.Himall_Products = new HashSet<ProductInfo>();
			this.Himall_ShopBonus = new HashSet<ShopBonusInfo>();
			this.Himall_FlashSale = new HashSet<FlashSaleInfo>();
			this.Himall_ProductBrokerage = new HashSet<ProductBrokerageInfo>();
			this.Himall_ReceivingAddressConfig = new HashSet<ReceivingAddressInfo>();
		}
	}
}
