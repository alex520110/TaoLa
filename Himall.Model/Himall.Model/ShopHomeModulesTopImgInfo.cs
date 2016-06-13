using System;

namespace Himall.Model
{
	public class ShopHomeModulesTopImgInfo : BaseModel
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

		public string ImgPath
		{
			get;
			set;
		}

		public string Url
		{
			get;
			set;
		}

		public long HomeModuleId
		{
			get;
			set;
		}

		public int DisplaySequence
		{
			get;
			set;
		}

		public virtual ShopHomeModuleInfo Himall_ShopHomeModules
		{
			get;
			set;
		}
	}
}
