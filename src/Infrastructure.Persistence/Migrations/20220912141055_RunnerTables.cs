using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class RunnerTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "include_runner",
                schema: "budgeting",
                columns: table => new
                {
                    user = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    runner = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_include_runner", x => new { x.user, x.runner });
                });

            migrationBuilder.CreateTable(
                name: "region_runner_period",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    runner = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    region = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_region_runner_period", x => new { x.tenant, x.runner, x.region });
                });

            migrationBuilder.CreateTable(
                name: "runner",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    region = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    description = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    component = table.Column<string>(type: "character varying(4)", unicode: false, maxLength: 4, nullable: false),
                    month = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    week = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    component_week = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    year_week = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    milestone_projection = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_runner", x => new { x.tenant, x.cop_year, x.code, x.region });
                });

            migrationBuilder.CreateTable(
                name: "runner_component",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    runner = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    project = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    component = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_runner_component", x => new { x.tenant, x.runner, x.project, x.component });
                });

            migrationBuilder.CreateTable(
                name: "runner_component_history",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    runner = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    project = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    component = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_runner_component_history", x => new { x.tenant, x.runner, x.project, x.component });
                });

            migrationBuilder.CreateTable(
                name: "runner_history",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    region = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    description = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    component = table.Column<string>(type: "character varying(4)", unicode: false, maxLength: 4, nullable: false),
                    month = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    week = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    component_week = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    year_week = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    milestone_projection = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_runner_history", x => new { x.tenant, x.cop_year, x.code, x.region });
                });

            migrationBuilder.CreateTable(
                name: "runner_period",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(6)", unicode: false, maxLength: 6, nullable: false),
                    description = table.Column<string>(type: "character varying(75)", unicode: false, maxLength: 75, nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    component = table.Column<string>(type: "character varying(4)", unicode: false, maxLength: 4, nullable: false),
                    month = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    week = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    component_week = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    year_week = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    milestone_projection = table.Column<string>(type: "character varying(6)", unicode: false, maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_runner_period", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "runner_period_component",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    runner_period = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    project = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    component = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_runner_period_component", x => new { x.tenant, x.runner_period, x.project, x.component });
                });

            migrationBuilder.CreateTable(
                name: "runner_period_component_history",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    runner_period = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    project = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    component = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_runner_period_component_history", x => new { x.tenant, x.runner_period, x.project, x.component });
                });

            migrationBuilder.CreateTable(
                name: "runner_period_history",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(6)", unicode: false, maxLength: 6, nullable: false),
                    description = table.Column<string>(type: "character varying(75)", unicode: false, maxLength: 75, nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    component = table.Column<string>(type: "character varying(4)", unicode: false, maxLength: 4, nullable: false),
                    month = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    week = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    component_week = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    year_week = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    milestone_projection = table.Column<string>(type: "character varying(6)", unicode: false, maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_runner_period_history", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "runner_period_status",
                schema: "budgeting",
                columns: table => new
                {
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_runner_period_status", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "runner_status",
                schema: "budgeting",
                columns: table => new
                {
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_runner_status", x => x.code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "include_runner",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "region_runner_period",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "runner",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "runner_component",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "runner_component_history",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "runner_history",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "runner_period",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "runner_period_component",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "runner_period_component_history",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "runner_period_history",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "runner_period_status",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "runner_status",
                schema: "budgeting");
        }
    }
}
