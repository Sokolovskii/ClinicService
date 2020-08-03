using Microsoft.EntityFrameworkCore.Migrations;

namespace SokolovskiyClinicService.Migrations
{
    public partial class update_database_v13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "WednesdayId",
                table: "Schedules",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TuesdayId",
                table: "Schedules",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ThursdayId",
                table: "Schedules",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MondayId",
                table: "Schedules",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FridayId",
                table: "Schedules",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Schedules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SaturdayId",
                table: "Schedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SundayId",
                table: "Schedules",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "SaturdayId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "SundayId",
                table: "Schedules");

            migrationBuilder.AlterColumn<int>(
                name: "WednesdayId",
                table: "Schedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TuesdayId",
                table: "Schedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ThursdayId",
                table: "Schedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MondayId",
                table: "Schedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FridayId",
                table: "Schedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
