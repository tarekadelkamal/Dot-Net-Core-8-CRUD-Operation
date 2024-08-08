using GameZone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;

namespace GameZone.EntitiesConfiguration
{
    public class CategoryConf : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(LoadData());
        }

        public List<Category> LoadData()
        {
            return new List<Category>
            {
                new Category { Id = 1, Name = "Ware" },
                new Category { Id = 2, Name = "FootBall" },
                new Category { Id = 3, Name = "Car" }
            };
        }
    }
}
