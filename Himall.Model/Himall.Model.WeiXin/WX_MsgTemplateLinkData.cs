using TaoLa.Core;
using System;
using System.Collections.Generic;

namespace Himall.Model.WeiXin
{
	public class WX_MsgTemplateLinkData
	{
		public MessageTypeEnum MsgType
		{
			get;
			set;
		}

		public string MsgTemplateShortId
		{
			get;
			set;
		}

		public string ReturnUrl
		{
			get;
			set;
		}

		private static List<WX_MsgTemplateLinkData> DataList
		{
			get;
			set;
		}

		static WX_MsgTemplateLinkData()
		{
			WX_MsgTemplateLinkData.DataList = new List<WX_MsgTemplateLinkData>();
			WX_MsgTemplateLinkData wX_MsgTemplateLinkData = new WX_MsgTemplateLinkData();
			wX_MsgTemplateLinkData.MsgType = MessageTypeEnum.OrderCreated;
			wX_MsgTemplateLinkData.MsgTemplateShortId = "OPENTM207102467";
			wX_MsgTemplateLinkData.ReturnUrl = "/m-weixin/Order/Detail/{id}";
			WX_MsgTemplateLinkData.DataList.Add(wX_MsgTemplateLinkData);
			wX_MsgTemplateLinkData = new WX_MsgTemplateLinkData();
			wX_MsgTemplateLinkData.MsgType = MessageTypeEnum.OrderPay;
			wX_MsgTemplateLinkData.MsgTemplateShortId = "OPENTM207185188";
			wX_MsgTemplateLinkData.ReturnUrl = "/m-weixin/Order/Detail/{id}";
			WX_MsgTemplateLinkData.DataList.Add(wX_MsgTemplateLinkData);
			wX_MsgTemplateLinkData = new WX_MsgTemplateLinkData();
			wX_MsgTemplateLinkData.MsgType = MessageTypeEnum.OrderShipping;
			wX_MsgTemplateLinkData.MsgTemplateShortId = "OPENTM202243318";
			wX_MsgTemplateLinkData.ReturnUrl = "/m-weixin/Order/Detail/{id}";
			WX_MsgTemplateLinkData.DataList.Add(wX_MsgTemplateLinkData);
			wX_MsgTemplateLinkData = new WX_MsgTemplateLinkData();
			wX_MsgTemplateLinkData.MsgType = MessageTypeEnum.OrderRefund;
			wX_MsgTemplateLinkData.MsgTemplateShortId = "TM00430";
			wX_MsgTemplateLinkData.ReturnUrl = "/m-weixin/OrderRefund/RefundDetail/{id}";
			WX_MsgTemplateLinkData.DataList.Add(wX_MsgTemplateLinkData);
			wX_MsgTemplateLinkData = new WX_MsgTemplateLinkData();
			wX_MsgTemplateLinkData.MsgType = MessageTypeEnum.ShopHaveNewOrder;
			wX_MsgTemplateLinkData.MsgTemplateShortId = "OPENTM200750297";
			WX_MsgTemplateLinkData.DataList.Add(wX_MsgTemplateLinkData);
			wX_MsgTemplateLinkData = new WX_MsgTemplateLinkData();
			wX_MsgTemplateLinkData.MsgType = MessageTypeEnum.ReceiveBonus;
			wX_MsgTemplateLinkData.MsgTemplateShortId = "OPENTM200681790";
			wX_MsgTemplateLinkData.ReturnUrl = "/m-weixin/Member/Center";
			WX_MsgTemplateLinkData.DataList.Add(wX_MsgTemplateLinkData);
			wX_MsgTemplateLinkData = new WX_MsgTemplateLinkData();
			wX_MsgTemplateLinkData.MsgType = MessageTypeEnum.LimitTimeBuy;
			wX_MsgTemplateLinkData.MsgTemplateShortId = "OPENTM206903698";
			wX_MsgTemplateLinkData.ReturnUrl = "/m-wap/limittimebuy/detail/{id}";
			WX_MsgTemplateLinkData.DataList.Add(wX_MsgTemplateLinkData);
			wX_MsgTemplateLinkData = new WX_MsgTemplateLinkData();
			wX_MsgTemplateLinkData.MsgType = MessageTypeEnum.SubscribeLimitTimeBuy;
			wX_MsgTemplateLinkData.MsgTemplateShortId = "OPENTM202118814";
			WX_MsgTemplateLinkData.DataList.Add(wX_MsgTemplateLinkData);
		}

		public static List<WX_MsgTemplateLinkData> GetList()
		{
			return WX_MsgTemplateLinkData.DataList;
		}
	}
}
