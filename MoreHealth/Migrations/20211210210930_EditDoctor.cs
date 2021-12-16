using Microsoft.EntityFrameworkCore.Migrations;

namespace MoreHealth.Migrations
{
    public partial class EditDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentHome_Patient_PatientId",
                table: "AppointmentHome");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentHome",
                table: "AppointmentHome");

            migrationBuilder.RenameTable(
                name: "AppointmentHome",
                newName: "AppointmentHomes");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentHome_PatientId",
                table: "AppointmentHomes",
                newName: "IX_AppointmentHomes_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentHomes",
                table: "AppointmentHomes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentHomes_Patient_PatientId",
                table: "AppointmentHomes",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentHomes_Patient_PatientId",
                table: "AppointmentHomes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentHomes",
                table: "AppointmentHomes");

            migrationBuilder.RenameTable(
                name: "AppointmentHomes",
                newName: "AppointmentHome");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentHomes_PatientId",
                table: "AppointmentHome",
                newName: "IX_AppointmentHome_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentHome",
                table: "AppointmentHome",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentHome_Patient_PatientId",
                table: "AppointmentHome",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
