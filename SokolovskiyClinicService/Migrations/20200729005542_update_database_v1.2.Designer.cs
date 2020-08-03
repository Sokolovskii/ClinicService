﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SokolovskiyClinicService.Entity;

namespace SokolovskiyClinicService.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200729005542_update_database_v1.2")]
    partial class update_database_v12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SokolovskiyClinicService.Models.DomainModels.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfDismissal")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfessionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("SokolovskiyClinicService.Models.DomainModels.Profession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Professions");
                });

            modelBuilder.Entity("SokolovskiyClinicService.Models.DomainModels.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ActualisationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int?>("FridayId")
                        .HasColumnType("int");

                    b.Property<int?>("MondayId")
                        .HasColumnType("int");

                    b.Property<int?>("ThursdayId")
                        .HasColumnType("int");

                    b.Property<int?>("TuesdayId")
                        .HasColumnType("int");

                    b.Property<int?>("WednesdayId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FridayId");

                    b.HasIndex("MondayId");

                    b.HasIndex("ThursdayId");

                    b.HasIndex("TuesdayId");

                    b.HasIndex("WednesdayId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("SokolovskiyClinicService.Models.DomainModels.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("TimeOfBeginSession")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("TimeOfEndSession")
                        .HasColumnType("time");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("SokolovskiyClinicService.Models.DomainModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SokolovskiyClinicService.Models.DomainModels.WorkDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("BeginOfDay")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("EndOfDay")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("workDays");
                });

            modelBuilder.Entity("SokolovskiyClinicService.Models.DomainModels.Schedule", b =>
                {
                    b.HasOne("SokolovskiyClinicService.Models.DomainModels.WorkDay", "Friday")
                        .WithMany()
                        .HasForeignKey("FridayId");

                    b.HasOne("SokolovskiyClinicService.Models.DomainModels.WorkDay", "Monday")
                        .WithMany()
                        .HasForeignKey("MondayId");

                    b.HasOne("SokolovskiyClinicService.Models.DomainModels.WorkDay", "Thursday")
                        .WithMany()
                        .HasForeignKey("ThursdayId");

                    b.HasOne("SokolovskiyClinicService.Models.DomainModels.WorkDay", "Tuesday")
                        .WithMany()
                        .HasForeignKey("TuesdayId");

                    b.HasOne("SokolovskiyClinicService.Models.DomainModels.WorkDay", "Wednesday")
                        .WithMany()
                        .HasForeignKey("WednesdayId");
                });
#pragma warning restore 612, 618
        }
    }
}
