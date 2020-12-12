using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Discord.WebSocket;
using Quartz;
using Quartz.Impl;
using ZDC.Discord.Data.Jobs;

namespace ZDC.Discord.Data
{
    internal class StartJobs
    {
        public static async Task StartAllJobs(ZdcContext context, DiscordSocketClient client)
        {
            try
            {
                // Grab the Scheduler instance from the Factory
                var props = new NameValueCollection
                {
                    {"quartz.serializer.type", "binary"}
                };
                var Factory = new StdSchedulerFactory(props);
                var Scheduler = await Factory.GetScheduler();

                // Add database context to scheduler context
                Scheduler.Context.Put("context", context);
                Scheduler.Context.Put("discordClient", client);

                // Create update roles job
                var UpdateRolesJob = JobBuilder.Create<UpdateRolesJob>()
                    .WithIdentity("DatafileJob", "Jobs")
                    .Build();

                // Create update roles trigger
                var UpdateRolesTrigger = TriggerBuilder.Create()
                    .WithIdentity("DatafileTrigger", "Jobs")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithIntervalInMinutes(2)
                        .RepeatForever())
                    .Build();

                // Add update roles job to scheduler
                await Scheduler.ScheduleJob(UpdateRolesJob, UpdateRolesTrigger);

                // Start the scheduler
                await Scheduler.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}