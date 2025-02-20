using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class RstServerStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "server_status",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    region = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    runner = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    day_status = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    batch = table.Column<string>(type: "character varying(7)", unicode: false, maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_server_status", x => new { x.tenant, x.region, x.runner, x.cop_year });
                });

            migrationBuilder.CreateTable(
                name: "server_status_history",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    region = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    runner = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    day_status = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    batch = table.Column<string>(type: "character varying(7)", unicode: false, maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_server_status_history", x => new { x.tenant, x.region, x.runner, x.cop_year });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "server_status",
                schema: "common");

            migrationBuilder.DropTable(
                name: "server_status_history",
                schema: "common");
        }
    }
}
