using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace proiectDaw.Migrations
{
    public partial class AddProject2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "softwareDevelopers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_softwareDevelopers_ProjectId",
                table: "softwareDevelopers",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_softwareDevelopers_projects_ProjectId",
                table: "softwareDevelopers",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_softwareDevelopers_projects_ProjectId",
                table: "softwareDevelopers");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropIndex(
                name: "IX_softwareDevelopers_ProjectId",
                table: "softwareDevelopers");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "softwareDevelopers");
        }
    }
}
