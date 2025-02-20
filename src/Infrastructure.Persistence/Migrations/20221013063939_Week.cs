using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class Week : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "week",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    week_serial = table.Column<int>(type: "integer", nullable: false),
                    week_start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    week_end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_week", x => new { x.tenant, x.cop_year, x.week_serial });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "week",
                schema: "common");
        }
    }
}
