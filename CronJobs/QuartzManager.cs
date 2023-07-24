using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerTest.CronJobs
{
    public static class QuartzManager
    {

        public static void TriggerSingleJob<T>(Dictionary<string, object> args = null) where T : IJob
        {
            // create a map of arguments to pass to the job
            JobDataMap map = new JobDataMap();
            foreach (var arg in args)
                map.Put(arg.Key, arg.Value);

            // create a unique id to identify the job and trigger
            var id = Guid.NewGuid();

            // create the job
            IJobDetail jobDetail = JobBuilder.Create<T>()
                .WithIdentity($"onetimejob_{id}", "default")
                .UsingJobData(map)
                .Build();
            ISimpleTrigger simpleTrg = (ISimpleTrigger)TriggerBuilder.Create()
                .WithIdentity($"onetimetrigger_{id}", "default")
                .StartNow()
                .Build();

            // schedule the job to run
            if(Program.scheduler != null)
                Program.scheduler.ScheduleJob(jobDetail, simpleTrg);
        }
    }
}
