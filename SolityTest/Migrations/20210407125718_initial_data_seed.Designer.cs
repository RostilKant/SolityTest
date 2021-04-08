﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SolityTest.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210407125718_initial_data_seed")]
    partial class initial_data_seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("EmployeeProject", b =>
                {
                    b.Property<Guid>("EmployeesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProjectsId")
                        .HasColumnType("uuid");

                    b.HasKey("EmployeesId", "ProjectsId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("EmployeeProject");
                });

            modelBuilder.Entity("Entities.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("EmployeeId");

                    b.Property<DateTime>("EmploymentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("Id");

                    b.HasIndex("FirstName", "LastName")
                        .IsUnique();

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            EmploymentDate = new DateTime(2021, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Rose",
                            Job = "ASP.NET Core Developer",
                            LastName = "Lee"
                        },
                        new
                        {
                            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            EmploymentDate = new DateTime(2021, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Nick",
                            Job = "Unity Developer",
                            LastName = "Lee"
                        });
                });

            modelBuilder.Entity("Entities.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ProjectId");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            ReleaseDate = new DateTime(2021, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2021, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Flying jetpack"
                        },
                        new
                        {
                            Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                            ReleaseDate = new DateTime(2021, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Pokemon REST API"
                        });
                });

            modelBuilder.Entity("EmployeeProject", b =>
                {
                    b.HasOne("Entities.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}