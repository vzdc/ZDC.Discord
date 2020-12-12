using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using ZDC.Discord.Data;
using ZDC.Discord.Models;

namespace ZDC.Discord.Services
{
    public class DiscordService
    {
        public static async Task SetRating(SocketGuild guild, SocketGuildUser guildUser, ulong newRole, VatsimRating rating)
        {
            // Get role to add
            var role = guild.GetRole(newRole);

            // Add role
            await guildUser.AddRoleAsync(role);

            // Send message saying their role was added
            var dm = await guildUser.GetOrCreateDMChannelAsync();
            await dm.SendMessageAsync($"ZDC discord rating added: `{rating}`");
        }

        public static async Task UpdateRating(SocketGuild guild, SocketGuildUser guildUser, ulong newRole,
            ulong oldRole, VatsimRating rating)
        {
            // Get old role
            var role = guild.GetRole(oldRole);

            // Remove role
            await guildUser.RemoveRoleAsync(role);

            // Get matching rating role
            var ratingRole = guild.Roles
                .FirstOrDefault(x => x.Id == newRole);

            // Set their role
            await guildUser.AddRoleAsync(ratingRole);

            // Send message saying their role was updated
            var dm = await guildUser.GetOrCreateDMChannelAsync();
            await dm.SendMessageAsync($"ZDC discord rating updated to `{rating}`");
        }

        public static async Task SetRatingsRole(SocketGuild guild, SocketGuildUser guildUser, User user)
        {
            switch (user.Rating)
            {
                case VatsimRating.NONE:
                    // Set new role
                    await SetRating(guild, guildUser, Constants.ObsRole, VatsimRating.OBS);
                    break;
                case VatsimRating.OBS:
                    // Set new role
                    await SetRating(guild, guildUser, Constants.ObsRole, VatsimRating.OBS);
                    break;
                case VatsimRating.S1:
                    // Set new role
                    await SetRating(guild, guildUser, Constants.S1Role, VatsimRating.S1);
                    break;
                case VatsimRating.S2:
                    // Set new role
                    await SetRating(guild, guildUser, Constants.S2Role, VatsimRating.S2);
                    break;
                case VatsimRating.S3:
                    // Set new role
                    await SetRating(guild, guildUser, Constants.S3Role, VatsimRating.S3);
                    break;
                case VatsimRating.C1:
                    // Set new role
                    await SetRating(guild, guildUser, Constants.C1Role, VatsimRating.C1);
                    break;
                case VatsimRating.C2:
                    // Set new role
                    await SetRating(guild, guildUser, Constants.C1Role, VatsimRating.C1);
                    break;
                case VatsimRating.C3:
                    // Set new role
                    await SetRating(guild, guildUser, Constants.C3Role, VatsimRating.C3);
                    break;
                case VatsimRating.I1:
                    // Set new role
                    await SetRating(guild, guildUser, Constants.I1Role, VatsimRating.I1);
                    break;
                case VatsimRating.I2:
                    // Set new role
                    await SetRating(guild, guildUser, Constants.I1Role, VatsimRating.I1);
                    break;
                case VatsimRating.I3:
                    // Set new role
                    await SetRating(guild, guildUser, Constants.I3Role, VatsimRating.I3);
                    break;
                case VatsimRating.SUP:
                    // Set new role
                    await SetRating(guild, guildUser, Constants.SupRole, VatsimRating.SUP);
                    break;
                default:
                    // Set new role
                    await SetRating(guild, guildUser, Constants.ObsRole, VatsimRating.OBS);
                    break;
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
                        // Update rating
                        await UpdateRating(guild, guildUser, Constants.ObsRole, role.Id, VatsimRating.OBS);
                    }

                    break;
                case VatsimRating.OBS:
                    if (role.Id != Constants.ObsRole)
                    {
                        // Update rating
                        await UpdateRating(guild, guildUser, Constants.ObsRole, role.Id, VatsimRating.OBS);
                    }

                    break;
                case VatsimRating.S1:
                    if (role.Id != Constants.S1Role)
                    {
                        // Update rating
                        await UpdateRating(guild, guildUser, Constants.S1Role, role.Id, VatsimRating.S1);
                    }

                    break;
                case VatsimRating.S2:
                    if (role.Id != Constants.S2Role)
                    {
                        // Update rating
                        await UpdateRating(guild, guildUser, Constants.S2Role, role.Id, VatsimRating.S2);
                    }

                    break;
                case VatsimRating.S3:
                    if (role.Id != Constants.S3Role)
                    {
                        // Update rating
                        await UpdateRating(guild, guildUser, Constants.S3Role, role.Id, VatsimRating.S3);
                    }

                    break;
                case VatsimRating.C1:
                    if (role.Id != Constants.C1Role)
                    {
                        // Update rating
                        await UpdateRating(guild, guildUser, Constants.C1Role, role.Id, VatsimRating.C1);
                    }

                    break;
                case VatsimRating.C2:
                    if (role.Id != Constants.C1Role)
                    {
                        // Update rating
                        await UpdateRating(guild, guildUser, Constants.C1Role, role.Id, VatsimRating.C1);
                    }

                    break;
                case VatsimRating.C3:
                    if (role.Id != Constants.C3Role)
                    {
                        // Update rating
                        await UpdateRating(guild, guildUser, Constants.C3Role, role.Id, VatsimRating.C3);
                    }

                    break;
                case VatsimRating.I1:
                    if (role.Id != Constants.I1Role)
                    {
                        // Update rating
                        await UpdateRating(guild, guildUser, Constants.I1Role, role.Id, VatsimRating.I1);
                    }

                    break;
                case VatsimRating.I2:
                    if (role.Id != Constants.I1Role)
                    {
                        // Update rating
                        await UpdateRating(guild, guildUser, Constants.I1Role, role.Id, VatsimRating.I1);
                    }

                    break;
                case VatsimRating.I3:
                    if (role.Id != Constants.I3Role)
                    {
                        // Update rating
                        await UpdateRating(guild, guildUser, Constants.I3Role, role.Id, VatsimRating.I3);
                    }

                    break;
                case VatsimRating.SUP:
                    if (role.Id != Constants.SupRole)
                    {
                        // Update rating
                        await UpdateRating(guild, guildUser, Constants.SupRole, role.Id, VatsimRating.SUP);
                    }

                    break;
                default:
                    // Update rating
                    await UpdateRating(guild, guildUser, Constants.ObsRole, role.Id, VatsimRating.OBS);
                    break;
            }
        }
    }
}
