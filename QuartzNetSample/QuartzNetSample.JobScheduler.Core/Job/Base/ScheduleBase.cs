using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace QuartzNetSample.JobScheduler.Core.Job.Base
{
    public class ScheduleBase
    {
        private static IScheduler _scheduler;

        public static IScheduler Scheduler
        {
            get
            {
                if (_scheduler != null)
                {
                    return _scheduler;
                }

                var properties = new NameValueCollection();
                properties["quartz.scheduler.instanceName"] = "定时任务系统";

                // 设置线程池
                properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
                properties["quartz.threadPool.threadCount"] = "2";
                properties["quartz.threadPool.threadPriority"] = "Normal";

                // 远程输出配置
                properties["quartz.scheduler.exporter.type"] = "Quartz.Simpl.RemotingSchedulerExporter, Quartz";
                properties["quartz.scheduler.exporter.port"] = "8008";
                properties["quartz.scheduler.exporter.bindName"] = "QuartzScheduler";
                properties["quartz.scheduler.exporter.channelType"] = "tcp";

                var schedulerFactory = new StdSchedulerFactory(properties);
                _scheduler = schedulerFactory.GetScheduler();

                return _scheduler;
            }
        }

        public static void AddSchedule<T>(JobServiceBase<T> service, int TimeSpan) where T : IJob
        {
            service.AddJobToSchedule(Scheduler, TimeSpan);
        }
    }
}
