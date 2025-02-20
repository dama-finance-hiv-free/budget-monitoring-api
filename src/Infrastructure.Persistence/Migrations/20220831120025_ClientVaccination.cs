using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class ClientVaccination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                schema: "client",
                table: "client_vaccination",
                newName: "client");

            migrationBuilder.AddColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "branch",
                schema: "client",
                table: "client_vaccination");

            migrationBuilder.RenameColumn(
                name: "client",
                schema: "client",
                table: "client_vaccination",
                newName: "description");
        }
    }
}
