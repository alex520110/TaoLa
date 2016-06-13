using Himall.Model;
using System;

namespace TaoLa.IServices.QueryModel
{
	public class VshopQuery : QueryBase
	{
		public string Name
		{
			get;
			set;
		}

		public VShopExtendInfo.VShopExtendType? VshopType
		{
			get;
			set;
		}

		public VShopExtendInfo.VShopExtendState VshopState
		{
			get;
			set;
		}
	}
}
