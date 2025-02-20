using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class ActivityPlanTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_activity_plan",
                schema: "budgeting",
                table: "activity_plan");

            migrationBuilder.DropColumn(
                name: "cop_year",
                schema: "budgeting",
                table: "activity_plan");

            migrationBuilder.DropColumn(
                name: "project",
                schema: "budgeting",
                table: "activity_plan");

            migrationBuilder.DropColumn(
                name: "approach",
                schema: "budgeting",
                table: "activity_plan");

            migrationBuilder.DropColumn(
                name: "budget_balance",
                schema: "budgeting",
                table: "activity_plan");

            migrationBuilder.DropColumn(
                name: "component",
                schema: "budgeting",
                table: "activity_plan");

            migrationBuilder.DropColumn(
                name: "objective",
                schema: "budgeting",
                table: "activity_plan");

            migrationBuilder.AddPrimaryKey(
                name: "pk_activity_plan",
                schema: "budgeting",
                table: "activity_plan",
                columns: new[] { "tenant", "code" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_activity_plan",
                schema: "budgeting",
                table: "activity_plan");

            migrationBuilder.AddColumn<string>(
                name: "cop_year",
                schema: "budgeting",
                table: "activity_plan",
                type: "character varying(8)",
                unicode: false,
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "project",
                schema: "budgeting",
                table: "activity_plan",
                type: "character varying(2)",
                unicode: false,
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "approach",
                schema: "budgeting",
                table: "activity_plan",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "budget_balance",
                schema: "budgeting",
                table: "activity_plan",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "component",
                schema: "budgeting",
                table: "activity_plan",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "objective",
                schema: "budgeting",
                table: "activity_plan",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "pk_activity_plan",
                schema: "budgeting",
                table: "activity_plan",
                columns: new[] { "tenant", "code", "cop_year", "project" });
        }
    }
}
