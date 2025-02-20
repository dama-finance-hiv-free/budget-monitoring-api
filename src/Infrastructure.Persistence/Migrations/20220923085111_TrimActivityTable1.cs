using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class TrimActivityTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_activity_history",
                schema: "budgeting",
                table: "activity_history");

            migrationBuilder.DropPrimaryKey(
                name: "pk_activity",
                schema: "budgeting",
                table: "activity");

            migrationBuilder.DropColumn(
                name: "batch_line_detail",
                schema: "budgeting",
                table: "activity_history");

            migrationBuilder.DropColumn(
                name: "account",
                schema: "budgeting",
                table: "activity_history");

            migrationBuilder.DropColumn(
                name: "account_line",
                schema: "budgeting",
                table: "activity_history");

            migrationBuilder.DropColumn(
                name: "sense",
                schema: "budgeting",
                table: "activity_history");

            migrationBuilder.DropColumn(
                name: "batch_line_detail",
                schema: "budgeting",
                table: "activity");

            migrationBuilder.DropColumn(
                name: "account",
                schema: "budgeting",
                table: "activity");

            migrationBuilder.DropColumn(
                name: "account_line",
                schema: "budgeting",
                table: "activity");

            migrationBuilder.DropColumn(
                name: "sense",
                schema: "budgeting",
                table: "activity");

            migrationBuilder.AddPrimaryKey(
                name: "pk_activity_history",
                schema: "budgeting",
                table: "activity_history",
                columns: new[] { "tenant", "batch", "batch_line", "project" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_activity",
                schema: "budgeting",
                table: "activity",
                columns: new[] { "tenant", "batch", "batch_line", "project" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_activity_history",
                schema: "budgeting",
                table: "activity_history");

            migrationBuilder.DropPrimaryKey(
                name: "pk_activity",
                schema: "budgeting",
                table: "activity");

            migrationBuilder.AddColumn<string>(
                name: "batch_line_detail",
                schema: "budgeting",
                table: "activity_history",
                type: "character varying(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "account",
                schema: "budgeting",
                table: "activity_history",
                type: "character varying(25)",
                unicode: false,
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "account_line",
                schema: "budgeting",
                table: "activity_history",
                type: "character varying(3)",
                unicode: false,
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sense",
                schema: "budgeting",
                table: "activity_history",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "batch_line_detail",
                schema: "budgeting",
                table: "activity",
                type: "character varying(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "account",
                schema: "budgeting",
                table: "activity",
                type: "character varying(25)",
                unicode: false,
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "account_line",
                schema: "budgeting",
                table: "activity",
                type: "character varying(3)",
                unicode: false,
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sense",
                schema: "budgeting",
                table: "activity",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "pk_activity_history",
                schema: "budgeting",
                table: "activity_history",
                columns: new[] { "tenant", "batch", "batch_line", "batch_line_detail", "project" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_activity",
                schema: "budgeting",
                table: "activity",
                columns: new[] { "tenant", "batch", "batch_line", "batch_line_detail", "project" });
        }
    }
}
