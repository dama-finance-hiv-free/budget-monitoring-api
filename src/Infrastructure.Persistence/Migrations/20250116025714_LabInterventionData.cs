using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class LabInterventionData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM budgeting.intervention WHERE code IN ('20','21');
INSERT INTO budgeting.intervention(
	tenant, code, cop_year, description, budget_code, percentage, created_on)
	VALUES ('101', '20', '06', 'ASP LSS', '01', 0, '2025-01-01')
	      ,('101', '21', '06', 'ASP Policy', '01', 0, '2025-01-01');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
