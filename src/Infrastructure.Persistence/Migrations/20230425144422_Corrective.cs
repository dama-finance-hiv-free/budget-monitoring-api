using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class Corrective : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "project",
                schema: "budgeting",
                table: "runner_period_history",
                type: "character varying(3)",
                unicode: false,
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "project",
                schema: "budgeting",
                table: "runner_period",
                type: "character varying(3)",
                unicode: false,
                maxLength: 3,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "project",
                schema: "budgeting",
                table: "runner_period_history");

            migrationBuilder.DropColumn(
                name: "project",
                schema: "budgeting",
                table: "runner_period");
        }
    }
}
