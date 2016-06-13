using System;

namespace Himall.Model
{
	public class ChartSeries<T> where T : struct
	{
		public string Name
		{
			get;
			set;
		}

		public T[] Data
		{
			get;
			set;
		}
	}
}
