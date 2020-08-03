using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SokolovskiyClinicService.Migrations
{
    public partial class update_database_v12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "BeginOfWorkDay",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "EndOfWorkDay",
                table: "Schedules");

            migrationBuilder.AddColumn<int>(
                name: "FridayId",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MondayId",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThursdayId",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TuesdayId",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WednesdayId",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Doctors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "workDays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeginOfDay = table.Column<TimeSpan>(nullable: false),
                    EndOfDay = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workDays", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_FridayId",
                table: "Schedules",
                column: "FridayId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_MondayId",
                table: "Schedules",
                column: "MondayId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ThursdayId",
                table: "Schedules",
                column: "ThursdayId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TuesdayId",
                table: "Schedules",
                column: "TuesdayId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_WednesdayId",
                table: "Schedules",
                column: "WednesdayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_workDays_FridayId",
                table: "Schedules",
                column: "FridayId",
                principalTable: "workDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_workDays_MondayId",
                table: "Schedules",
                column: "MondayId",
                principalTable: "workDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_workDays_ThursdayId",
                table: "Schedules",
                column: "ThursdayId",
                principalTable: "workDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_workDays_TuesdayId",
                table: "Schedules",
                column: "TuesdayId",
                principalTable: "workDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_workDays_WednesdayId",
                table: "Schedules",
                column: "WednesdayId",
                principalTable: "workDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_workDays_FridayId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_workDays_MondayId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_workDays_ThursdayId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_workDays_TuesdayId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_workDays_WednesdayId",
                table: "Schedules");

            migrationBuilder.DropTable(
                name: "workDays");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_FridayId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_MondayId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_ThursdayId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_TuesdayId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_WednesdayId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "FridayId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "MondayId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "ThursdayId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "TuesdayId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "WednesdayId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Doctors");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "BeginOfWorkDay",
                table: "Schedules",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndOfWorkDay",
                table: "Schedules",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "DateOfDismissal", "IsRemoved", "Name", "ProfessionId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Хатаке Какаши", 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Итачи Учиха", 2 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Харуно Сакура", 3 }
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
                    { 1, new DateTime(2020, 7, 26, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 8, 30, 0, 0), 1, new TimeSpan(0, 18, 0, 0, 0) },
                    { 2, new DateTime(2020, 7, 26, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 9, 0, 0, 0), 2, new TimeSpan(0, 15, 0, 0, 0) },
                    { 3, new DateTime(2020, 7, 26, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 10, 0, 0, 0), 3, new TimeSpan(0, 17, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Date", "DoctorId", "TimeOfBeginSession", "TimeOfEndSession", "UserId" },
                values: new object[] { 1, new DateTime(2020, 7, 26, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 9, 0, 0, 0), new TimeSpan(0, 9, 30, 0, 0), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "PassHash", "Role" },
                values: new object[,]
                {
                    { 1, "login1", "Наруто Узумаки", "dattebayo", 0 },
                    { 2, "login2", "Хатаке Какаши", "RinOneLove", 1 }
                });
        }
    }
}
