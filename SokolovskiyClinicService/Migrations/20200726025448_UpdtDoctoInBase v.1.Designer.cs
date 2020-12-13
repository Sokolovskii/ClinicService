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
    [Migration("20200726025448_UpdtDoctoInBase v.1")]
    partial class UpdtDoctoInBasev1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("sokolovskiy_clinic_service.Models.DomainModels.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfDismissal")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfessionId")
                        .HasColumnType("int");

                    b.Property<bool>("RemovedFlag")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfDismissal = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Джон Краммер",
                            ProfessionId = 1,
                            RemovedFlag = false
                        },
                        new
                        {
                            Id = 2,
                            DateOfDismissal = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Итачи Учиха",
                            ProfessionId = 1,
                            RemovedFlag = false
                        },
                        new
                        {
                            Id = 3,
                            DateOfDismissal = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Киллер Би",
                            ProfessionId = 3,
                            RemovedFlag = false
                        });
                });

            modelBuilder.Entity("sokolovskiy_clinic_service.Models.DomainModels.Profession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Professions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Хирург"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Окулист"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Терапевт"
                        });
                });

            modelBuilder.Entity("sokolovskiy_clinic_service.Models.DomainModels.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ActualisationDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("BeginOfWorkDay")
                        .HasColumnType("time");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndOfWorkDay")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Schedules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActualisationDate = new DateTime(2020, 7, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            BeginOfWorkDay = new TimeSpan(0, 8, 30, 0, 0),
                            DoctorId = 1,
                            EndOfWorkDay = new TimeSpan(0, 18, 0, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            ActualisationDate = new DateTime(2020, 7, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            BeginOfWorkDay = new TimeSpan(0, 9, 0, 0, 0),
                            DoctorId = 2,
                            EndOfWorkDay = new TimeSpan(0, 15, 0, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            ActualisationDate = new DateTime(2020, 7, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            BeginOfWorkDay = new TimeSpan(0, 10, 0, 0, 0),
                            DoctorId = 3,
                            EndOfWorkDay = new TimeSpan(0, 17, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("sokolovskiy_clinic_service.Models.DomainModels.Session", b =>
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2020, 7, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            DoctorId = 1,
                            TimeOfBeginSession = new TimeSpan(0, 9, 0, 0, 0),
                            TimeOfEndSession = new TimeSpan(0, 9, 30, 0, 0),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("sokolovskiy_clinic_service.Models.DomainModels.User", b =>
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "login1",
                            Name = "Наруто Узумаки",
                            PassHash = "dattebayo",
                            Role = 0
                        },
                        new
                        {
                            Id = 2,
                            Login = "login2",
                            Name = "Хатаке Какаши",
                            PassHash = "RinOneLove",
                            Role = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}