using TaoLa.Core;
using System;

namespace Himall.Model
{
	public class UserProformanceModel : BaseModel
	{
		public new long Id
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public long UserId
		{
			get;
			set;
		}

		public string ProductName
		{
			get;
			set;
		}

		public decimal RealTotalPrice
		{
			get;
			set;
		}

		public OrderInfo.OrderOperateStatus OrderStatus
		{
			get;
			set;
		}

		public bool Expired
		{
			get;
			set;
		}

		public DateTime OrderTime
		{
			get;
			set;
		}

		public DateTime? FinshedTime
		{
			get;
			set;
		}

		public string ExpriedStatus
		{
			get
			{
				return this.Expired ? "是" : "否";
			}
		}

		public string OrderStatusDesc
		{
			get
			{
				return this.OrderStatus.ToDescription();
			}
		}

		public string OrderTimeString
		{
			get
			{
				return this.OrderTime.ToString("yyyy-MM-dd HH:mm:ss");
			}
		}

		public string OrderIdString
		{
			get
			{
				return this.Id.ToString();
			}
		}

		public decimal Brokerage
		{
			get;
			set;
		}
	}
}
