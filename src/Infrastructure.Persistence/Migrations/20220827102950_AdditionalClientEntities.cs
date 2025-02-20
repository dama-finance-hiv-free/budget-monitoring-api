using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class AdditionalClientEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client_disability_type",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_disability_type", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "client_medical_condition",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_medical_condition", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "client_vaccination_at_birth",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_vaccination_at_birth", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "client_vaccination_at_fourteen_weeks",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_vaccination_at_fourteen_weeks", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "client_vaccination_at_nine_months",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_vaccination_at_nine_months", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "client_vaccination_at_six_to_eleven_months",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_vaccination_at_six_to_eleven_months", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "client_vaccination_at_six_weeks",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_vaccination_at_six_weeks", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "client_vaccination_at_ten_weeks",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_vaccination_at_ten_weeks", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "vaccination_at_birth",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vaccination_at_birth", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "vaccination_at_fourteen_weeks",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vaccination_at_fourteen_weeks", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "vaccination_at_nine_months",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vaccination_at_nine_months", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "vaccination_at_six_to_eleven_months",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vaccination_at_six_to_eleven_months", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "vaccination_at_six_weeks",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vaccination_at_six_weeks", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "vaccination_at_ten_weeks",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vaccination_at_ten_weeks", x => new { x.tenant, x.code });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client_disability_type",
                schema: "client");

            migrationBuilder.DropTable(
                name: "client_medical_condition",
                schema: "client");

            migrationBuilder.DropTable(
                name: "client_vaccination_at_birth",
                schema: "client");

            migrationBuilder.DropTable(
                name: "client_vaccination_at_fourteen_weeks",
                schema: "client");

            migrationBuilder.DropTable(
                name: "client_vaccination_at_nine_months",
                schema: "client");

            migrationBuilder.DropTable(
                name: "client_vaccination_at_six_to_eleven_months",
                schema: "client");

            migrationBuilder.DropTable(
                name: "client_vaccination_at_six_weeks",
                schema: "client");

            migrationBuilder.DropTable(
                name: "client_vaccination_at_ten_weeks",
                schema: "client");

            migrationBuilder.DropTable(
                name: "vaccination_at_birth",
                schema: "client");

            migrationBuilder.DropTable(
                name: "vaccination_at_fourteen_weeks",
                schema: "client");

            migrationBuilder.DropTable(
                name: "vaccination_at_nine_months",
                schema: "client");

            migrationBuilder.DropTable(
                name: "vaccination_at_six_to_eleven_months",
                schema: "client");

            migrationBuilder.DropTable(
                name: "vaccination_at_six_weeks",
                schema: "client");

            migrationBuilder.DropTable(
                name: "vaccination_at_ten_weeks",
                schema: "client");
        }
    }
}
