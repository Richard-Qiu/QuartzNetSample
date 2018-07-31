using Quartz;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuartzNetSample.JobScheduler.Core.Job.Base
{
    public abstract class JobServiceBase<T> where T : IJob
    {
        protected abstract string JobName { get; }
        protected abstract string GroupName { get; }

        private IJobDetail GetJobDetail()
        {
            var job = JobBuilder.Create<T>()
                .WithIdentity(JobName, GroupName)
                .Build();
            return job;
        }

        protected abstract ITrigger GetTrigger(int TimeSpan);

        public void AddJobToSchedule(IScheduler scheduler, int TimeSpan)
        {
            scheduler.ScheduleJob(GetJobDetail(), GetTrigger(TimeSpan));
        }
    }
}
