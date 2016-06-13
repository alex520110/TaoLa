using System;

namespace Himall.Model
{
	public class ArticleInfo : BaseModel
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

		public long CategoryId
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public string IconUrl
		{
			get;
			set;
		}

		public string Content
		{
			get;
			set;
		}

		public DateTime AddDate
		{
			get;
			set;
		}

		public long DisplaySequence
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

		public bool IsRelease
		{
			get;
			set;
		}

		public virtual ArticleCategoryInfo ArticleCategoryInfo
		{
			get;
			set;
		}
	}
}
