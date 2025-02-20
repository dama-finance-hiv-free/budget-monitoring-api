using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class UserCoordination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activity_journal_history",
                schema: "budgeting");

            migrationBuilder.CreateTable(
                name: "activity_history",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    batch = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    batch_line = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    batch_line_detail = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    project = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
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
                    table.PrimaryKey("pk_activity_history", x => new { x.tenant, x.batch, x.batch_line, x.batch_line_detail, x.project });
                });

            migrationBuilder.CreateTable(
                name: "transaction_code",
                schema: "budgeting",
                columns: table => new
                {
                    code = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    description = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_transaction_code", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "user_coordination",
                schema: "budgeting",
                columns: table => new
                {
                    user = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    coordination = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_coordination", x => new { x.user, x.coordination });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activity_history",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "transaction_code",
                schema: "budgeting");

            migrationBuilder.DropTable(
                name: "user_coordination",
                schema: "budgeting");

            migrationBuilder.CreateTable(
                name: "activity_journal_history",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    batch = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    batch_line = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    batch_line_detail = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    project = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    account = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: false),
                    account_line = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: false),
                    activity = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    activity_type = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    approach = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    branch = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    budget_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    component = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    cost_category = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(350)", unicode: false, maxLength: 350, nullable: false),
                    donor = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    intervention = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    objective = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    product = table.Column<string>(type: "text", nullable: true),
                    region = table.Column<string>(type: "character varying(4)", unicode: false, maxLength: 4, nullable: false),
                    runner = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    sense = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    server_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    site = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    tran_code = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    trans_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    voucher = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_activity_journal_history", x => new { x.tenant, x.batch, x.batch_line, x.batch_line_detail, x.project });
                });
        }
    }
}
