using Quartz;
using QuartzNetSample.JobScheduler.Core.Job.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuartzNetSample.JobScheduler.Core.Job
{
    public class TestJobService: JobServiceBase<TestJob>
    {
        protected override string GroupName
        {
            get
            {
                return "门店同步助手任务";
            }
        }

        protected override string JobName
        {
            get
            {
                return "获取未同步的线上订单";
            }
        }

        protected override ITrigger GetTrigger(int TimeSpan)
        {
            var trigger = TriggerBuilder.Create()
              .WithIdentity(JobName, GroupName)
              .WithSimpleSchedule(x => x
                  .WithIntervalInSeconds(TimeSpan)
                  .RepeatForever())
              .Build();

            return trigger;
        }
    }
}
