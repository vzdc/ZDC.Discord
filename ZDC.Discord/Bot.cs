using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ZDC.Discord.Data;

namespace ZDC.Discord
{
    public class Bot : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly ZdcContext _context;
        private readonly ILogger<Bot> _logger;
        private DiscordSocketClient _client;

        public Bot(ILogger<Bot> logger, IConfiguration configuration, ZdcContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Configure the bot
            ConfigureBot().Wait();
        }

        /// <summary>
        ///     Function to configure the bot and start it
        /// </summary>
        public async Task ConfigureBot()
        {
            // Create the bot object
            _client = new DiscordSocketClient();

            // Get the token
            var token = _configuration.GetValue<string>("DiscordToken");

            // Login
            await _client.LoginAsync(TokenType.Bot, token);

            // Start bot
            await _client.StartAsync();

            // Start roles job
            await StartJobs.StartAllJobs(_context, _client);
        }

        /// <summary>
        ///     Function to execute the worker service
        /// </summary>
        /// <param name="stoppingToken">Token to cancel execution</param>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
                // Run until cancelled
                await Task.Delay(-1, stoppingToken);

            // Stop bot since we broke out of the while loop
            await _client.StopAsync();
        }
    }
}