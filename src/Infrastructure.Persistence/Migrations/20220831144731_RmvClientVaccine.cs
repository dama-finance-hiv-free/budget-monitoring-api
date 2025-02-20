using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class RmvClientVaccine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_client_vaccination",
                schema: "client",
                table: "client_vaccination");

            migrationBuilder.RenameColumn(
                name: "code",
                schema: "client",
                table: "client_vaccination",
                newName: "ref_line");

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5);

            migrationBuilder.AddColumn<string>(
                name: "reference",
                schema: "client",
                table: "client_vaccination",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "vaccine",
                schema: "client",
                table: "client_vaccination",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "vaccine_date",
                schema: "client",
                table: "client_vaccination",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_vaccination",
                schema: "client",
                table: "client_vaccination",
                columns: new[] { "tenant", "reference", "ref_line", "client" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_client_vaccination",
                schema: "client",
                table: "client_vaccination");

            migrationBuilder.DropColumn(
                name: "reference",
                schema: "client",
                table: "client_vaccination");

            migrationBuilder.DropColumn(
                name: "vaccine",
                schema: "client",
                table: "client_vaccination");

            migrationBuilder.DropColumn(
                name: "vaccine_date",
                schema: "client",
                table: "client_vaccination");

            migrationBuilder.RenameColumn(
                name: "ref_line",
                schema: "client",
                table: "client_vaccination",
                newName: "code");

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_vaccination",
                schema: "client",
                table: "client_vaccination",
                columns: new[] { "tenant", "code", "branch", "client" });
        }
    }
}
