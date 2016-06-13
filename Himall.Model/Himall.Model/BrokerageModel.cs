using System;

namespace Himall.Model
{
	public class BrokerageModel
	{
		public long Id
		{
			get;
			set;
		}

		public string TypeName
		{
			get
			{
				return "分销佣金";
			}
		}

		public long OrderId
		{
			get;
			set;
		}

		public string ProductName
		{
			get;
			set;
		}

		public long ProductId
		{
			get;
			set;
		}

		public decimal RealTotal
		{
			get;
			set;
		}

		public decimal Brokerage
		{
			get;
			set;
		}

		public long UserId
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public DateTime SettlementTime
		{
			get;
			set;
		}

		public string SettlementTimeString
		{
			get
			{
				return this.SettlementTime.ToString("yyyy-MM-dd");
			}
		}
	}
}
