using System;

namespace Himall.Model
{
	public class ImageAdInfo : BaseModel
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

		private string imageUrl
		{
			get;
			set;
		}

		public string Url
		{
			get;
			set;
		}

		public bool IsTransverseAD
		{
			get;
			set;
		}

		public string ImageUrl
		{
			get
			{
				return this.ImageServerUrl + this.imageUrl;
			}
			set
			{
				if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(this.ImageServerUrl))
				{
					this.imageUrl = value.Replace(this.ImageServerUrl, "");
				}
				else
				{
					this.imageUrl = value;
				}
			}
		}
	}
}
