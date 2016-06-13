using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class ArticleCategoryInfo : BaseModel
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

		public long ParentCategoryId
		{
			get;
			set;
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

		public bool IsDefault
		{
			get;
			set;
		}

		public virtual ICollection<ArticleInfo> ArticleInfo
		{
			get;
			set;
		}

		public ArticleCategoryInfo()
		{
			this.ArticleInfo = new HashSet<ArticleInfo>();
		}
	}
}
