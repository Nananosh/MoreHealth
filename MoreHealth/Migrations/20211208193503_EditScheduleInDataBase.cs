using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoreHealth.Migrations
{
    public partial class EditScheduleInDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Doctor_DoctorId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Patient_PatientId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkSchedule_WorkDate_WorkDateId",
                table: "WorkSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkSchedule_WorkingShift_WorkingShiftId",
                table: "WorkSchedule");

            migrationBuilder.DropTable(
                name: "DoctorWorkSchedule");

            migrationBuilder.DropTable(
                name: "WorkDate");

            migrationBuilder.DropTable(
                name: "WorkingShift");

            migrationBuilder.DropIndex(
                name: "IX_WorkSchedule_WorkDateId",
                table: "WorkSchedule");

            migrationBuilder.DropColumn(
                name: "WorkDateId",
                table: "WorkSchedule");

            migrationBuilder.RenameColumn(
                name: "WorkingShiftId",
                table: "WorkSchedule",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkSchedule_WorkingShiftId",
                table: "WorkSchedule",
                newName: "IX_WorkSchedule_DoctorId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "WorkSchedule",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RecurrenceRule",
                table: "WorkSchedule",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "WorkSchedule",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Feedback",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Feedback",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Doctor_DoctorId",
                table: "Feedback",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Patient_PatientId",
                table: "Feedback",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSchedule_Doctor_DoctorId",
                table: "WorkSchedule",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Doctor_DoctorId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Patient_PatientId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkSchedule_Doctor_DoctorId",
                table: "WorkSchedule");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "WorkSchedule");

            migrationBuilder.DropColumn(
                name: "RecurrenceRule",
                table: "WorkSchedule");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "WorkSchedule");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "WorkSchedule",
                newName: "WorkingShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkSchedule_DoctorId",
                table: "WorkSchedule",
                newName: "IX_WorkSchedule_WorkingShiftId");

            migrationBuilder.AddColumn<int>(
                name: "WorkDateId",
                table: "WorkSchedule",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Feedback",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Feedback",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DoctorWorkSchedule",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    WorkSchedulesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorWorkSchedule", x => new { x.DoctorId, x.WorkSchedulesId });
                    table.ForeignKey(
                        name: "FK_DoctorWorkSchedule_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorWorkSchedule_WorkSchedule_WorkSchedulesId",
                        column: x => x.WorkSchedulesId,
                        principalTable: "WorkSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkDate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingShift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndWorkShift = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartWorkShift = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingShift", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkSchedule_WorkDateId",
                table: "WorkSchedule",
                column: "WorkDateId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorWorkSchedule_WorkSchedulesId",
                table: "DoctorWorkSchedule",
                column: "WorkSchedulesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Doctor_DoctorId",
                table: "Feedback",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Patient_PatientId",
                table: "Feedback",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSchedule_WorkDate_WorkDateId",
                table: "WorkSchedule",
                column: "WorkDateId",
                principalTable: "WorkDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSchedule_WorkingShift_WorkingShiftId",
                table: "WorkSchedule",
                column: "WorkingShiftId",
                principalTable: "WorkingShift",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
