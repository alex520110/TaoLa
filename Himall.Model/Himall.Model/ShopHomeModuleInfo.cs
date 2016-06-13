using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class ShopHomeModuleInfo : BaseModel
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

		public long ShopId
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public bool IsEnable
		{
			get;
			set;
		}

		public int DisplaySequence
		{
			get;
			set;
		}

		public string Url
		{
			get;
			set;
		}

		public virtual ICollection<ShopHomeModuleProductInfo> ShopHomeModuleProductInfo
		{
			get;
			set;
		}

		public virtual ICollection<ShopHomeModulesTopImgInfo> Himall_ShopHomeModulesTopImg
		{
			get;
			set;
		}

		public ShopHomeModuleInfo()
		{
			this.ShopHomeModuleProductInfo = new HashSet<ShopHomeModuleProductInfo>();
			this.Himall_ShopHomeModulesTopImg = new HashSet<ShopHomeModulesTopImgInfo>();
		}
	}
}
