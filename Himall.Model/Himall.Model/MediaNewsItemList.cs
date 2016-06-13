using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class MediaNewsItemList
	{
		public IEnumerable<MediaNewsItem> content
		{
			get;
			set;
		}

		public int total_count
		{
			get;
			set;
		}

		public int count
		{
			get;
			set;
		}

		public string errCode
		{
			get;
			set;
		}

		public string errMsg
		{
			get;
			set;
		}
	}
}
