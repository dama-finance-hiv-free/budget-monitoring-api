using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class VaccinatiionSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM client.vaccination;
INSERT INTO client.vaccination(
	tenant, code, description, created_on, vaccination_type)
	VALUES ('101', '01', 'BCG', '2022-03-21 01:00:00+01', '01'),
    ('101', '02', 'OPV 0', '2022-03-21 01:00:00+01', '01'),
    ('101', '03', 'DTP-HepB-Hib 1', '2022-03-21 01:00:00+01', '02'),
    ('101', '04', 'OPV 1', '2022-03-21 01:00:00+01', '02'),
    ('101', '05', 'Pneumo 13–1 (PCV)', '2022-03-21 01:00:00+01', '02'),
    ('101', '06', 'ROTA 1', '2022-03-21 01:00:00+01', '02'),
    ('101', '07', 'DTP-HepB-Hib 2', '2022-03-21 01:00:00+01', '03'),
    ('101', '08', 'OPV 2', '2022-03-21 01:00:00+01', '03'),
    ('101', '09', 'Pneumo 13–2 (PCV)', '2022-03-21 01:00:00+01', '03'),
    ('101', '10', 'ROTA 2', '2022-03-21 01:00:00+01', '03'),
    ('101', '11', 'DTP-HepB-Hib 3', '2022-03-21 01:00:00+01', '04'),
    ('101', '12', 'OPV 3', '2022-03-21 01:00:00+01', '04'),
    ('101', '13', 'Pneumo 13–3 (PCV)', '2022-03-21 01:00:00+01', '04'),
    ('101', '14', 'ROTA 3', '2022-03-21 01:00:00+01', '04'),
    ('101', '15', 'Vit A', '2022-03-21 01:00:00+01', '05'),
    ('101', '16', 'MR', '2022-03-21 01:00:00+01', '06'),
    ('101', '17', 'YF', '2022-03-21 01:00:00+01', '06');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
