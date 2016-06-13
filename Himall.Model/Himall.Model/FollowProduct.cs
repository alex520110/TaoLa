using System;

namespace Himall.Model
{
	public class FollowProduct
	{
		private string _imagePath;

		public decimal Price
		{
			get;
			set;
		}

		public string ImagePath
		{
			get
			{
				return this._imagePath;
			}
			set
			{
				this._imagePath = value;
			}
		}

		public long ProductId
		{
			get;
			set;
		}

		public string ProductName
		{
			get;
			set;
		}
	}
}
