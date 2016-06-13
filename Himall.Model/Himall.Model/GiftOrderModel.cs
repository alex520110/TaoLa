using Himall.Core;
using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class GiftOrderModel
	{
		public PlatformType PlatformType
		{
			get;
			set;
		}

		public UserMemberInfo CurrentUser
		{
			get;
			set;
		}

		public ShippingAddressInfo ReceiveAddress
		{
			get;
			set;
		}

		public string UserRemark
		{
			get;
			set;
		}

		public IEnumerable<GiftOrderItemModel> Gifts
		{
			get;
			set;
		}

		public GiftOrderModel()
		{
			this.PlatformType = PlatformType.PC;
		}
	}
}
