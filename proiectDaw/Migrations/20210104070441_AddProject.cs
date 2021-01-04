using Microsoft.EntityFrameworkCore.Migrations;

namespace proiectDaw.Migrations
{
    public partial class AddProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HireDate",
                table: "softwareDevelopers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "softwareDevelopers");
        }
    }
}
