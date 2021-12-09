using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoreHealth.Migrations
{
    public partial class EditDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Cabinet_CabinetId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "CabinetDoctor");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_CabinetId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CabinetId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IsHome",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Appointments",
                newName: "DateStart");

            migrationBuilder.AddColumn<int>(
                name: "CabinetId",
                table: "Doctor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "AppointmentHome",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentHome", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentHome_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_CabinetId",
                table: "Doctor",
                column: "CabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentHome_PatientId",
                table: "AppointmentHome",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Cabinet_CabinetId",
                table: "Doctor",
                column: "CabinetId",
                principalTable: "Cabinet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Cabinet_CabinetId",
                table: "Doctor");

            migrationBuilder.DropTable(
                name: "AppointmentHome");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_CabinetId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "CabinetId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "DateStart",
                table: "Appointments",
                newName: "Date");

            migrationBuilder.AddColumn<int>(
                name: "CabinetId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHome",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CabinetDoctor",
                columns: table => new
                {
                    CabinetsId = table.Column<int>(type: "int", nullable: false),
                    DoctorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinetDoctor", x => new { x.CabinetsId, x.DoctorsId });
                    table.ForeignKey(
                        name: "FK_CabinetDoctor_Cabinet_CabinetsId",
                        column: x => x.CabinetsId,
                        principalTable: "Cabinet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabinetDoctor_Doctor_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CabinetId",
                table: "Appointments",
                column: "CabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_CabinetDoctor_DoctorsId",
                table: "CabinetDoctor",
                column: "DoctorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Cabinet_CabinetId",
                table: "Appointments",
                column: "CabinetId",
                principalTable: "Cabinet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
