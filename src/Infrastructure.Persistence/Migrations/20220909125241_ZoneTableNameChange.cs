using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class ZoneTableNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Zone",
                schema: "budgeting",
                newName: "zone",
                newSchema: "budgeting");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "zone",
                schema: "budgeting",
                newName: "Zone",
                newSchema: "budgeting");
        }
    }
}
