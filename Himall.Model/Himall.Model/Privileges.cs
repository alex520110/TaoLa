using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class Privileges
	{
		public List<GroupActionItem> Privilege
		{
			get;
			set;
		}

		public Privileges()
		{
			this.Privilege = new List<GroupActionItem>();
		}
	}
}
