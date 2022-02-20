using Microsoft.EntityFrameworkCore.Migrations;

namespace MoreHealth.Migrations
{
    public partial class EditFeedback2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Raring",
                table: "Feedback",
                newName: "Rating");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Feedback",
                newName: "Raring");
        }
    }
}
