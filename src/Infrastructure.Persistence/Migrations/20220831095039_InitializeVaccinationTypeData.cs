using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class InitializeVaccinationTypeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM client.vaccination_type;
INSERT INTO client.vaccination_type(
	tenant, code, description, created_on)
	VALUES ('101', '01', 'At Birth', '2022-03-21 01:00:00+01'),
    ('101', '02', '6 Weeks', '2022-03-21 01:00:00+01'),
    ('101', '03', '10 Weeks', '2022-03-21 01:00:00+01'),
    ('101', '04', '14 Weeks', '2022-03-21 01:00:00+01'),
    ('101', '05', '6 to 11 Months', '2022-03-21 01:00:00+01'),
    ('101', '06', '9 Months', '2022-03-21 01:00:00+01');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
