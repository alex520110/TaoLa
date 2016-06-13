using Himall.Model;
using System;

namespace TaoLa.IServices.QueryModel
{
	public class GiftsOrderQuery : QueryBase
	{
		public string skey
		{
			get;
			set;
		}

		public long? OrderId
		{
			get;
			set;
		}

		public GiftOrderInfo.GiftOrderStatus? status
		{
			get;
			set;
		}

		public long? UserId
		{
			get;
			set;
		}
	}
}
