using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class ComponentWeek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "component",
                schema: "common",
                table: "week",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "component_week_serial",
                schema: "common",
                table: "week",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "component",
                schema: "common",
                table: "week");

            migrationBuilder.DropColumn(
                name: "component_week_serial",
                schema: "common",
                table: "week");
        }
    }
}
