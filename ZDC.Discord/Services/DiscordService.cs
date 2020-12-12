using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using ZDC.Discord.Data;
using ZDC.Discord.Models;

namespace ZDC.Discord.Services
{
    public class DiscordService
    {
        public static async Task GetRatingsRole(SocketGuild guild, SocketGuildUser guildUser, User user)
        {
            switch (user.Rating)
            {
                case VatsimRating.NONE:
                    // Get role to add
                    var role = guild.GetRole(Constants.ObsRole);

                    // Add role
                    await guildUser.AddRoleAsync(role);

                    // Send message saying their role was added
                    var dm = await guildUser.GetOrCreateDMChannelAsync();
                    await dm.SendMessageAsync($"ZDC discord rating added: `{VatsimRating.OBS}`");

                    break;
                case VatsimRating.OBS:
                    // Get role to add
                    var role = guild.GetRole(Constants.ObsRole);

                    // Add role
                    await guildUser.AddRoleAsync(role);

                    // Send message saying their role was added
                    var dm = await guildUser.GetOrCreateDMChannelAsync();
                    await dm.SendMessageAsync($"ZDC discord rating added: `{VatsimRating.OBS}`");
                    break;
                case VatsimRating.S1:
                    break;
                case VatsimRating.S2:
                    break;
                case VatsimRating.S3:
                    break;
                case VatsimRating.C1:
                    break;
                case VatsimRating.C2:
                    break;
                case VatsimRating.C3:
                    break;
                case VatsimRating.I1:
                    break;
                case VatsimRating.I2:
                    break;
                case VatsimRating.I3:
                    break;
                case VatsimRating.SUP:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static async Task UpdateRatingsRole(SocketGuild guild, SocketGuildUser guildUser, SocketRole role, User user)
        {
            // Switch through the user's rating
            switch (user.Rating)
            {
                case VatsimRating.NONE:
                    if (role.Id != Constants.ObsRole)
                    {
                        // Remove role
                        await guildUser.RemoveRoleAsync(role);

                        // Get matching rating role
                        var ratingRole = guild.Roles
                            .FirstOrDefault(x => x.Id == Constants.ObsRole);

                        // Set their role
                        await guildUser.AddRoleAsync(ratingRole);

                        // Send message saying their role was updated
                        var dm = await guildUser.GetOrCreateDMChannelAsync();
                        await dm.SendMessageAsync($"ZDC discord rating updated to `{VatsimRating.OBS}`");
                    }

                    break;
                case VatsimRating.OBS:
                    if (role.Id != Constants.ObsRole)
                    {
                        // Remove role
                        await guildUser.RemoveRoleAsync(role);

                        // Get matching rating role
                        var ratingRole = guild.Roles
                            .FirstOrDefault(x => x.Id == Constants.ObsRole);

                        // Set their role
                        await guildUser.AddRoleAsync(ratingRole);

                        // Send message saying their role was updated
                        var dm = await guildUser.GetOrCreateDMChannelAsync();
                        await dm.SendMessageAsync($"ZDC discord rating updated to `{VatsimRating.OBS}`");
                    }

                    break;
                case VatsimRating.S1:
                    if (role.Id != Constants.S1Role)
                    {
                        // Remove role
                        await guildUser.RemoveRoleAsync(role);

                        // Get matching rating role
                        var ratingRole = guild.Roles
                            .FirstOrDefault(x => x.Id == Constants.S1Role);

                        // Set their role
                        await guildUser.AddRoleAsync(ratingRole);

                        // Send message saying their role was updated
                        var dm = await guildUser.GetOrCreateDMChannelAsync();
                        await dm.SendMessageAsync($"ZDC discord rating updated to `{VatsimRating.S1}`");
                    }

                    break;
                case VatsimRating.S2:
                    if (role.Id != Constants.S2Role)
                    {
                        // Remove role
                        await guildUser.RemoveRoleAsync(role);

                        // Get matching rating role
                        var ratingRole = guild.Roles
                            .FirstOrDefault(x => x.Id == Constants.S2Role);

                        // Set their role
                        await guildUser.AddRoleAsync(ratingRole);

                        // Send message saying their role was updated
                        var dm = await guildUser.GetOrCreateDMChannelAsync();
                        await dm.SendMessageAsync($"ZDC discord rating updated to `{VatsimRating.S2}`");
                    }

                    break;
                case VatsimRating.S3:
                    if (role.Id != Constants.S3Role)
                    {
                        // Remove role
                        await guildUser.RemoveRoleAsync(role);

                        // Get matching rating role
                        var ratingRole = guild.Roles
                            .FirstOrDefault(x => x.Id == Constants.S3Role);

                        // Set their role
                        await guildUser.AddRoleAsync(ratingRole);

                        // Send message saying their role was updated
                        var dm = await guildUser.GetOrCreateDMChannelAsync();
                        await dm.SendMessageAsync($"ZDC discord rating updated to `{VatsimRating.S3}`");
                    }

                    break;
                case VatsimRating.C1:
                    if (role.Id != Constants.C1Role)
                    {
                        // Remove role
                        await guildUser.RemoveRoleAsync(role);

                        // Get matching rating role
                        var ratingRole = guild.Roles
                            .FirstOrDefault(x => x.Id == Constants.C1Role);

                        // Set their role
                        await guildUser.AddRoleAsync(ratingRole);

                        // Send message saying their role was updated
                        var dm = await guildUser.GetOrCreateDMChannelAsync();
                        await dm.SendMessageAsync($"ZDC discord rating updated to `{VatsimRating.C1}`");
                    }

                    break;
                case VatsimRating.C2:
                    if (role.Id != Constants.C1Role)
                    {
                        // Remove role
                        await guildUser.RemoveRoleAsync(role);

                        // Get matching rating role
                        var ratingRole = guild.Roles
                            .FirstOrDefault(x => x.Id == Constants.C1Role);

                        // Set their role
                        await guildUser.AddRoleAsync(ratingRole);

                        // Send message saying their role was updated
                        var dm = await guildUser.GetOrCreateDMChannelAsync();
                        await dm.SendMessageAsync($"ZDC discord rating updated to `{VatsimRating.C1}`");
                    }

                    break;
                case VatsimRating.C3:
                    if (role.Id != Constants.C3Role)
                    {
                        // Remove role
                        await guildUser.RemoveRoleAsync(role);

                        // Get matching rating role
                        var ratingRole = guild.Roles
                            .FirstOrDefault(x => x.Id == Constants.C3Role);

                        // Set their role
                        await guildUser.AddRoleAsync(ratingRole);

                        // Send message saying their role was updated
                        var dm = await guildUser.GetOrCreateDMChannelAsync();
                        await dm.SendMessageAsync($"ZDC discord rating updated to `{VatsimRating.C3}`");
                    }

                    break;
                case VatsimRating.I1:
                    if (role.Id != Constants.I1Role)
                    {
                        // Remove role
                        await guildUser.RemoveRoleAsync(role);

                        // Get matching rating role
                        var ratingRole = guild.Roles
                            .FirstOrDefault(x => x.Id == Constants.I1Role);

                        // Set their role
                        await guildUser.AddRoleAsync(ratingRole);

                        // Send message saying their role was updated
                        var dm = await guildUser.GetOrCreateDMChannelAsync();
                        await dm.SendMessageAsync($"ZDC discord rating updated to `{VatsimRating.I1}`");
                    }

                    break;
                case VatsimRating.I2:
                    if (role.Id != Constants.I1Role)
                    {
                        // Remove role
                        await guildUser.RemoveRoleAsync(role);

                        // Get matching rating role
                        var ratingRole = guild.Roles
                            .FirstOrDefault(x => x.Id == Constants.I1Role);

                        // Set their role
                        await guildUser.AddRoleAsync(ratingRole);

                        // Send message saying their role was updated
                        var dm = await guildUser.GetOrCreateDMChannelAsync();
                        await dm.SendMessageAsync($"ZDC discord rating updated to `{VatsimRating.I1}`");
                    }

                    break;
                case VatsimRating.I3:
                    if (role.Id != Constants.I3Role)
                    {
                        // Remove role
                        await guildUser.RemoveRoleAsync(role);

                        // Get matching rating role
                        var ratingRole = guild.Roles
                            .FirstOrDefault(x => x.Id == Constants.I3Role);

                        // Set their role
                        await guildUser.AddRoleAsync(ratingRole);

                        // Send message saying their role was updated
                        var dm = await guildUser.GetOrCreateDMChannelAsync();
                        await dm.SendMessageAsync($"ZDC discord rating updated to `{VatsimRating.I3}`");
                    }

                    break;
                case VatsimRating.SUP:
                    if (role.Id != Constants.SupRole)
                    {
                        // Remove role
                        await guildUser.RemoveRoleAsync(role);

                        // Get matching rating role
                        var ratingRole = guild.Roles
                            .FirstOrDefault(x => x.Id == Constants.SupRole);

                        // Set their role
                        await guildUser.AddRoleAsync(ratingRole);

                        // Send message saying their role was updated
                        var dm = await guildUser.GetOrCreateDMChannelAsync();
                        await dm.SendMessageAsync($"ZDC discord rating updated to `{VatsimRating.SUP}`");
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
