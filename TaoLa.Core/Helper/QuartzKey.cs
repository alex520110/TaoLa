using Quartz;
using System;
using System.Collections.Generic;

namespace TaoLa.Core
{
	public class QuartzKey
	{
		public JobKey JobKey
		{
			get;
			set;
		}

		public List<string> Logs
		{
			get;
			set;
		}

		public TriggerKey TriggerKey
		{
			get;
			set;
		}

		public QuartzKey()
		{
			this.Logs = new List<string>();
		}
	}
}
