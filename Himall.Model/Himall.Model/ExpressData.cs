using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class ExpressData
	{
		public bool Success
		{
			get;
			set;
		}

		public string Message
		{
			get;
			set;
		}

		public IEnumerable<ExpressDataItem> ExpressDataItems
		{
			get;
			set;
		}

		public ExpressData()
		{
			this.ExpressDataItems = new ExpressDataItem[0];
		}
	}
}
