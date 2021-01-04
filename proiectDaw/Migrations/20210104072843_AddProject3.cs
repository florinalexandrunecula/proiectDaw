using Microsoft.EntityFrameworkCore.Migrations;

namespace proiectDaw.Migrations
{
    public partial class AddProject3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_softwareDevelopers_projects_ProjectId",
                table: "softwareDevelopers");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "softwareDevelopers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_softwareDevelopers_projects_ProjectId",
                table: "softwareDevelopers",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_softwareDevelopers_projects_ProjectId",
                table: "softwareDevelopers");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "softwareDevelopers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_softwareDevelopers_projects_ProjectId",
                table: "softwareDevelopers",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
