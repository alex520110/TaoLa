using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class ProvinceMode
	{
		public long Id
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public IEnumerable<CityMode> City
		{
			get;
			set;
		}
	}
}
