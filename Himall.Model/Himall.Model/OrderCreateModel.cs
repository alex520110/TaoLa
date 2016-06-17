using TaoLa.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class OrderCreateModel
	{
		public PlatformType PlatformType
		{
			get;
			set;
		}

		[JsonIgnore]
		public UserMemberInfo CurrentUser
		{
			get;
			set;
		}

		public long ReceiveAddressId
		{
			get;
			set;
		}

		public IEnumerable<string[]> CouponIdsStr
		{
			get;
			set;
		}

		public IEnumerable<long> CollPids
		{
			get;
			set;
		}

		public int Integral
		{
			get;
			set;
		}

		public InvoiceType Invoice
		{
			get;
			set;
		}

		public string InvoiceTitle
		{
			get;
			set;
		}

		public string InvoiceContext
		{
			get;
			set;
		}

		public IEnumerable<long> CartItemIds
		{
			get;
			set;
		}

		public IEnumerable<string> SkuIds
		{
			get;
			set;
		}

		public IEnumerable<int> Counts
		{
			get;
			set;
		}

		public bool IsCashOnDelivery
		{
			get;
			set;
		}

		public bool IslimitBuy
		{
			get;
			set;
		}

		public List<ProductInfo> ProductList
		{
			get;
			set;
		}

		public List<SKUInfo> SKUList
		{
			get;
			set;
		}

		public OrderCreateModel()
		{
			this.PlatformType = PlatformType.PC;
			this.ProductList = new List<ProductInfo>();
			this.SKUList = new List<SKUInfo>();
		}
	}
}
