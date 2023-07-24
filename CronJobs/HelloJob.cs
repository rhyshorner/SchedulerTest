using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerTest.CronJobs
{
    public class HelloJob : IJob
    {
        Task IJob.Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hello World!");
            return Task.CompletedTask;
        }
    }
}
