using System;

namespace Himall.Model
{
	public class CollocationProducts
	{
		public long ProductId
		{
			get;
			set;
		}

		public long ColloPid
		{
			get;
			set;
		}

		public string ProductName
		{
			get;
			set;
		}

		public bool IsMain
		{
			get;
			set;
		}

		public long Stock
		{
			get;
			set;
		}

		public decimal MinSalePrice
		{
			get;
			set;
		}

		public decimal MaxSalePrice
		{
			get;
			set;
		}

		public decimal MinCollPrice
		{
			get;
			set;
		}

		public decimal MaxCollPrice
		{
			get;
			set;
		}

		public string Image
		{
			get;
			set;
		}

		public int DisplaySequence
		{
			get;
			set;
		}
	}
}
