using QuartzNetSample.JobScheduler.Core;
using System;
using Topshelf;

namespace QuartzNetSample.JobScheduler.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<JobManager>(s =>
                {
                    s.ConstructUsing(name => new JobManager());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("服务描述");
                x.SetDisplayName("服务显示名称");
                x.SetServiceName("服务名称");
            });
        }
    }
}
