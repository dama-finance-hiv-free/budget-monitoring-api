using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class RstActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "activity",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    batch = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    batch_line = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    project = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    runner = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    component = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    branch = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    user_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    trans_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(350)", unicode: false, maxLength: 350, nullable: false),
                    activity = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    site = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    cost_category = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    intervention = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    budget_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    strategy = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    activity_type = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    tran_code = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    region = table.Column<string>(type: "character varying(4)", unicode: false, maxLength: 4, nullable: false),
                    server_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                    runner = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    component = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    branch = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    user_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    trans_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(350)", unicode: false, maxLength: 350, nullable: false),
                    activity = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    site = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    cost_category = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    intervention = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    budget_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    strategy = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    activity_type = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    tran_code = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    region = table.Column<string>(type: "character varying(4)", unicode: false, maxLength: 4, nullable: false),
                    server_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_activity_history", x => new { x.tenant, x.batch, x.batch_line, x.project });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activity",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "activity_history",
                schema: "budgeting");
        }
    }
}
