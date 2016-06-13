using System;
using System.Collections.Generic;

namespace Himall.Model.DTO
{
	public class AddShopHomeModuleModel
	{
		public long Id
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string Url
		{
			get;
			set;
		}

		public List<AddShopHomeModuleProductModel> Products
		{
			get;
			set;
		}

		public List<AddShopHomeModuleTopImgModel> TopImgs
		{
			get;
			set;
		}

		public long ShopId
		{
			get;
			set;
		}
	}
}
