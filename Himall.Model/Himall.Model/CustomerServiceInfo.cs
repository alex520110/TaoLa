using System;
using System.ComponentModel;

namespace Himall.Model
{
	public class CustomerServiceInfo : BaseModel
	{
		public enum ServiceTool
		{
			[Description("QQ")]
			QQ = 1,
			[Description("旺旺")]
			Wangwang
		}

		public enum ServiceType
		{
			[Description("售前")]
			PreSale = 1,
			[Description("售后")]
			AfterSale
		}

		private long _id;

		public new long Id
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
				base.Id = value;
			}
		}

		public long ShopId
		{
			get;
			set;
		}

		public CustomerServiceInfo.ServiceTool Tool
		{
			get;
			set;
		}

		public CustomerServiceInfo.ServiceType Type
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string AccountCode
		{
			get;
			set;
		}
	}
}
