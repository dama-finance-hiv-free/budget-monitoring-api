using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class BudgetingEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "employer",
                schema: "common",
                table: "branch");

            migrationBuilder.DropColumn(
                name: "motto",
                schema: "common",
                table: "branch");

            migrationBuilder.EnsureSchema(
                name: "budgeting");

            migrationBuilder.AddColumn<string>(
                name: "project",
                schema: "common",
                table: "branch",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "activity_journal",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    batch = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    batch_line = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    batch_line_detail = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    project = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    runner = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    component = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    product = table.Column<string>(type: "text", nullable: true),
                    donor = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    branch = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    account = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: false),
                    user_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    trans_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(350)", unicode: false, maxLength: 350, nullable: false),
                    activity = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    site = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    cost_category = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    intervention = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    approach = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    objective = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    budget_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    sense = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    account_line = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: false),
                    voucher = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: true),
                    activity_type = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    tran_code = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    region = table.Column<string>(type: "character varying(4)", unicode: false, maxLength: 4, nullable: false),
                    server_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_activity_journal", x => new { x.tenant, x.batch, x.batch_line, x.batch_line_detail, x.project });
                });

            migrationBuilder.CreateTable(
                name: "activity_journal_history",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    batch = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    batch_line = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    batch_line_detail = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    project = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    runner = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    component = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    product = table.Column<string>(type: "text", nullable: true),
                    donor = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    branch = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    account = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: false),
                    user_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    trans_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(350)", unicode: false, maxLength: 350, nullable: false),
                    activity = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    site = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    cost_category = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    intervention = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    approach = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    objective = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    budget_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    sense = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    account_line = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: false),
                    voucher = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: true),
                    activity_type = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    tran_code = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    region = table.Column<string>(type: "character varying(4)", unicode: false, maxLength: 4, nullable: false),
                    server_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_activity_journal_history", x => new { x.tenant, x.batch, x.batch_line, x.batch_line_detail, x.project });
                });

            migrationBuilder.CreateTable(
                name: "activity_plan",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    project = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    component = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: false),
                    intervention = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    cost_category = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    approach = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    objective = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    budget_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    budget_balance = table.Column<double>(type: "double precision", nullable: false),
                    activity_type = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_activity_plan", x => new { x.tenant, x.code, x.cop_year, x.project });
                });

            migrationBuilder.CreateTable(
                name: "budget",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    project = table.Column<string>(type: "character varying(6)", unicode: false, maxLength: 6, nullable: false),
                    region = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    activity = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    component = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_budget", x => new { x.tenant, x.cop_year, x.project, x.activity, x.component, x.region });
                });

            migrationBuilder.CreateTable(
                name: "budget_history",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    project = table.Column<string>(type: "character varying(6)", unicode: false, maxLength: 6, nullable: false),
                    region = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    activity = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    component = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_budget_history", x => new { x.tenant, x.cop_year, x.project, x.activity, x.component, x.region });
                });

            migrationBuilder.CreateTable(
                name: "component",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    project = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    long_description = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_component", x => new { x.tenant, x.code, x.cop_year, x.project });
                });

            migrationBuilder.CreateTable(
                name: "cop_year",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cop_year", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "cop_year_budget_code",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    project = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    budget_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cop_year_budget_code", x => new { x.tenant, x.cop_year, x.project, x.budget_code });
                });

            migrationBuilder.CreateTable(
                name: "cop_year_cost_category",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    project = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    cost_category = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cop_year_cost_category", x => new { x.tenant, x.cop_year, x.project, x.cost_category });
                });

            migrationBuilder.CreateTable(
                name: "cop_year_intervention",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    project = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    intervention = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cop_year_intervention", x => new { x.tenant, x.cop_year, x.project, x.intervention });
                });

            migrationBuilder.CreateTable(
                name: "cost_category",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    project = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    description = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cost_category", x => new { x.tenant, x.code, x.cop_year, x.project });
                });

            migrationBuilder.CreateTable(
                name: "district",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    project = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    region = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    description = table.Column<string>(type: "character varying(75)", unicode: false, maxLength: 75, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_district", x => new { x.tenant, x.cop_year, x.code, x.project });
                });

            migrationBuilder.CreateTable(
                name: "intervention",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    project = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: false),
                    budget_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    percentage = table.Column<double>(type: "double precision", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_intervention", x => new { x.tenant, x.cop_year, x.code, x.project });
                });

            migrationBuilder.CreateTable(
                name: "milestone",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    runner = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: false),
                    project = table.Column<string>(type: "character varying(4)", unicode: false, maxLength: 4, nullable: false),
                    activity = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: false),
                    site = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: false),
                    region = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    budget_note = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    target = table.Column<double>(type: "double precision", nullable: false),
                    achievement = table.Column<double>(type: "double precision", nullable: false),
                    budget = table.Column<double>(type: "double precision", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_milestone", x => new { x.tenant, x.project, x.runner, x.activity, x.site });
                });

            migrationBuilder.CreateTable(
                name: "project",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(6)", unicode: false, maxLength: 6, nullable: false),
                    description = table.Column<string>(type: "character varying(75)", unicode: false, maxLength: 75, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_project", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "quarter",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    cop_year = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quarter", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "site",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    project = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: true),
                    description = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: false),
                    district = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: true),
                    site_type = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: true),
                    site_tier = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_site", x => new { x.tenant, x.code, x.cop_year });
                });

            migrationBuilder.CreateTable(
                name: "site_type",
                schema: "budgeting",
                columns: table => new
                {
                    code = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    description = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_site_type", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                schema: "budgeting",
                columns: table => new
                {
                    code = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    description = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_zone", x => x.code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activity_journal",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "activity_journal_history",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "activity_plan",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "budget",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "budget_history",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "component",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "cop_year",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "cop_year_budget_code",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "cop_year_cost_category",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "cop_year_intervention",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "cost_category",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "district",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "intervention",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "milestone",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "project",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "quarter",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "site",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "site_type",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "Zone",
                schema: "budgeting");

            migrationBuilder.DropColumn(
                name: "project",
                schema: "common",
                table: "branch");

            migrationBuilder.AddColumn<string>(
                name: "employer",
                schema: "common",
                table: "branch",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "motto",
                schema: "common",
                table: "branch",
                type: "character varying(150)",
                unicode: false,
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
