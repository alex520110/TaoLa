using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class ProductDescriptionInfo : BaseModel
	{
		private long _id;

		[NotMapped]
		public string ShowMobileDescription
		{
			get
			{
				string text = "";
				if (this != null)
				{
					text = this.MobileDescription;
					if (string.IsNullOrWhiteSpace(text))
					{
						text = this.Description;
					}
				}
				return text;
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

		public long ProductId
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public long DescriptionPrefixId
		{
			get;
			set;
		}

		public long DescriptiondSuffixId
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

		public string AuditReason
		{
			get;
			set;
		}

		public string MobileDescription
		{
			get;
			set;
		}

		public virtual ProductInfo ProductInfo
		{
			get;
			set;
		}
	}
}
