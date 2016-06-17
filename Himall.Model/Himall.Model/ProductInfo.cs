using TaoLa.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class ProductInfo : BaseModel
	{
		public enum ProductSaleStatus
		{
			[Description("原始状态")]
			RawState,
			[Description("出售中")]
			OnSale,
			[Description("仓库中")]
			InStock,
			[Description("草稿箱")]
			InDraft,
			[Description("已删除")]
			InDelete
		}

		public enum ProductAuditStatus
		{
			[Description("待审核")]
			WaitForAuditing = 1,
			[Description("销售中")]
			Audited,
			[Description("未通过")]
			AuditFailed,
			[Description("违规下架")]
			InfractionSaleOff,
			[Description("未审核")]
			UnAudit
		}

		public enum ProductEditStatus
		{
			[Description("正常")]
			Normal,
			[Description("己修改")]
			Edited,
			[Description("待审核")]
			PendingAudit,
			[Description("己修改待审核")]
			EditedAndPending,
			[Description("强制待审核")]
			CompelPendingAudit,
			[Description("强制待审己修改")]
			CompelPendingHasEdited
		}

		public enum ImageSize
		{
			[Description("50×50")]
			Size_50 = 50,
			[Description("100×100")]
			Size_100 = 100,
			[Description("150×150")]
			Size_150 = 150,
			[Description("220×220")]
			Size_220 = 220,
			[Description("350×350")]
			Size_350 = 350
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

		public long ShopId
		{
			get;
			set;
		}

		public long CategoryId
		{
			get;
			set;
		}

		public string CategoryPath
		{
			get;
			set;
		}

		public long TypeId
		{
			get;
			set;
		}

		public long BrandId
		{
			get;
			set;
		}

		public string ProductName
		{
			get;
			set;
		}

		public string ProductCode
		{
			get;
			set;
		}

		public string ShortDescription
		{
			get;
			set;
		}

		public ProductInfo.ProductSaleStatus SaleStatus
		{
			get;
			set;
		}

		public DateTime AddedDate
		{
			get;
			set;
		}

		public long DisplaySequence
		{
			get;
			set;
		}

		private string imagePath
		{
			get;
			set;
		}

		public decimal MarketPrice
		{
			get;
			set;
		}

		public decimal MinSalePrice
		{
			get;
			set;
		}

		public bool HasSKU
		{
			get;
			set;
		}

		public long VistiCounts
		{
			get;
			set;
		}

		public long SaleCounts
		{
			get;
			set;
		}

		public ProductInfo.ProductAuditStatus AuditStatus
		{
			get;
			set;
		}

		public long FreightTemplateId
		{
			get;
			set;
		}

		public decimal? Weight
		{
			get;
			set;
		}

		public decimal? Volume
		{
			get;
			set;
		}

		public int? Quantity
		{
			get;
			set;
		}

		public string MeasureUnit
		{
			get;
			set;
		}

		public int EditStatus
		{
			get;
			set;
		}

		public virtual ICollection<ProductConsultationInfo> ProductConsultationInfo
		{
			get;
			set;
		}

		public virtual ICollection<ProductAttributeInfo> ProductAttributeInfo
		{
			get;
			set;
		}

		public virtual ProductDescriptionInfo ProductDescriptionInfo
		{
			get;
			set;
		}

		public virtual ICollection<SKUInfo> SKUInfo
		{
			get;
			set;
		}

		public virtual ICollection<FavoriteInfo> Himall_Favorites
		{
			get;
			set;
		}

		public virtual ICollection<FloorProductInfo> Himall_FloorProducts
		{
			get;
			set;
		}

		public virtual ICollection<ProductShopCategoryInfo> Himall_ProductShopCategories
		{
			get;
			set;
		}

		internal virtual ICollection<ShoppingCartItemInfo> Himall_ShoppingCarts
		{
			get;
			set;
		}

		public virtual ICollection<ProductCommentInfo> Himall_ProductComments
		{
			get;
			set;
		}

		public virtual ICollection<ModuleProductInfo> Himall_ModuleProducts
		{
			get;
			set;
		}

		public virtual ICollection<ShopHomeModuleProductInfo> Himall_ShopHomeModuleProducts
		{
			get;
			set;
		}

		public virtual ICollection<ProductVistiInfo> Himall_ProductVistis
		{
			get;
			set;
		}

		public virtual ICollection<BrowsingHistoryInfo> Himall_BrowsingHistory
		{
			get;
			set;
		}

		public virtual FreightTemplateInfo Himall_FreightTemplate
		{
			get;
			set;
		}

		public virtual ICollection<MobileHomeProductsInfo> Himall_MobileHomeProducts
		{
			get;
			set;
		}

		public virtual ICollection<FloorTablDetailsInfo> Himall_FloorTablDetails
		{
			get;
			set;
		}

		public virtual ShopInfo Himall_Shops
		{
			get;
			set;
		}

		public virtual CategoryInfo Himall_Categories
		{
			get;
			set;
		}

		public virtual ICollection<CollocationPoruductInfo> Himall_CollocationPoruducts
		{
			get;
			set;
		}

		public virtual ICollection<CollocationSkuInfo> Himall_CollocationSkus
		{
			get;
			set;
		}

		public virtual ICollection<AgentProductsInfo> Himall_AgentProducts
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

		public int ConcernedCount
		{
			get;
			set;
		}

		[NotMapped]
		public string ImagePath
		{
			get
			{
				return this.ImageServerUrl + this.imagePath;
			}
			set
			{
				if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(this.ImageServerUrl))
				{
					this.imagePath = value.Replace(this.ImageServerUrl, "");
				}
				else
				{
					this.imagePath = value;
				}
			}
		}

		[NotMapped]
		public IEnumerable<ShopCategoryInfo> ShopCateogryInfos
		{
			get;
			set;
		}

		[NotMapped]
		public long OrderCounts
		{
			get;
			set;
		}

		[NotMapped]
		public string Address
		{
			get;
			set;
		}

		[NotMapped]
		public string ShopName
		{
			get;
			set;
		}

		[NotMapped]
		public string BrandName
		{
			get;
			set;
		}

		[NotMapped]
		public string CategoryNames
		{
			get;
			set;
		}

		[NotMapped]
		public int IsCategory
		{
			get;
			set;
		}

		[NotMapped]
		public long TopId
		{
			get;
			set;
		}

		[NotMapped]
		public long BottomId
		{
			get;
			set;
		}

		[NotMapped]
		public string ShowProductState
		{
			get
			{
				string result = "错误数据";
				if (this != null)
				{
					if (this.AuditStatus == ProductInfo.ProductAuditStatus.WaitForAuditing)
					{
						result = ((this.SaleStatus == ProductInfo.ProductSaleStatus.OnSale) ? ProductInfo.ProductAuditStatus.WaitForAuditing.ToDescription() : ProductInfo.ProductSaleStatus.InStock.ToDescription());
					}
					else
					{
						result = this.AuditStatus.ToDescription();
					}
				}
				return result;
			}
		}

		public ProductInfo()
		{
			this.ProductConsultationInfo = new HashSet<ProductConsultationInfo>();
			this.ProductAttributeInfo = new HashSet<ProductAttributeInfo>();
			this.SKUInfo = new HashSet<SKUInfo>();
			this.Himall_Favorites = new HashSet<FavoriteInfo>();
			this.Himall_FloorProducts = new HashSet<FloorProductInfo>();
			this.Himall_ProductShopCategories = new HashSet<ProductShopCategoryInfo>();
			this.Himall_ShoppingCarts = new HashSet<ShoppingCartItemInfo>();
			this.Himall_ProductComments = new HashSet<ProductCommentInfo>();
			this.Himall_ModuleProducts = new HashSet<ModuleProductInfo>();
			this.Himall_ShopHomeModuleProducts = new HashSet<ShopHomeModuleProductInfo>();
			this.Himall_ProductVistis = new HashSet<ProductVistiInfo>();
			this.Himall_BrowsingHistory = new HashSet<BrowsingHistoryInfo>();
			this.Himall_MobileHomeProducts = new HashSet<MobileHomeProductsInfo>();
			this.Himall_FloorTablDetails = new HashSet<FloorTablDetailsInfo>();
			this.Himall_CollocationPoruducts = new HashSet<CollocationPoruductInfo>();
			this.Himall_CollocationSkus = new HashSet<CollocationSkuInfo>();
			this.Himall_AgentProducts = new HashSet<AgentProductsInfo>();
			this.Himall_FlashSale = new HashSet<FlashSaleInfo>();
			this.Himall_ProductBrokerage = new HashSet<ProductBrokerageInfo>();
		}

		public string GetImage(ProductInfo.ImageSize imageSize, int imageIndex = 1)
		{
			return string.Format(this.ImagePath + "/{0}_{1}.png", imageIndex, (int)imageSize);
		}
	}
}
