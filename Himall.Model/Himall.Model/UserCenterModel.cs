using System;
using System.Collections.Generic;
using System.Linq;

namespace Himall.Model
{
	public class UserCenterModel
	{
		public long WaitPayOrders
		{
			get;
			set;
		}

		public long WaitReceivingOrders
		{
			get;
			set;
		}

		public long WaitEvaluationOrders
		{
			get;
			set;
		}

		public decimal Expenditure
		{
			get;
			set;
		}

		public List<FollowProduct> FollwProducts
		{
			get;
			set;
		}

		public int FollowProductCount
		{
			get;
			set;
		}

		public int Intergral
		{
			get;
			set;
		}

		public string GradeName
		{
			get;
			set;
		}

		public int RefundCount
		{
			get;
			set;
		}

		public int UserCoupon
		{
			get;
			set;
		}

		public List<FollowShop> FollowShops
		{
			get;
			set;
		}

		public int FollowShopsCount
		{
			get;
			set;
		}

		public List<FollowShopCart> FollowShopCarts
		{
			get;
			set;
		}

		public int FollowShopCartsCount
		{
			get;
			set;
		}

		public MemberAccountSafety memberAccountSafety
		{
			get;
			set;
		}

		public IQueryable<OrderInfo> Orders
		{
			get;
			set;
		}

		public UserCenterModel()
		{
			this.FollwProducts = new List<FollowProduct>();
			this.FollowShops = new List<FollowShop>();
			this.FollowShopCarts = new List<FollowShopCart>();
		}
	}
}
