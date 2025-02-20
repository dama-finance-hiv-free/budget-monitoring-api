using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class RunnerProjectMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_runner_history",
                schema: "budgeting",
                table: "runner_history");

            migrationBuilder.DropPrimaryKey(
                name: "pk_runner",
                schema: "budgeting",
                table: "runner");

            migrationBuilder.AddColumn<string>(
                name: "project",
                schema: "budgeting",
                table: "runner_history",
                type: "character varying(3)",
                unicode: false,
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "project",
                schema: "budgeting",
                table: "runner",
                type: "character varying(3)",
                unicode: false,
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "pk_runner_history",
                schema: "budgeting",
                table: "runner_history",
                columns: new[] { "tenant", "cop_year", "code", "region", "project" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_runner",
                schema: "budgeting",
                table: "runner",
                columns: new[] { "tenant", "cop_year", "code", "region", "project" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_runner_history",
                schema: "budgeting",
                table: "runner_history");

            migrationBuilder.DropPrimaryKey(
                name: "pk_runner",
                schema: "budgeting",
                table: "runner");

            migrationBuilder.DropColumn(
                name: "project",
                schema: "budgeting",
                table: "runner_history");

            migrationBuilder.DropColumn(
                name: "project",
                schema: "budgeting",
                table: "runner");

            migrationBuilder.AddPrimaryKey(
                name: "pk_runner_history",
                schema: "budgeting",
                table: "runner_history",
                columns: new[] { "tenant", "cop_year", "code", "region" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_runner",
                schema: "budgeting",
                table: "runner",
                columns: new[] { "tenant", "cop_year", "code", "region" });
        }
    }
}
