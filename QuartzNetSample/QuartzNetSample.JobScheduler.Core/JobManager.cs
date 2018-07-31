using QuartzNetSample.JobScheduler.Core.Job;
using QuartzNetSample.JobScheduler.Core.Job.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuartzNetSample.JobScheduler.Core
{
    public class JobManager : ScheduleBase
    {
        public void Start()
        {
            //开启调度器
            ScheduleBase.Scheduler.Start();

            //把作业，触发器加入调度器
            ScheduleBase.AddSchedule(new TestJobService(), 20);
        }

        public void Stop()
        {
            ScheduleBase.Scheduler.Shutdown(true);
        }
    }
}
