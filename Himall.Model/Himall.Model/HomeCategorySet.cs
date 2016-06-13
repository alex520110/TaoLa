using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class HomeCategorySet
	{
		public class HomeCategoryTopic
		{
			public string Url
			{
				get;
				set;
			}

			public string ImageUrl
			{
				get;
				set;
			}
		}

		public IEnumerable<HomeCategoryInfo> HomeCategories
		{
			get;
			set;
		}

		public IEnumerable<HomeCategorySet.HomeCategoryTopic> HomeCategoryTopics
		{
			get;
			set;
		}

		public int RowNumber
		{
			get;
			set;
		}
	}
}
