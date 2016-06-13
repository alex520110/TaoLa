using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class CollocationDataModel
	{
		public long Id
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public DateTime StartTime
		{
			get;
			set;
		}

		public DateTime EndTime
		{
			get;
			set;
		}

		public string ShortDesc
		{
			get;
			set;
		}

		public long ShopId
		{
			get;
			set;
		}

		public DateTime CreateTime
		{
			get;
			set;
		}

		public List<CollocationPoruductModel> CollocationPoruducts
		{
			get;
			set;
		}
	}
}
