using System;

namespace Himall.Model
{
	public class ChargeDetailModel
	{
		public string Id
		{
			get;
			set;
		}

		public long MemId
		{
			get;
			set;
		}

		public string ChargeTime
		{
			get;
			set;
		}

		public decimal ChargeAmount
		{
			get;
			set;
		}

		public string ChargeWay
		{
			get;
			set;
		}

		public ChargeDetailInfo.ChargeDetailStatus ChargeStatus
		{
			get;
			set;
		}

		public string ChargeStatusDesc
		{
			get;
			set;
		}

		public string CreateTime
		{
			get;
			set;
		}
	}
}
