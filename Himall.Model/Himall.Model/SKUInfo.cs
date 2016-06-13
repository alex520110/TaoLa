using System;

namespace Himall.Model
{
	public class SKUInfo : BaseModel
	{
		private string _id;

		public new string Id
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

		public string Color
		{
			get;
			set;
		}

		public string Size
		{
			get;
			set;
		}

		public string Version
		{
			get;
			set;
		}

		public string Sku
		{
			get;
			set;
		}

		public long Stock
		{
			get;
			set;
		}

		public decimal CostPrice
		{
			get;
			set;
		}

		public decimal SalePrice
		{
			get;
			set;
		}

		public long AutoId
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
