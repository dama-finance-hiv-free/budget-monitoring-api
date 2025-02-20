using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class removeProjectFromSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "project",
                schema: "budgeting",
                table: "site");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "project",
                schema: "budgeting",
                table: "site",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true);
        }
    }
}
