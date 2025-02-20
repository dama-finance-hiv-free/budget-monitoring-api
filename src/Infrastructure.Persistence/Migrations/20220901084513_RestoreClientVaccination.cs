using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class RestoreClientVaccination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client_vaccination",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    reference = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    ref_line = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    client = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    branch = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: true),
                    vaccine = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: true),
                    vaccine_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_vaccination", x => new { x.tenant, x.reference, x.ref_line, x.client });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client_vaccination",
                schema: "client");
        }
    }
}
