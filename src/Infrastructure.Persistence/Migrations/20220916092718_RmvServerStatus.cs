using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class RmvServerStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "server_status",
                schema: "common");

            migrationBuilder.DropTable(
                name: "server_status_history",
                schema: "common");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "server_status",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    branch = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    trans_year = table.Column<string>(type: "character varying(4)", unicode: false, maxLength: 4, nullable: false),
                    back_office_only = table.Column<bool>(type: "boolean", nullable: false),
                    cash_trans = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    day_status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    sys_trans = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    trans_ref = table.Column<int>(type: "integer", nullable: false),
                    year_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    year_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_server_status", x => new { x.tenant, x.branch, x.trans_year });
                });

            migrationBuilder.CreateTable(
                name: "server_status_history",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    branch = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    trans_year = table.Column<string>(type: "character varying(4)", unicode: false, maxLength: 4, nullable: false),
                    status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    trans_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    year_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    year_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    year_status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_server_status_history", x => new { x.tenant, x.branch, x.trans_year });
                });
        }
    }
}
