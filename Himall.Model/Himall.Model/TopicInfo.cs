using Himall.Core;
using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class TopicInfo : BaseModel
	{
		private long _id;

		public string TopImage
		{
			get
			{
				return this.ImageServerUrl + this.topImage;
			}
			set
			{
				if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(this.ImageServerUrl))
				{
					this.topImage = value.Replace(this.ImageServerUrl, "");
				}
				else
				{
					this.topImage = value;
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

		public string FrontCoverImage
		{
			get
			{
				return this.ImageServerUrl + this.frontCoverImage;
			}
			set
			{
				if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(this.ImageServerUrl))
				{
					this.frontCoverImage = value.Replace(this.ImageServerUrl, "");
				}
				else
				{
					this.frontCoverImage = value;
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

		private string topImage
		{
			get;
			set;
		}

		private string backgroundImage
		{
			get;
			set;
		}

		public string frontCoverImage
		{
			get;
			set;
		}

		public string Tags
		{
			get;
			set;
		}

		public PlatformType PlatForm
		{
			get;
			set;
		}

		public long ShopId
		{
			get;
			set;
		}

		public bool IsRecommend
		{
			get;
			set;
		}

		public string SelfDefineText
		{
			get;
			set;
		}

		public virtual ICollection<TopicModuleInfo> TopicModuleInfo
		{
			get;
			set;
		}

		public virtual ICollection<MobileHomeTopicsInfo> Himall_MobileHomeTopics
		{
			get;
			set;
		}

		public TopicInfo()
		{
			this.TopicModuleInfo = new HashSet<TopicModuleInfo>();
			this.Himall_MobileHomeTopics = new HashSet<MobileHomeTopicsInfo>();
		}
	}
}
