using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class RunnerProjectData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE budgeting.runner SET project = '01';
UPDATE budgeting.runner_history SET project = '01';");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
