using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class AddHAModelsHAMedicalConditionHADisabilityType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ha_disability_type",
                schema: "client",
                table: "client");

            migrationBuilder.DropColumn(
                name: "ha_medical_condition",
                schema: "client",
                table: "client");

            migrationBuilder.CreateTable(
                name: "client_ha_disability_type",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    client = table.Column<string>(type: "text", nullable: true),
                    branch = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_ha_disability_type", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "client_ha_medical_condition",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    client = table.Column<string>(type: "text", nullable: true),
                    branch = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_ha_medical_condition", x => new { x.tenant, x.code });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client_ha_disability_type",
                schema: "client");

            migrationBuilder.DropTable(
                name: "client_ha_medical_condition",
                schema: "client");

            migrationBuilder.AddColumn<string>(
                name: "ha_disability_type",
                schema: "client",
                table: "client",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ha_medical_condition",
                schema: "client",
                table: "client",
                type: "text",
                nullable: true);
        }
    }
}
