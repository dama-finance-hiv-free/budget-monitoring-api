using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class ActivityPlanDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "budgeting",
                table: "activity_plan",
                type: "character varying(350)",
                unicode: false,
                maxLength: 350,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldUnicode: false,
                oldMaxLength: 200);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "budgeting",
                table: "activity_plan",
                type: "character varying(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(350)",
                oldUnicode: false,
                oldMaxLength: 350);
        }
    }
}
