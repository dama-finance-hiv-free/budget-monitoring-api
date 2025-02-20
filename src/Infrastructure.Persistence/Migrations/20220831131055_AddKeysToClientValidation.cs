using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class AddKeysToClientValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_client_vaccination",
                schema: "client",
                table: "client_vaccination");

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_client_vaccination",
                schema: "client",
                table: "client_vaccination");

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldUnicode: false,
                oldMaxLength: 50);

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

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_vaccination",
                schema: "client",
                table: "client_vaccination",
                columns: new[] { "tenant", "code" });
        }
    }
}
