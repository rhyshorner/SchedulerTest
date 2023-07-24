using System;
using Quartz;
using Quartz.Impl;
using SchedulerTest.CronJobs;
using static Quartz.Logging.OperationName;

class Program
{
    // creating a global scheduler for the application
    public static IScheduler? scheduler;


    static void Main(string[] args)
    {

        // Create a Scheduler for the application
        scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;
        scheduler.Start();





        // creating and running a repeating cron job
        IJobDetail helloJob = JobBuilder.Create<HelloJob>()
            .WithIdentity("job1", "group1")
            .Build();
        ITrigger HelloTrigger = TriggerBuilder.Create()
            .WithIdentity("trigger1", "group1")
            .StartNow()
            .WithCronSchedule("0/1 * * * * ?")
            .Build();
        scheduler.ScheduleJob(helloJob, HelloTrigger);




        // an example of running a single job (but pausing for 3 seconds between each run)
        Thread.Sleep(TimeSpan.FromSeconds(3));

        QuartzManager.TriggerSingleJob<GoodbyeJob>(new Dictionary<string, object>
        {
            { "courierJob", "Test" },
        });

        Thread.Sleep(TimeSpan.FromSeconds(3));

        QuartzManager.TriggerSingleJob<GoodbyeJob>(new Dictionary<string, object>
        {
            { "courierJob", "Test" },
        });

        Thread.Sleep(TimeSpan.FromSeconds(3));

        QuartzManager.TriggerSingleJob<GoodbyeJob>(new Dictionary<string, object>
        {
            { "courierJob", "Test" },
        });





        // just to hold console open
        Console.ReadLine();
    }
}

