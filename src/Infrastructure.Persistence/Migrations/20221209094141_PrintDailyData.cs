using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class PrintDailyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "print_daily_data",
                schema: "budgeting",
                columns: table => new
                {
                    user = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    user_code = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    site = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    site_name = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: false),
                    user_name = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: false),
                    previous_receipts = table.Column<double>(type: "double precision", nullable: false),
                    today_receipts = table.Column<double>(type: "double precision", nullable: false),
                    total_receipts = table.Column<double>(type: "double precision", nullable: false),
                    trans_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_print_daily_data", x => new { x.user, x.site, x.user_code });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "print_daily_data",
                schema: "budgeting");
        }
    }
}
