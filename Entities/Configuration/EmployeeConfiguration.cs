using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    FirstName = "Rose",
                    LastName = "Lee",
                    Job = "ASP.NET Core Developer",
                    EmploymentDate = new DateTime(2021, 4, 10)
                }, 
                new Employee
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    FirstName = "Nick",
                    LastName = "Lee",
                    Job = "Unity Developer",
                    EmploymentDate = new DateTime(2021, 4, 12)     
                }
            );
        }
    }
}