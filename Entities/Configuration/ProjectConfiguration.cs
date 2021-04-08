using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData(
                new Project
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    Title = "Flying jetpack",
                    StartDate = new DateTime(2021, 3, 11),
                    ReleaseDate = new DateTime(2021, 7, 16)
                },
                new Project
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    Title = "Pokemon REST API",
                    StartDate = new DateTime(2021, 5, 1),
                    ReleaseDate = new DateTime(2021, 6, 12)
                });
        }
    }
}