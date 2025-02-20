using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class DisabilityScreeningAnswerAndOtherEdits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                schema: "client",
                table: "client_vaccination_at_ten_weeks");

            migrationBuilder.DropColumn(
                name: "description",
                schema: "client",
                table: "client_vaccination_at_six_weeks");

            migrationBuilder.DropColumn(
                name: "description",
                schema: "client",
                table: "client_vaccination_at_six_to_eleven_months");

            migrationBuilder.DropColumn(
                name: "description",
                schema: "client",
                table: "client_vaccination_at_nine_months");

            migrationBuilder.DropColumn(
                name: "description",
                schema: "client",
                table: "client_vaccination_at_fourteen_weeks");

            migrationBuilder.DropColumn(
                name: "description",
                schema: "client",
                table: "client_vaccination_at_birth");

            migrationBuilder.DropColumn(
                name: "description",
                schema: "client",
                table: "client_medical_condition");

            migrationBuilder.DropColumn(
                name: "description",
                schema: "client",
                table: "client_disability_type");

            migrationBuilder.AddColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_ten_weeks",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_ten_weeks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_six_weeks",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_six_weeks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_six_to_eleven_months",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_six_to_eleven_months",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_nine_months",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_nine_months",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_fourteen_weeks",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_fourteen_weeks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_birth",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_birth",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_medical_condition",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "client",
                schema: "client",
                table: "client_medical_condition",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_disability_type",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "client",
                schema: "client",
                table: "client_disability_type",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "disability_screening_answer",
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
                    table.PrimaryKey("pk_disability_screening_answer", x => new { x.tenant, x.code });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "disability_screening_answer",
                schema: "client");

            migrationBuilder.DropColumn(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_ten_weeks");

            migrationBuilder.DropColumn(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_ten_weeks");

            migrationBuilder.DropColumn(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_six_weeks");

            migrationBuilder.DropColumn(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_six_weeks");

            migrationBuilder.DropColumn(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_six_to_eleven_months");

            migrationBuilder.DropColumn(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_six_to_eleven_months");

            migrationBuilder.DropColumn(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_nine_months");

            migrationBuilder.DropColumn(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_nine_months");

            migrationBuilder.DropColumn(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_fourteen_weeks");

            migrationBuilder.DropColumn(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_fourteen_weeks");

            migrationBuilder.DropColumn(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_birth");

            migrationBuilder.DropColumn(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_birth");

            migrationBuilder.DropColumn(
                name: "branch",
                schema: "client",
                table: "client_medical_condition");

            migrationBuilder.DropColumn(
                name: "client",
                schema: "client",
                table: "client_medical_condition");

            migrationBuilder.DropColumn(
                name: "branch",
                schema: "client",
                table: "client_disability_type");

            migrationBuilder.DropColumn(
                name: "client",
                schema: "client",
                table: "client_disability_type");

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "client",
                table: "client_vaccination_at_ten_weeks",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "client",
                table: "client_vaccination_at_six_weeks",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "client",
                table: "client_vaccination_at_six_to_eleven_months",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "client",
                table: "client_vaccination_at_nine_months",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "client",
                table: "client_vaccination_at_fourteen_weeks",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "client",
                table: "client_vaccination_at_birth",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "client",
                table: "client_medical_condition",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "client",
                table: "client_disability_type",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);
        }
    }
}
