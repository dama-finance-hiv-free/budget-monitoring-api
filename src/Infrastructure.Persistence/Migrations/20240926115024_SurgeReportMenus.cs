using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class SurgeReportMenus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
-- system menus for surge reports
insert into common.system_menu (app, code, created_on, description, lid, parent, status) 
values ('01', 'L', '2022-01-02 01:00:00+01', 'Surge Reports', '01', '', '01'), 
('01', 'L00', '2022-01-02 01:00:00+01', 'Site Cost Category', '01', 'L', '01');

-- Assign menus to role  
insert into common.role_menu (app, created_on, menu_code, role_code, status, tenant) 
values 
('01', '2022-01-02 01:00:00+01', 'L', '00', '01', '101'), 
('01', '2022-01-02 01:00:00+01', 'L00', '00', '01', '101');
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
