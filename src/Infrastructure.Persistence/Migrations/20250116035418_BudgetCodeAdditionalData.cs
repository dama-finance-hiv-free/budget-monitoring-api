using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class BudgetCodeAdditionalData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM budgeting.budget_code WHERE code IN ('09','10');
INSERT INTO budgeting.budget_code(tenant, code, description, created_on)
	VALUES ('101', '09', 'HIV/TB', '2025-01-01')
	      ,('101', '10', 'PrEP', '2025-01-01');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
