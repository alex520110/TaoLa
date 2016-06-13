using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class ProductSkuModel
	{
		public long productId
		{
			get;
			set;
		}

		public string ProductName
		{
			get;
			set;
		}

		public string ImgUrl
		{
			get;
			set;
		}

		public List<SKUModel> SKUs
		{
			get;
			set;
		}
	}
}
