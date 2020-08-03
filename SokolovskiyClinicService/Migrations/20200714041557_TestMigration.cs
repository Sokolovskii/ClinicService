using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SokolovskiyClinicService.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ProfessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(nullable: false),
                    BeginOfWorkDay = table.Column<TimeSpan>(nullable: false),
                    EndOfWorkDay = table.Column<TimeSpan>(nullable: false),
                    ActualisationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    TimeOfBeginSession = table.Column<TimeSpan>(nullable: false),
                    TimeOfEndSession = table.Column<TimeSpan>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Login = table.Column<string>(nullable: false),
                    PassHash = table.Column<string>(nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Name", "ProfessionId" },
                values: new object[,]
                {
                    { 1, "Джон Краммер", 1 },
                    { 2, "Итачи Учиха", 1 },
                    { 3, "Киллер Би", 3 }
                });

            migrationBuilder.InsertData(
                table: "Professions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Хирург" },
                    { 2, "Окулист" },
                    { 3, "Терапевт" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "ActualisationDate", "BeginOfWorkDay", "DoctorId", "EndOfWorkDay" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 7, 14, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 8, 30, 0, 0), 1, new TimeSpan(0, 18, 0, 0, 0) },
                    { 2, new DateTime(2020, 7, 14, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 9, 0, 0, 0), 2, new TimeSpan(0, 15, 0, 0, 0) },
                    { 3, new DateTime(2020, 7, 14, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 10, 0, 0, 0), 3, new TimeSpan(0, 17, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Date", "DoctorId", "TimeOfBeginSession", "TimeOfEndSession", "UserId" },
                values: new object[] { 1, new DateTime(2020, 7, 14, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 9, 0, 0, 0), new TimeSpan(0, 9, 30, 0, 0), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "PassHash", "Role" },
                values: new object[,]
                {
                    { 1, "login1", "Наруто Узумаки", "dattebayo", 0 },
                    { 2, "login2", "Хатаке Какаши", "RinOneLove", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
