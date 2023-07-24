using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerTest.CronJobs
{
    public class GoodbyeJob : IJob
    {
        Task IJob.Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Goodbye World!");
            return Task.CompletedTask;
        }
    }
}
