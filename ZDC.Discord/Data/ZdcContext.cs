using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ZDC.Discord.Models;

namespace ZDC.Discord.Data
{
    public class ZdcContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ZdcContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ZdcSync> ZdcSync { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_configuration.GetValue<string>("ConnectionString"));
        }
    }
}