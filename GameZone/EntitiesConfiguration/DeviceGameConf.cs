using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameZone.Models;
namespace GameZone.EntitiesConfiguration
{
    public class DeviceGameConf : IEntityTypeConfiguration<DeviceGame>
    {
        public void Configure(EntityTypeBuilder<DeviceGame> builder)
        {
            builder.HasKey(d => new { d.Id, d.DeviceId, d.GameId });
            builder.Property(d => d.Id).ValueGeneratedOnAdd();
            
        }
    }
}
