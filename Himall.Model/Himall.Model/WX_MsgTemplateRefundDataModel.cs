using System;

namespace Himall.Model
{
	public class WX_MsgTemplateRefundDataModel
	{
		public WX_MSGItemBaseModel first
		{
			get;
			set;
		}

		public WX_MSGItemBaseModel orderProductPrice
		{
			get;
			set;
		}

		public WX_MSGItemBaseModel orderProductName
		{
			get;
			set;
		}

		public WX_MSGItemBaseModel orderName
		{
			get;
			set;
		}

		public WX_MSGItemBaseModel remark
		{
			get;
			set;
		}

		public WX_MsgTemplateRefundDataModel()
		{
			this.first = new WX_MSGItemBaseModel();
			this.orderProductPrice = new WX_MSGItemBaseModel();
			this.orderProductName = new WX_MSGItemBaseModel();
			this.orderName = new WX_MSGItemBaseModel();
			this.remark = new WX_MSGItemBaseModel();
		}
	}
}
