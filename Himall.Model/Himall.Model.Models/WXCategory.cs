using System;
using System.Collections.Generic;

namespace Himall.Model.Models
{
	public class WXCategory
	{
		public string Id
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public List<WXCategory> Child
		{
			get;
			set;
		}

		public WXCategory()
		{
			this.Child = new List<WXCategory>();
		}
	}
}
