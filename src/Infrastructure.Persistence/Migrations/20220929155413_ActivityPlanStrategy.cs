using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class ActivityPlanStrategy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activity",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "activity_history",
                schema: "budgeting");

            migrationBuilder.DropColumn(
                name: "created_on",
                schema: "budgeting",
                table: "activity_plan");

            migrationBuilder.AddColumn<string>(
                name: "project",
                schema: "budgeting",
                table: "activity_plan",
                type: "character varying(2)",
                unicode: false,
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "strategy",
                schema: "budgeting",
                table: "activity_plan",
                type: "character varying(2)",
                unicode: false,
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "project",
                schema: "budgeting",
                table: "activity_plan");

            migrationBuilder.DropColumn(
                name: "strategy",
                schema: "budgeting",
                table: "activity_plan");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_on",
                schema: "budgeting",
                table: "activity_plan",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "activity",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    batch = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    batch_line = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    project = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    activity = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    activity_type = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    branch = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    budget_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    component = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    cost_category = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(350)", unicode: false, maxLength: 350, nullable: false),
                    intervention = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    region = table.Column<string>(type: "character varying(4)", unicode: false, maxLength: 4, nullable: false),
                    runner = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    server_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    site = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    tran_code = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    trans_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_activity", x => new { x.tenant, x.batch, x.batch_line, x.project });
                });

            migrationBuilder.CreateTable(
                name: "activity_history",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    batch = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    batch_line = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    project = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    activity = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    activity_type = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    branch = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    budget_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    component = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    cost_category = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(350)", unicode: false, maxLength: 350, nullable: false),
                    intervention = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    region = table.Column<string>(type: "character varying(4)", unicode: false, maxLength: 4, nullable: false),
                    runner = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    server_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    site = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    tran_code = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    trans_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_activity_history", x => new { x.tenant, x.batch, x.batch_line, x.project });
                });
        }
    }
}
