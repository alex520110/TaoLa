using System;

namespace Himall.Model
{
	public enum AdminPrivilege
	{
		[Privilege("商品", "商品管理", 2001, "product/management", "product", "")]
		ProductManage = 2001,
		[Privilege("商品", "分类管理", 2002, "category/management", "category", "")]
		CategoryManage,
		[Privilege("商品", "品牌管理", 2003, "brand/Verify", "brand", "")]
		BrandManage,
		[Privilege("商品", "类型管理", 2004, "ProductType/management", "ProductType", "")]
		ProductTypeManage,
		[Privilege("商品", "咨询管理", 2006, "ProductConsultation/management", "productconsultation", "")]
		ConsultationManage = 2006,
		[Privilege("商品", "评论管理", 2007, "ProductComment/management", "ProductComment", "")]
		CommentManage,
		[Privilege("交易", "订单管理", 3001, "Order/management", "order", "")]
		OrderManage = 3001,
		[Privilege("交易", "退款处理", 3002, "OrderRefund/management?showtype=2", "orderrefund", "")]
		ReturnRefundManage,
		[Privilege("交易", "退货处理", 3009, "OrderRefund/management?showtype=3", "orderrefund", "")]
		ReturnGoodsManage = 3009,
		[Privilege("交易", "交易评价", 3003, "OrderComment/management", "ordercomment", "")]
		OrderComment = 3003,
		[Privilege("交易", "交易投诉", 3004, "OrderComplaint/management", "ordercomplaint", "")]
		OrderComplaint,
		[Privilege("交易", "支付方式", 3005, "Payment/management", "payment", "")]
		PaymentManage,
		[Privilege("交易", "快递单模板", 3006, "ExpressTemplate/management", "ExpressTemplate", "")]
		ExpressTemplate,
		[Privilege("交易", "交易设置", 3007, "AdvancePayment/edit", "AdvancePayment", "")]
		PaymentManageSet,
		[Privilege("交易", "发票管理", 3008, "Order/InvoiceContext", "InvoiceContext", "")]
		InvoiceContextManage,
		[Privilege("会员", "会员管理", 4001, "member/management", "member", "")]
		MemberManage = 4001,
		[Privilege("会员", "标签管理", 4009, "Label/management", "Label", "")]
		LabelManage = 4009,
		[Privilege("会员", "会员营销", 4010, "MessageGroup/WXGroupMessage", "MessageGroup", "")]
		MarketingManage,
		[Privilege("会员", "会员积分", 4003, "MemberIntegral/search", "MemberIntegral", "")]
		MemberIntegral = 4003,
		[Privilege("会员", "积分规则", 4004, "IntegralRule/management", "IntegralRule", "")]
		IntegralRule,
		[Privilege("会员", "会员等级", 4005, "MemberGrade/management", "MemberGrade", "")]
		MemberGrade,
		[Privilege("会员", "信任登录", 4006, "OAuth/Management", "OAuth", "")]
		OAuth,
		[Privilege("会员", "会员推广", 4007, "MemberInvite/Setting", "MemberInvite", "")]
		MemberInvite,
		[Privilege("会员", "预付款管理", 4008, "Capital/Index", "Capital", "")]
		Capital,
		[Privilege("店铺", "店铺管理", 5001, "shop/management?type=Auditing", "Shop", "")]
		ShopManage = 5001,
		[Privilege("店铺", "店铺套餐", 5002, "ShopGrade/management", "ShopGrade", "")]
		ShopPackage,
		[Privilege("店铺", "结算管理", 5003, "Account/management", "Account", "")]
		SettlementManage,
		[Privilege("店铺", "保证金管理", 5004, "CashDeposit/Management", "CashDeposit", "")]
		CashDepositManagement,
		[Privilege("统计", "会员统计", 6002, "Statistics/Member", "statistics", "member")]
		MemberStatistics = 6002,
		[Privilege("统计", "店铺统计", 6003, "Statistics/NewShop", "statistics", "newshop")]
		ShopStatistics,
		[Privilege("统计", "销量分析", 6004, "Statistics/ProductSaleRanking", "statistics", "productsaleranking")]
		SalesAnalysis,
		[Privilege("网站", "页面设置", 7001, "PageSettings", "PageSettings", "")]
		PageSetting = 7001,
		[Privilege("网站", "文章管理", 7002, "Article/management", "article", "")]
		ArticleManage,
		[Privilege("网站", "文章分类", 7003, "ArticleCategory/management", "articlecategory", "")]
		ArticleCategoryManage,
		[Privilege("分销", "分销市场管理", 7101, "DistributionMarket/management", "DistributionMarket", "")]
		DistributionMarket = 7101,
		[Privilege("分销", "销售员管理", 7102, "Promoter/management", "Promoter", "")]
		Promoter,
		[Privilege("分销", "分销业绩管理", 7103, "Proformance/management", "Proformance", "")]
		Proformance,
		[Privilege("系统", "站点设置", 8001, "SiteSetting/Index", "SiteSetting", ""), Privilege("系统", "站点设置", 8001, "SiteSetting/Index", "Navigation", "")]
		SiteSetting = 8001,
		[Privilege("系统", "管理员", 8002, "Manager/management", "Manager", "")]
		AdminManage,
		[Privilege("系统", "权限组", 8003, "Privilege/management", "privilege", "")]
		PrivilegesManage,
		[Privilege("系统", "操作日志", 8004, "OperationLog/management", "OperationLog", "")]
		OperationLog,
		[Privilege("系统", "消息设置", 8005, "Message/management", "Message", "")]
		MessageSetting,
		[Privilege("系统", "协议管理", 8006, "Agreement/Management", "Agreement", "")]
		Agreement,
		[Privilege("营销", "限时购", 9001, "LimitTimeBuy/management", "LimitTimeBuy", "")]
		LimitTimeBuy = 9001,
		[Privilege("营销", "优惠券", 9002, "Coupon/management", "Coupon", "")]
		Coupon,
		[Privilege("营销", "组合购", 9003, "Collocation/management", "Collocation", "")]
		Collocation,
		[Privilege("营销", "微信现金红包", 9004, "Bonus/management", "Bonus", "")]
		Bonus,
		[Privilege("营销", "代金红包", 9005, "ShopBonus/management", "ShopBonus", "")]
		ShopBonus,
		[Privilege("营销", "礼品管理", 9006, "Gift/management", "gift", "")]
		GiftManage,
		[Privilege("营销", "礼品兑换列表", 9007, "Gift/Order", "giftorder", "")]
		GiftOrder,
		[Privilege("营销", "签到", 9008, "SignIn/Setting", "signinsetting", "")]
		SignIn,
		[Privilege("营销", "移动端专题", 9009, "MobileTopic/management", "MobileTopic", "")]
		MobileTopic,
		[Privilege("营销", "PC端专题", 9010, "Topic/management", "Topic", "")]
		PCTopic,
		[Privilege("微商城", "商城首页设置", 10001, "Weixin/HomePageSetting", "MobileHomeProducts", ""), Privilege("微商城", "商城首页设置", 10001, "Weixin/HomePageSetting", "WeiXin", "")]
		Vshop = 10001,
		[Privilege("微商城", "微店管理", 10002, "Vshop/VShopManagement", "Vshop", "")]
		VshopManage,
		[Privilege("微商城", "菜单设置", 10003, "Weixin/MenuManage", "WeiXin", "")]
		VshopMenu,
		[Privilege("微商城", "公众号设置", 10004, "Weixin/BasicSettings", "WeiXin", "")]
		VshopBasicSetting,
		[Privilege("微商城", "素材管理", 10005, "Weixin/WXMsgTemplateManage", "WeiXin", "")]
		WXMsgTemplateManage,
		[Privilege("APP", "APP首页配置", 12001, "APPShop/HomePageSetting", "APPShop", "")]
		APPShop = 12001
	}
}
