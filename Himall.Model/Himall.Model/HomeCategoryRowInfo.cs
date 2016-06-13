using System;

namespace Himall.Model
{
	public class HomeCategoryRowInfo : BaseModel
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

		public int RowId
		{
			get;
			set;
		}

		private string image1
		{
			get;
			set;
		}

		public string Url1
		{
			get;
			set;
		}

		private string image2
		{
			get;
			set;
		}

		public string Url2
		{
			get;
			set;
		}

		public string Image1
		{
			get
			{
				return this.ImageServerUrl + this.image1;
			}
			set
			{
				if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(this.ImageServerUrl))
				{
					this.image1 = value.Replace(this.ImageServerUrl, "");
				}
				else
				{
					this.image1 = value;
				}
			}
		}

		public string Image2
		{
			get
			{
				return this.ImageServerUrl + this.image2;
			}
			set
			{
				if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(this.ImageServerUrl))
				{
					this.image2 = value.Replace(this.ImageServerUrl, "");
				}
				else
				{
					this.image2 = value;
				}
			}
		}
	}
}
