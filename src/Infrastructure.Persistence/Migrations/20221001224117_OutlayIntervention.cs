using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class OutlayIntervention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "outlay_intervention",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    project = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    outlay = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    intervention = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_outlay_intervention", x => new { x.tenant, x.cop_year, x.project, x.outlay, x.intervention });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "outlay_intervention",
                schema: "budgeting");
        }
    }
}
