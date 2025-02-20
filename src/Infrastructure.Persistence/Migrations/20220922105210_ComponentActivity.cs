﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class ComponentActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "component_activity",
                schema: "budgeting",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    cop_year = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    component = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    activity = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_component_activity", x => new { x.tenant, x.cop_year, x.component, x.activity });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "component_activity",
                schema: "budgeting");
        }
    }
}
