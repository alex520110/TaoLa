using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.Core
{
    public enum MessageTypeEnum
    {
        [Description("订单创建时")]
        OrderCreated = 1,
        [Description("订单付款时")]
        OrderPay,
        [Description("订单发货")]
        OrderShipping,
        [Description("订单退款")]
        OrderRefund,
        [Description("找回密码")]
        FindPassWord,
        [Description("店铺审核")]
        ShopAudited,
        [Description("开店成功")]
        ShopSuccess,
        [Description("店铺有新订单")]
        ShopHaveNewOrder,
        [Description("领取红包通知")]
        ReceiveBonus,
        [Description("限时购开始通知")]
        LimitTimeBuy,
        [Description("订阅限时购")]
        SubscribeLimitTimeBuy
    }
}
