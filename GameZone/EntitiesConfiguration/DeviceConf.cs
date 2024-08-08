using GameZone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZone.EntitiesConfiguration
{
    public class DeviceConf : IEntityTypeConfiguration<Device> 
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasData(LoadData());

            builder.HasMany(w => w.Games)
                .WithOne(w => w.Device);
        }

        public List<Device> LoadData()
        {
            return new List<Device>
            {
                new Device{Id = 1, Name = "PlayStation", Icon = "bi bi-playstation"},
                new Device{Id = 2, Name = "Xbox", Icon = "bi bi-xbox"},
                new Device{Id = 3, Name = "Nintendo Switch", Icon = "bi bi-nintendo-switch"},
                new Device{Id = 4, Name = "PC", Icon = "bi bi-pc-display"}
            };
        }
    }
}
