using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class SiteRmvCopYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_site",
                schema: "budgeting",
                table: "site");

            migrationBuilder.DropColumn(
                name: "cop_year",
                schema: "budgeting",
                table: "site");

            migrationBuilder.AddPrimaryKey(
                name: "pk_site",
                schema: "budgeting",
                table: "site",
                columns: new[] { "tenant", "code" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_site",
                schema: "budgeting",
                table: "site");

            migrationBuilder.AddColumn<string>(
                name: "cop_year",
                schema: "budgeting",
                table: "site",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "pk_site",
                schema: "budgeting",
                table: "site",
                columns: new[] { "tenant", "code", "cop_year" });
        }
    }
}
