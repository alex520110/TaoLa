using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class CollocationPoruductModel
	{
		public long Id
		{
			get;
			set;
		}

		public long ProductId
		{
			get;
			set;
		}

		public string ImagePath
		{
			get;
			set;
		}

		public string ProductName
		{
			get;
			set;
		}

		public long ColloId
		{
			get;
			set;
		}

		public bool IsMain
		{
			get;
			set;
		}

		public int DisplaySequence
		{
			get;
			set;
		}

		public List<CollocationSkus> CollocationSkus
		{
			get;
			set;
		}
	}
}
