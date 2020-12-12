using System;
using System.Linq;
using System.Threading.Tasks;
using Discord.Rest;
using Discord.WebSocket;
using Quartz;
using ZDC.Discord.Models;
using ZDC.Discord.Services;

namespace ZDC.Discord.Data.Jobs
{
    internal class UpdateRolesJob : IJob
    {
        public async Task Execute(IJobExecutionContext jobContext)
        {
            // get Quartz scheduler context
            var schedulerContext = jobContext.Scheduler.Context;

            // Pull the ZdcContext object from the scheduler context
            var context = (ZdcContext) schedulerContext.Get("context");

            // Pull the discord service from the scheduler context
            var client = (DiscordSocketClient) schedulerContext.Get("discordClient");

            //Todo update guild id to ZDC post testing
            // Get ZDC discord guild
            var guild = client.GetGuild(787174501565464608);

            // Ensure guild was found
            if (guild != null)
            {
                // Update rating roles
                await UpdateRatingRoles(context, client, guild);

                // Update training roles
                await UpdateTrainingRoles(context, client, guild);

                // Update controller roles
                await UpdateControllerRoles(context, client, guild);
            }
        }

        /// <summary>
        ///     Function to update rating roles
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="client">Discord bot</param>
        /// <param name="guild">Discord guild</param>
        /// <returns></returns>
        public async Task UpdateRatingRoles(ZdcContext context, DiscordSocketClient client, SocketGuild guild)
        {
            // Loop through controllers
            foreach (var user in context.Users.ToList())
            {
                // Try to find corresponding zdc sync data
                var sync = context.ZdcSync
                    .FirstOrDefault(x => x.Id == user.Id);

                // Ensure it was found
                if (sync == null) continue;

                // Ensure guild exists
                if (guild == null) continue;

                // Get user from guild
                var guildUser = guild.Users.FirstOrDefault(x => x.Id == ulong.Parse(sync.Discord));

                // Get rating role
                var role = guildUser.Roles
                    .FirstOrDefault(x => Constants.RatingRoles.Contains(x.Id));

                // If role was found
                if (role != null)
                {
                    // Update ratings
                    await DiscordService.UpdateRatingsRole(guild, guildUser, role, user);
                }
                else
                {
                    // Else get role they should have and add them
                }

            }
        }

        /// <summary>
        ///     Function to update training roles
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="client">Discord bot</param>
        /// <param name="guild">Discord guild</param>
        /// <returns></returns>
        public async Task UpdateTrainingRoles(ZdcContext context, DiscordSocketClient client, SocketGuild guild)
        {
            // Loop through controllers
            foreach (var user in context.Users.ToList())
            {
                // Try to find corresponding zdc sync data
                var sync = context.ZdcSync
                    .FirstOrDefault(x => x.Id == user.Id);

                // Ensure it was found
                if (sync != null) continue;

                // Ensure guild exists
                if (guild != null) continue;

                // Get user from guild
                var guildUser = guild.Users.FirstOrDefault(x => x.Id == ulong.Parse(sync.Discord));

                // Get training role
                var role = guildUser.Roles
                    .FirstOrDefault(x => Constants.TrainingRoles.Contains(x.Id));

                // If role was found
                if (role != null) continue;

                // Switch through training roles
                switch (user.TrainingRole)
                {
                    case TrainingRole.INS:
                        if (role.Id != Constants.InsRole)
                        {
                            // Remove role
                            await guildUser.RemoveRoleAsync(role);

                            // Get matching training role
                            var trainingRole = guild.Roles
                                .FirstOrDefault(x => x.Id == Constants.InsRole);

                            // Set their role
                            await guildUser.AddRoleAsync(trainingRole);

                            // Send message saying their role was updated
                            var dm = await guildUser.GetOrCreateDMChannelAsync();
                            await dm.SendMessageAsync($"ZDC discord training role updated to `{TrainingRole.INS}`");
                        }

                        break;
                    case TrainingRole.MTR:
                        if (role.Id != Constants.MtrRole)
                        {
                            // Remove role
                            await guildUser.RemoveRoleAsync(role);

                            // Get matching training role
                            var trainingRole = guild.Roles
                                .FirstOrDefault(x => x.Id == Constants.MtrRole);

                            // Set their role
                            await guildUser.AddRoleAsync(trainingRole);

                            // Send message saying their role was updated
                            var dm = await guildUser.GetOrCreateDMChannelAsync();
                            await dm.SendMessageAsync($"ZDC discord training role updated to `{TrainingRole.MTR}`");
                        }

                        break;
                    case TrainingRole.None:
                        if (role.Id > 0)
                        {
                            // Remove role
                            await guildUser.RemoveRoleAsync(role);

                            // Send message saying their role was removed
                            var dm = await guildUser.GetOrCreateDMChannelAsync();
                            await dm.SendMessageAsync("ZDC discord training role removed");
                        }

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        ///     Function to update controller roles
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="client">Discord bot</param>
        /// <param name="guild">Discord guild</param>
        /// <returns></returns>
        public async Task UpdateControllerRoles(ZdcContext context, DiscordSocketClient client, SocketGuild guild)
        {
            // Iterate through users
            foreach (var user in context.Users.ToList())
            {
                // Try to find corresponding zdc sync data
                var sync = context.ZdcSync
                    .FirstOrDefault(x => x.Id == user.Id);

                // Ensure it was found
                if (sync != null) continue;

                // Ensure guild exists
                if (guild != null) continue;

                // Get user from guild
                var guildUser = guild.Users.FirstOrDefault(x => x.Id == ulong.Parse(sync.Discord));

                // Get training role
                var role = guildUser.Roles
                    .FirstOrDefault(x => Constants.ControllerRoles.Contains(x.Id));

                // If role was found
                if (role != null)
                    switch (user.Visitor)
                    {
                        case true:
                            if (role.Id != Constants.VisitingControllerRole)
                            {
                                // Remove role
                                await guildUser.RemoveRoleAsync(role);

                                // Get matching controller role
                                var controllerRole = guild.Roles
                                    .FirstOrDefault(x => x.Id == Constants.VisitingControllerRole);

                                // Set their role
                                await guildUser.AddRoleAsync(controllerRole);

                                // Send message saying their role was updated
                                var dm = await guildUser.GetOrCreateDMChannelAsync();
                                await dm.SendMessageAsync("ZDC discord role updated to `Visiting Controller`");
                            }

                            break;
                        case false:
                            if (role.Id != Constants.HomeControllerRole)
                            {
                                // Remove role
                                await guildUser.RemoveRoleAsync(role);

                                // Get matching controller role
                                var controllerRole = guild.Roles
                                    .FirstOrDefault(x => x.Id == Constants.HomeControllerRole);

                                // Set their role
                                await guildUser.AddRoleAsync(controllerRole);

                                // Send message saying their role was updated
                                var dm = await guildUser.GetOrCreateDMChannelAsync();
                                await dm.SendMessageAsync("ZDC discord role updated to `Home Controller`");
                            }

                            break;
                    }
            }
        }
    }
}