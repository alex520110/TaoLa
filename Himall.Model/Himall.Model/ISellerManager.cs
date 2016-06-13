using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public interface ISellerManager : IManager
	{
		long VShopId
		{
			get;
			set;
		}

		List<SellerPrivilege> SellerPrivileges
		{
			get;
			set;
		}
	}
}
