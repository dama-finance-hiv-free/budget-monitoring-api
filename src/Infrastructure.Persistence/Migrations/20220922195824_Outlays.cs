using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class Outlays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "annual_target",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    outlay = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    project = table.Column<string>(type: "character varying(6)", unicode: false, maxLength: 6, nullable: false),
                    component = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    region = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    target = table.Column<double>(type: "double precision", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_annual_target", x => new { x.tenant, x.outlay, x.cop_year, x.project, x.component, x.region });
                });

            migrationBuilder.CreateTable(
                name: "cop_year_outlay",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    project = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    outlay = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cop_year_outlay", x => new { x.tenant, x.cop_year, x.project, x.outlay });
                });

            migrationBuilder.CreateTable(
                name: "outlay",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    budget_code = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: true),
                    indicator = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: false),
                    type = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_outlay", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "target",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    outlay = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    project = table.Column<string>(type: "character varying(6)", unicode: false, maxLength: 6, nullable: false),
                    component = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    region = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    target = table.Column<double>(type: "double precision", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_target", x => new { x.tenant, x.outlay, x.cop_year, x.project, x.component, x.region });
                });

            migrationBuilder.CreateTable(
                name: "target_history",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    outlay = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    project = table.Column<string>(type: "character varying(6)", unicode: false, maxLength: 6, nullable: false),
                    component = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    region = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    target = table.Column<double>(type: "double precision", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_target_history", x => new { x.tenant, x.outlay, x.cop_year, x.project, x.component, x.region });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "annual_target",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "cop_year_outlay",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "outlay",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "target",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "target_history",
                schema: "budgeting");
        }
    }
}
