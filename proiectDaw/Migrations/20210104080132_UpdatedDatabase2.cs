using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace proiectDaw.Migrations
{
    public partial class UpdatedDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_softwareDevelopers_projects_ProjectId",
                table: "softwareDevelopers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_softwareDevelopers",
                table: "softwareDevelopers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projects",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "SoftwareDeveloperId",
                table: "softwareDevelopers");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "projects");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "softwareDevelopers",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "projects",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_softwareDevelopers",
                table: "softwareDevelopers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_projects",
                table: "projects",
                column: "Id");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_softwareDevelopers",
                table: "softwareDevelopers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projects",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "softwareDevelopers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "projects");

            migrationBuilder.AddColumn<int>(
                name: "SoftwareDeveloperId",
                table: "softwareDevelopers",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "projects",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_softwareDevelopers",
                table: "softwareDevelopers",
                column: "SoftwareDeveloperId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_projects",
                table: "projects",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_softwareDevelopers_projects_ProjectId",
                table: "softwareDevelopers",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
