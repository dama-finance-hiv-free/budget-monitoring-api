using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class AddedIndexToActivityHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_activity_history_trans_date",
                schema: "budgeting",
                table: "activity_history",
                column: "trans_date");

            migrationBuilder.CreateIndex(
                name: "ix_activity_trans_date",
                schema: "budgeting",
                table: "activity",
                column: "trans_date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_activity_history_trans_date",
                schema: "budgeting",
                table: "activity_history");

            migrationBuilder.DropIndex(
                name: "ix_activity_trans_date",
                schema: "budgeting",
                table: "activity");
        }
    }
}
