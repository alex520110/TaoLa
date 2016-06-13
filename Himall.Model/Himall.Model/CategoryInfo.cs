using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class CategoryInfo : BaseModel
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

		public string Icon
		{
			get;
			set;
		}

		public long DisplaySequence
		{
			get;
			set;
		}

		public long ParentCategoryId
		{
			get;
			set;
		}

		public int Depth
		{
			get;
			set;
		}

		public string Path
		{
			get;
			set;
		}

		public string RewriteName
		{
			get;
			set;
		}

		public bool HasChildren
		{
			get;
			set;
		}

		public long TypeId
		{
			get;
			set;
		}

		public decimal CommisRate
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

		public virtual ProductTypeInfo ProductTypeInfo
		{
			get;
			set;
		}

		public virtual ICollection<FloorCategoryInfo> FloorCategoryInfo
		{
			get;
			set;
		}

		public virtual ICollection<HomeCategoryInfo> HomeCategoryInfo
		{
			get;
			set;
		}

		public virtual ICollection<BusinessCategoryInfo> BusinessCategoryInfo
		{
			get;
			set;
		}

		public virtual ICollection<ProductInfo> Himall_Products
		{
			get;
			set;
		}

		public virtual CategoryCashDepositInfo Himall_CategoryCashDeposit
		{
			get;
			set;
		}

		public CategoryInfo()
		{
			this.FloorCategoryInfo = new HashSet<FloorCategoryInfo>();
			this.HomeCategoryInfo = new HashSet<HomeCategoryInfo>();
			this.BusinessCategoryInfo = new HashSet<BusinessCategoryInfo>();
			this.Himall_Products = new HashSet<ProductInfo>();
		}
	}
}
