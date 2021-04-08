using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolityTest.Migrations
{
    public partial class initial_data_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmploymentDate", "FirstName", "Job", "LastName" },
                values: new object[,]
                {
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new DateTime(2021, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rose", "ASP.NET Core Developer", "Lee" },
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new DateTime(2021, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nick", "Unity Developer", "Lee" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ReleaseDate", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new DateTime(2021, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flying jetpack" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), new DateTime(2021, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pokemon REST API" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"));
        }
    }
}
