using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class TrimActivityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "approach",
                schema: "budgeting",
                table: "activity_history");

            migrationBuilder.DropColumn(
                name: "donor",
                schema: "budgeting",
                table: "activity_history");

            migrationBuilder.DropColumn(
                name: "objective",
                schema: "budgeting",
                table: "activity_history");

            migrationBuilder.DropColumn(
                name: "product",
                schema: "budgeting",
                table: "activity_history");

            migrationBuilder.DropColumn(
                name: "voucher",
                schema: "budgeting",
                table: "activity_history");

            migrationBuilder.DropColumn(
                name: "approach",
                schema: "budgeting",
                table: "activity");

            migrationBuilder.DropColumn(
                name: "donor",
                schema: "budgeting",
                table: "activity");

            migrationBuilder.DropColumn(
                name: "objective",
                schema: "budgeting",
                table: "activity");

            migrationBuilder.DropColumn(
                name: "product",
                schema: "budgeting",
                table: "activity");

            migrationBuilder.DropColumn(
                name: "voucher",
                schema: "budgeting",
                table: "activity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "approach",
                schema: "budgeting",
                table: "activity_history",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "donor",
                schema: "budgeting",
                table: "activity_history",
                type: "character varying(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "objective",
                schema: "budgeting",
                table: "activity_history",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "product",
                schema: "budgeting",
                table: "activity_history",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "voucher",
                schema: "budgeting",
                table: "activity_history",
                type: "character varying(15)",
                unicode: false,
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "approach",
                schema: "budgeting",
                table: "activity",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "donor",
                schema: "budgeting",
                table: "activity",
                type: "character varying(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "objective",
                schema: "budgeting",
                table: "activity",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "product",
                schema: "budgeting",
                table: "activity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "voucher",
                schema: "budgeting",
                table: "activity",
                type: "character varying(15)",
                unicode: false,
                maxLength: 15,
                nullable: true);
        }
    }
}
