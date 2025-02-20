using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class InterventionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_intervention",
                schema: "budgeting",
                table: "intervention");

            migrationBuilder.DropColumn(
                name: "cop_year",
                schema: "budgeting",
                table: "intervention");

            migrationBuilder.DropColumn(
                name: "project",
                schema: "budgeting",
                table: "intervention");

            migrationBuilder.AddPrimaryKey(
                name: "pk_intervention",
                schema: "budgeting",
                table: "intervention",
                columns: new[] { "tenant", "code" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_intervention",
                schema: "budgeting",
                table: "intervention");

            migrationBuilder.AddColumn<string>(
                name: "cop_year",
                schema: "budgeting",
                table: "intervention",
                type: "character varying(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "project",
                schema: "budgeting",
                table: "intervention",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "pk_intervention",
                schema: "budgeting",
                table: "intervention",
                columns: new[] { "tenant", "cop_year", "code", "project" });
        }
    }
}
