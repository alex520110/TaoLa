using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class BrandInfo : BaseModel
	{
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

		public string Name
		{
			get;
			set;
		}

		public long DisplaySequence
		{
			get;
			set;
		}

		private string logo
		{
			get;
			set;
		}

		public string RewriteName
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public string Meta_Title
		{
			get;
			set;
		}

		public string Meta_Description
		{
			get;
			set;
		}

		public string Meta_Keywords
		{
			get;
			set;
		}

		public bool IsRecommend
		{
			get;
			set;
		}

		public virtual ICollection<TypeBrandInfo> TypeBrandInfo
		{
			get;
			set;
		}

		public virtual ICollection<FloorBrandInfo> FloorBrandInfo
		{
			get;
			set;
		}

		public virtual ICollection<ShopBrandsInfo> Himall_ShopBrands
		{
			get;
			set;
		}

		public virtual ICollection<ShopBrandApplysInfo> Himall_ShopBrandApplys
		{
			get;
			set;
		}

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

		public BrandInfo()
		{
			this.TypeBrandInfo = new HashSet<TypeBrandInfo>();
			this.FloorBrandInfo = new HashSet<FloorBrandInfo>();
			this.Himall_ShopBrands = new HashSet<ShopBrandsInfo>();
			this.Himall_ShopBrandApplys = new HashSet<ShopBrandApplysInfo>();
		}
	}
}
