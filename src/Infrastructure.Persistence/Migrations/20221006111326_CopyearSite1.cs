using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class CopyearSite1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_cop_year_site",
                schema: "budgeting",
                table: "cop_year_site");

            migrationBuilder.DropColumn(
                name: "project",
                schema: "budgeting",
                table: "cop_year_site");

            migrationBuilder.AddPrimaryKey(
                name: "pk_cop_year_site",
                schema: "budgeting",
                table: "cop_year_site",
                columns: new[] { "tenant", "cop_year", "site" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_cop_year_site",
                schema: "budgeting",
                table: "cop_year_site");

            migrationBuilder.AddColumn<string>(
                name: "project",
                schema: "budgeting",
                table: "cop_year_site",
                type: "character varying(2)",
                unicode: false,
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "pk_cop_year_site",
                schema: "budgeting",
                table: "cop_year_site",
                columns: new[] { "tenant", "cop_year", "project", "site" });
        }
    }
}
