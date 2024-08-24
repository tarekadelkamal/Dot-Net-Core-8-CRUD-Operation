using GameZone.EntitiesConfiguration;
using GameZone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace GameZone
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GamesConf());
            modelBuilder.ApplyConfiguration(new DeviceConf());
            modelBuilder.ApplyConfiguration(new CategoryConf());
            modelBuilder.ApplyConfiguration(new DeviceGameConf());
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceGame> DeviceGames { get; set; }
    }
}
