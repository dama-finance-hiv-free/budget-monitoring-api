using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class InterventionData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM budgeting.intervention;

INSERT INTO budgeting.intervention(tenant, code, cop_year, description, budget_code, percentage, created_on)
	VALUES ('101', '01', '06', 'IM Program Management', '01', 0, '2025-01-01')
	      ,('101', '02', '06', 'Health Management Information Systems (HMIS)', '01', 0, '2025-01-01')
		  ,('101', '03', '06', 'HIV Clinical Services NSD Children', '05', 0, '2025-01-01')
		  ,('101', '04', '06', 'HIV Clinical Services NSD Non-Targeted Populations', '01', 0, '2025-01-01')
		  ,('101', '05', '06', 'HIV Clinical Services SD AGYW', '04', 0, '2025-01-01')
		  ,('101', '06', '06', 'HIV Clinical Services SD Children', '05', 0, '2025-01-01')
		  ,('101', '07', '06', 'HIV Clinical Services SD Key Populations', '01', 0, '2025-01-01')
		  ,('101', '08', '06', 'HIV Clinical Services SD Non-Targeted Populations', '01', 0, '2025-01-01')
		  ,('101', '09', '06', 'HIV Clinical Services SD Pregnant & Breastfeeding Women', '04', 0, '2025-01-01')
		  ,('101', '10', '06', 'HIV Laboratory Services SD Non-Targeted Populations', '07', 0, '2025-01-01')
		  ,('101', '11', '06', 'Facility-based testing SD Non-Targeted Populations', '02', 0, '2025-01-01')
		  ,('101', '12', '06', 'PrEP NSD Non-Targeted Populations', '10', 0, '2025-01-01')
		  ,('101', '13', '06', 'PrEP SD Key Populations', '10', 0, '2025-01-01')
		  ,('101', '14', '06', 'HIV/TB  SD Non-Targeted Populations', '09', 0, '2025-01-01')
		  ,('101', '15', '06', 'HIV/TB NSD Non-Targeted Populations', '09', 0, '2025-01-01')
		  ,('101', '16', '06', 'HIV/TB SD-CHILDREN', '09', 0, '2025-01-01')
		  ,('101', '17', '06', 'Community-based testing SD Non-Targeted Populations', '02', 0, '2025-01-01')
		  ,('101', '18', '06', 'Community-based testing (EID Reagents) SD-CHILDREN', '02', 0, '2025-01-01')
		  ,('101', '19', '06', 'HIV Clinical Services NSD Key Populations', '02', 0, '2025-01-01');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
