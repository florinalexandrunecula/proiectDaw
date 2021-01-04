using Microsoft.EntityFrameworkCore.Migrations;

namespace proiectDaw.Migrations
{
    public partial class UpdateDatabaseWithEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "softwareDevelopers",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "softwareDevelopers");
        }
    }
}
