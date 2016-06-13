using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class CityMode
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

		public IEnumerable<CountyMode> County
		{
			get;
			set;
		}
	}
}
