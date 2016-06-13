using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Himall.Model
{
	public class UserMemberInfo : BaseModel
	{
		public enum SexType
		{
			[Description("男")]
			Male,
			[Description("女")]
			Female
		}

		private int _availableIntegrals;

		private int _historyIntegral;

		private long _id;

		public int AvailableIntegrals
		{
			get
			{
				return this._availableIntegrals;
			}
		}

		public int HistoryIntegral
		{
			get
			{
				return this._historyIntegral;
			}
		}

		public long MemberGradeId
		{
			get;
			set;
		}

		public string MemberGradeName
		{
			get;
			set;
		}

		[NotMapped]
		public string Photo
		{
			get
			{
				return this.ImageServerUrl + this.photo;
			}
			set
			{
				if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(this.ImageServerUrl))
				{
					this.photo = value.Replace(this.ImageServerUrl, "");
				}
				else
				{
					this.photo = value;
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

		public string UserName
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}

		public string PasswordSalt
		{
			get;
			set;
		}

		public string Email
		{
			get;
			set;
		}

		public DateTime CreateDate
		{
			get;
			set;
		}

		public int TopRegionId
		{
			get;
			set;
		}

		public int RegionId
		{
			get;
			set;
		}

		public string RealName
		{
			get;
			set;
		}

		public string CellPhone
		{
			get;
			set;
		}

		public string QQ
		{
			get;
			set;
		}

		public string Address
		{
			get;
			set;
		}

		public bool Disabled
		{
			get;
			set;
		}

		public DateTime LastLoginDate
		{
			get;
			set;
		}

		public int OrderNumber
		{
			get;
			set;
		}

		public decimal Expenditure
		{
			get;
			set;
		}

		public int Points
		{
			get;
			set;
		}

		public string Nick
		{
			get;
			set;
		}

		internal string photo
		{
			get;
			set;
		}

		public long ParentSellerId
		{
			get;
			set;
		}

		public string Remark
		{
			get;
			set;
		}

		public string PayPwd
		{
			get;
			set;
		}

		public string PayPwdSalt
		{
			get;
			set;
		}

		public long? InviteUserId
		{
			get;
			set;
		}

		public UserMemberInfo.SexType? Sex
		{
			get;
			set;
		}

		public long? ShareUserId
		{
			get;
			set;
		}

		public virtual ICollection<FavoriteInfo> FavoriteInfo
		{
			get;
			set;
		}

		public virtual ICollection<MemberOpenIdInfo> MemberOpenIdInfo
		{
			get;
			set;
		}

		public virtual ICollection<ShippingAddressInfo> ShippingAddressInfo
		{
			get;
			set;
		}

		internal virtual ICollection<ShoppingCartItemInfo> ShoppingCartInfo
		{
			get;
			set;
		}

		public virtual ICollection<FavoriteShopInfo> Himall_FavoriteShops
		{
			get;
			set;
		}

		public virtual ICollection<BrowsingHistoryInfo> Himall_BrowsingHistory
		{
			get;
			set;
		}

		public virtual ICollection<ProductCommentInfo> Himall_ProductComments
		{
			get;
			set;
		}

		public virtual ICollection<MemberIntegralRecord> Himall_MemberIntegralRecord
		{
			get;
			set;
		}

		public virtual ICollection<MemberIntegral> Himall_MemberIntegral
		{
			get;
			set;
		}

		public virtual ICollection<InviteRecordInfo> InviteMemberRecord
		{
			get;
			set;
		}

		public virtual ICollection<InviteRecordInfo> RegMemberRecord
		{
			get;
			set;
		}

		public virtual ICollection<BonusReceiveInfo> Himall_BonusReceive
		{
			get;
			set;
		}

		public virtual ICollection<ShopBonusReceiveInfo> Himall_ShopBonusReceive
		{
			get;
			set;
		}

		public virtual ICollection<ShopBonusGrantInfo> Himall_ShopBonusGrant
		{
			get;
			set;
		}

		public virtual ICollection<AgentProductsInfo> Himall_AgentProducts
		{
			get;
			set;
		}

		public virtual ICollection<PromoterInfo> Himall_Promoter
		{
			get;
			set;
		}

		public virtual ICollection<DistributionUserLinkInfo> Himall_DistributionUserLink
		{
			get;
			set;
		}

		public void InitUserIntegralInfo()
		{
			this._availableIntegrals = 0;
			this._historyIntegral = 0;
			if (this != null)
			{
				MemberIntegral memberIntegral = this.Himall_MemberIntegral.FirstOrDefault<MemberIntegral>();
				if (memberIntegral != null)
				{
					this._availableIntegrals = memberIntegral.AvailableIntegrals;
					this._historyIntegral = memberIntegral.HistoryIntegrals;
				}
			}
		}

		public UserMemberInfo()
		{
			this.FavoriteInfo = new HashSet<FavoriteInfo>();
			this.MemberOpenIdInfo = new HashSet<MemberOpenIdInfo>();
			this.ShippingAddressInfo = new HashSet<ShippingAddressInfo>();
			this.ShoppingCartInfo = new HashSet<ShoppingCartItemInfo>();
			this.Himall_FavoriteShops = new HashSet<FavoriteShopInfo>();
			this.Himall_BrowsingHistory = new HashSet<BrowsingHistoryInfo>();
			this.Himall_ProductComments = new HashSet<ProductCommentInfo>();
			this.Himall_MemberIntegralRecord = new HashSet<MemberIntegralRecord>();
			this.Himall_MemberIntegral = new HashSet<MemberIntegral>();
			this.InviteMemberRecord = new HashSet<InviteRecordInfo>();
			this.RegMemberRecord = new HashSet<InviteRecordInfo>();
			this.Himall_BonusReceive = new HashSet<BonusReceiveInfo>();
			this.Himall_ShopBonusReceive = new HashSet<ShopBonusReceiveInfo>();
			this.Himall_ShopBonusGrant = new HashSet<ShopBonusGrantInfo>();
			this.Himall_AgentProducts = new HashSet<AgentProductsInfo>();
			this.Himall_Promoter = new HashSet<PromoterInfo>();
			this.Himall_DistributionUserLink = new HashSet<DistributionUserLinkInfo>();
		}
	}
}
