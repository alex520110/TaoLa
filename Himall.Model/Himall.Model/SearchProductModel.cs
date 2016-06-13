using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class SearchProductModel
	{
		public List<BrandInfo> Brands
		{
			get;
			set;
		}

		public List<TypeAttributesModel> ProductAttrs
		{
			get;
			set;
		}
	}
}
