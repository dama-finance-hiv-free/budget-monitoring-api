using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class tickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ticket",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    user_code = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    user_email = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    user_phone_number = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    region = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: false),
                    comment = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ticket", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "ticket_status",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    description = table.Column<string>(type: "character varying(75)", unicode: false, maxLength: 75, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ticket_status", x => new { x.tenant, x.code });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ticket",
                schema: "common");

            migrationBuilder.DropTable(
                name: "ticket_status",
                schema: "common");
        }
    }
}
