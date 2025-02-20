using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class PediatricSurgeActivities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
delete from common.system_menu where app = '01' and code in ('J','J00');
insert into common.system_menu (app,code,created_on,description,lid,parent,status) values
('01','J','2022-01-02 01:00:00+01','Pediatric Surge Activities','01','','01'),
('01','J00','2022-01-02 01:00:00+01','Site Activities','01','J','01');

-- assign surge activity menus to role
delete from common.role_menu where app = '01' and role_code = '00' and menu_code in ('J','J00');
insert into common.role_menu (app,created_on,menu_code,role_code,status,tenant)values
('01','2022-01-02 01:00:00+01','J','00','01','101'),
('01','2022-01-02 01:00:00+01','J00','00','01','101');
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
