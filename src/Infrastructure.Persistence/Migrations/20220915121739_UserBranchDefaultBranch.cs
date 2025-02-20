using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class UserBranchDefaultBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_on",
                schema: "common",
                table: "user_branch");

            migrationBuilder.AddColumn<string>(
                name: "is_default",
                schema: "common",
                table: "user_branch",
                type: "character varying(2)",
                unicode: false,
                maxLength: 2,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "project",
                schema: "budgeting",
                table: "activity_journal_history",
                type: "character varying(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2)",
                oldUnicode: false,
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "project",
                schema: "budgeting",
                table: "activity_journal",
                type: "character varying(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2)",
                oldUnicode: false,
                oldMaxLength: 2);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "region",
                schema: "budgeting");

            migrationBuilder.DropColumn(
                name: "is_default",
                schema: "common",
                table: "user_branch");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_on",
                schema: "common",
                table: "user_branch",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "project",
                schema: "budgeting",
                table: "activity_journal_history",
                type: "character varying(2)",
                unicode: false,
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldUnicode: false,
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "project",
                schema: "budgeting",
                table: "activity_journal",
                type: "character varying(2)",
                unicode: false,
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldUnicode: false,
                oldMaxLength: 10);
        }
    }
}
