using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class LineChartDataModel<T> where T : struct
	{
		public string[] XAxisData
		{
			get;
			set;
		}

		public IList<ChartSeries<T>> SeriesData
		{
			get;
			set;
		}

		public string[] ExpandProp
		{
			get;
			set;
		}
	}
}
