using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class MediaNewsItem
	{
		public IEnumerable<WXMaterialInfo> items
		{
			get;
			set;
		}

		public string media_id
		{
			get;
			set;
		}

		public string update_time
		{
			get;
			set;
		}
	}
}
