using System;

namespace Himall.Model
{
	public enum UserPrivilege
	{
		[Privilege("首页", "个人中心", 1001, "UserCenter/home", "UserOrder", "")]
		Home = 1001,
		[Privilege("首页", "我的订单", 1002, "UserOrder", "UserOrder", "")]
		OrderManage,
		[Privilege("首页", "咨询管理", 1003, "userConsultation", "userConsultation", "")]
		UserConsultation,
		[Privilege("首页", "评价管理", 1004, "userComment", "userComment", "")]
		UserComment,
		[Privilege("我的关注", "商品关注", 2001, "productConcern/index", "ProductConcern", "")]
		ProductConcern = 2001,
		[Privilege("我的关注", "店铺关注", 2002, "shopConcern/Index", "ShopConcern", "")]
		ShopConcern,
		[Privilege("售后服务", "退换货管理", 3001, "OrderRefund/List?showtype=2", "OrderRefund", "")]
		OrderRefund = 3001,
		[Privilege("售后服务", "投诉维权", 3002, "OrderComplaint", "OrderComplaint", "")]
		OrderComplaint,
		[Privilege("帐户管理", "收货地址管理", 4001, "UserAddress", "UserAddress", "")]
		UserAddress = 4001,
		[Privilege("帐户管理", "个人信息", 4002, "UserInfo/Index", "", "")]
		UserInfo,
		[Privilege("帐户管理", "修改密码", 4003, "UserInfo/ChangePassWord", "UserInfo", "ChangePassWord")]
		ChangePassWord,
		[Privilege("资产中心", "我的优惠劵", 5001, "userCoupon/index", "userCoupon", "")]
		UserCoupon = 5001,
		[Privilege("资产中心", "我的积分", 5002, "userIntegral/Index", "userIntegral", "")]
		UserIntegral,
		[Privilege("资产中心", "我的账户", 5003, "UserCapital/Index", "UserCapital", "")]
		UserCapitals
	}
}
