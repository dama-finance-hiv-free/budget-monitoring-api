using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class RmvClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client",
                schema: "client");

            migrationBuilder.DropTable(
                name: "client_disability_type",
                schema: "client");

            migrationBuilder.DropTable(
                name: "client_ha_disability_type",
                schema: "client");

            migrationBuilder.DropTable(
                name: "client_ha_medical_condition",
                schema: "client");

            migrationBuilder.DropTable(
                name: "client_medical_condition",
                schema: "client");

            migrationBuilder.DropTable(
                name: "client_vaccination",
                schema: "client");

            migrationBuilder.DropTable(
                name: "current_activity",
                schema: "client");

            migrationBuilder.DropTable(
                name: "disability_screening_answer",
                schema: "client");

            migrationBuilder.DropTable(
                name: "disability_type",
                schema: "client");

            migrationBuilder.DropTable(
                name: "education_level",
                schema: "client");

            migrationBuilder.DropTable(
                name: "marital_status",
                schema: "client");

            migrationBuilder.DropTable(
                name: "medical_condition",
                schema: "client");

            migrationBuilder.DropTable(
                name: "pregnancy_lactation",
                schema: "client");

            migrationBuilder.DropTable(
                name: "residency_status",
                schema: "client");

            migrationBuilder.DropTable(
                name: "vaccination",
                schema: "client");

            migrationBuilder.DropTable(
                name: "vaccination_type",
                schema: "client");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "client");

            migrationBuilder.CreateTable(
                name: "client",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    branch = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    address = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    age = table.Column<int>(type: "integer", unicode: false, maxLength: 10, nullable: false),
                    comment = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: true),
                    community = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: true),
                    community_volunteer = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    current_activity = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    disability_screening_q1 = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    disability_screening_q2 = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    disability_screening_q3 = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    disability_screening_q4 = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    disability_screening_q5 = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    disability_screening_q6 = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    education_level = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    gender = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: true),
                    health_area = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: true),
                    marital_status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: true),
                    medication_available = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    name_of_child = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true),
                    name_of_mother = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true),
                    number_of_children = table.Column<int>(type: "integer", nullable: false),
                    phone_number = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: true),
                    pregnancy_lactating = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    pregnancy_lactation = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    residency_status = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    runner = table.Column<string>(type: "character varying(12)", unicode: false, maxLength: 12, nullable: true),
                    sub_division = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: true),
                    vaccination_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    has_birth_certificate = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client", x => new { x.tenant, x.code, x.branch });
                });

            migrationBuilder.CreateTable(
                name: "client_disability_type",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    branch = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    client = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_disability_type", x => new { x.tenant, x.code, x.branch, x.client });
                });

            migrationBuilder.CreateTable(
                name: "client_ha_disability_type",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    branch = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    client = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_ha_disability_type", x => new { x.tenant, x.code, x.branch, x.client });
                });

            migrationBuilder.CreateTable(
                name: "client_ha_medical_condition",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    branch = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    client = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_ha_medical_condition", x => new { x.tenant, x.code, x.branch, x.client });
                });

            migrationBuilder.CreateTable(
                name: "client_medical_condition",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    branch = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    client = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_medical_condition", x => new { x.tenant, x.code, x.branch, x.client });
                });

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
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    vaccine = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: true),
                    vaccine_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_vaccination", x => new { x.tenant, x.reference, x.ref_line, x.client });
                });

            migrationBuilder.CreateTable(
                name: "current_activity",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_current_activity", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "disability_screening_answer",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_disability_screening_answer", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "disability_type",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_disability_type", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "education_level",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_education_level", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "marital_status",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_marital_status", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "medical_condition",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medical_condition", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "pregnancy_lactation",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pregnancy_lactation", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "residency_status",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_residency_status", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "vaccination",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    vaccination_type = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vaccination", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "vaccination_type",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vaccination_type", x => new { x.tenant, x.code });
                });
        }
    }
}
