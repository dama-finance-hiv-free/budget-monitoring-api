using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class BudgetCodeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_budget_code",
                schema: "budgeting",
                table: "budget_code");

            migrationBuilder.DropColumn(
                name: "cop_year",
                schema: "budgeting",
                table: "budget_code");

            migrationBuilder.AddPrimaryKey(
                name: "pk_budget_code",
                schema: "budgeting",
                table: "budget_code",
                columns: new[] { "tenant", "code" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_budget_code",
                schema: "budgeting",
                table: "budget_code");

            migrationBuilder.AddColumn<string>(
                name: "cop_year",
                schema: "budgeting",
                table: "budget_code",
                type: "character varying(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "pk_budget_code",
                schema: "budgeting",
                table: "budget_code",
                columns: new[] { "tenant", "code", "cop_year" });
        }
    }
}
