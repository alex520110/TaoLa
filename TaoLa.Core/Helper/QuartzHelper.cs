using Quartz;
using Quartz.Collection;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace TaoLa.Core
{
	public class QuartzHelper
	{
		private const string QuartzHelperScheulerName = "QuartzHelperScheulerName";

		private static object oLock;

		private static Dictionary<string, QuartzKey> quartzCache;

		private static IScheduler sched;

		private static ISchedulerFactory sf;

		static QuartzHelper()
		{
			QuartzHelper.oLock = new object();
			QuartzHelper.quartzCache = new Dictionary<string, QuartzKey>();
			QuartzHelper.sched = null;
			QuartzHelper.sf = null;
			QuartzHelper.sf = new StdSchedulerFactory(new NameValueCollection
			{
				{
					"quartz.scheduler.instanceName",
					"QuartzHelperScheulerName"
				}
			});
			QuartzHelper.sched = QuartzHelper.sf.GetScheduler();
		}

		public static void Close()
		{
			QuartzHelper.GetScheduler().Shutdown(true);
		}

		public static void Close(object jobKey)
		{
			if (jobKey is JobKey)
			{
				QuartzHelper.GetScheduler().DeleteJob(jobKey as JobKey);
			}
		}

		public static QuartzKey ExecuteAtDate(System.Action<Dictionary<string, object>> action, System.DateTime date, Dictionary<string, object> dataMap = null, string jobName = null)
		{
			return QuartzHelper.Start(action, delegate(TriggerBuilder p)
			{
				p.WithCronSchedule(QuartzHelper.BuilderCronExpression(date));
			}, dataMap, jobName);
		}

		public static QuartzKey ExecuteAtTime(System.Action<Dictionary<string, object>> action, string cronExpression, Dictionary<string, object> dataMap = null, string jobName = null)
		{
			return QuartzHelper.Start(action, delegate(TriggerBuilder p)
			{
				p.WithCronSchedule(cronExpression);
			}, dataMap, jobName);
		}

		public static void ExecuteInterval(System.Action<Dictionary<string, object>> action, System.TimeSpan interval, Dictionary<string, object> dataMap = null)
		{
			System.Action<TriggerBuilder> action2 = null;
			lock (QuartzHelper.oLock)
			{
				if (action2 == null)
				{
					action2 = delegate(TriggerBuilder p)
					{
						p.WithSimpleSchedule(delegate(SimpleScheduleBuilder p1)
						{
							p1.WithInterval(interval);
						});
					};
				}
				QuartzHelper.Start(action, action2, dataMap, null);
			}
		}

		public static IScheduler GetScheduler()
		{
			ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
			return schedulerFactory.GetScheduler("QuartzHelperScheulerName");
		}

		public static bool IsStart()
		{
			return QuartzHelper.GetScheduler() != null && QuartzHelper.GetScheduler().IsStarted;
		}

		public static string BuilderCronExpression(System.DateTime date)
		{
			string empty = string.Empty;
			return string.Format("{0} {1} {2} {3} {4} ?", new object[]
			{
				date.Second,
				date.Minute,
				date.Hour,
				date.Day,
				date.Month
			});
		}

		private static QuartzKey Start(System.Action<Dictionary<string, object>> action, System.Action<TriggerBuilder> action2, Dictionary<string, object> dataMap, string jobName)
		{
			QuartzKey quartzKey = new QuartzKey();
			if (jobName != null)
			{
				if (QuartzHelper.quartzCache.ContainsKey(jobName))
				{
					quartzKey = QuartzHelper.quartzCache[jobName];
				}
				else
				{
					QuartzHelper.quartzCache.Add(jobName, quartzKey);
				}
			}
			jobName = (jobName ?? System.Guid.NewGuid().ToString("D"));
			string group = "group_" + jobName;
			string name = "trigger_" + jobName;
			IJobDetail jobDetail = JobBuilder.Create(typeof(QuartzJob)).WithIdentity(jobName, group).Build();
			TriggerBuilder triggerBuilder = TriggerBuilder.Create().WithIdentity(name, group);
			action2(triggerBuilder);
			ITrigger trigger = triggerBuilder.Build();
			if (QuartzHelper.quartzCache.ContainsKey(jobName))
			{
				QuartzHelper.quartzCache[jobName].JobKey = jobDetail.Key;
				QuartzHelper.quartzCache[jobName].TriggerKey = trigger.Key;
				QuartzHelper.quartzCache[jobName].Logs.Add(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 调度任务已经启动。");
			}
			jobDetail.JobDataMap.Add("dataMap", dataMap);
			jobDetail.JobDataMap.Add("action", action);
			jobDetail.JobDataMap.Add("jobName", jobName);
			jobDetail.JobDataMap.Add("quartzCache", QuartzHelper.quartzCache);
			QuartzHelper.sched.ScheduleJob(jobDetail, new Quartz.Collection.HashSet<ITrigger>
			{
				trigger
			}, true);
			QuartzHelper.sched.Start();
			return quartzKey;
		}
	}
}
