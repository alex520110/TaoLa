using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class HomeFloorInfo : BaseModel
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

		public string FloorName
		{
			get;
			set;
		}

		public long DisplaySequence
		{
			get;
			set;
		}

		public bool IsShow
		{
			get;
			set;
		}

		public string SubName
		{
			get;
			set;
		}

		public long StyleLevel
		{
			get;
			set;
		}

		public string DefaultTabName
		{
			get;
			set;
		}

		public virtual ICollection<FloorBrandInfo> FloorBrandInfo
		{
			get;
			set;
		}

		public virtual ICollection<FloorCategoryInfo> FloorCategoryInfo
		{
			get;
			set;
		}

		public virtual ICollection<FloorProductInfo> FloorProductInfo
		{
			get;
			set;
		}

		public virtual ICollection<FloorTopicInfo> FloorTopicInfo
		{
			get;
			set;
		}

		public virtual ICollection<FloorTablsInfo> Himall_FloorTabls
		{
			get;
			set;
		}

		public HomeFloorInfo()
		{
			this.FloorBrandInfo = new HashSet<FloorBrandInfo>();
			this.FloorCategoryInfo = new HashSet<FloorCategoryInfo>();
			this.FloorProductInfo = new HashSet<FloorProductInfo>();
			this.FloorTopicInfo = new HashSet<FloorTopicInfo>();
			this.Himall_FloorTabls = new HashSet<FloorTablsInfo>();
		}
	}
}
