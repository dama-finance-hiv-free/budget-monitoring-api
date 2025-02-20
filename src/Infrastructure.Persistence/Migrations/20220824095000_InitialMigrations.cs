using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "common");

            migrationBuilder.EnsureSchema(
                name: "client");

            migrationBuilder.CreateTable(
                name: "branch",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(75)", unicode: false, maxLength: 75, nullable: false),
                    branch_name = table.Column<string>(type: "character varying(75)", unicode: false, maxLength: 75, nullable: false),
                    branch_short_name = table.Column<string>(type: "character varying(35)", unicode: false, maxLength: 35, nullable: false),
                    station_code = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    address = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    telephone = table.Column<string>(type: "character varying(35)", unicode: false, maxLength: 35, nullable: false),
                    region = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    motto = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: false),
                    head_office = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    employer = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    branch_type = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    branch_town = table.Column<string>(type: "character varying(35)", unicode: false, maxLength: 35, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_branch", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "branch_station",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    branch = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    station = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_branch_station", x => new { x.tenant, x.branch, x.station });
                });

            migrationBuilder.CreateTable(
                name: "client",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    branch = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    name_of_child = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true),
                    gender = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: true),
                    age = table.Column<int>(type: "integer", unicode: false, maxLength: 10, nullable: false),
                    runner = table.Column<string>(type: "character varying(12)", unicode: false, maxLength: 12, nullable: true),
                    name_of_mother = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true),
                    marital_status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: true),
                    phone_number = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: true),
                    number_of_children = table.Column<int>(type: "integer", nullable: false),
                    address = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    residency_status = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    education_level = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    current_activity = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    disability_screening_q1 = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    disability_screening_q2 = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    disability_screening_q3 = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    disability_screening_q4 = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    disability_screening_q5 = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    disability_screening_q6 = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    has_birth_certificate = table.Column<string>(type: "text", nullable: true),
                    ha_disability_type = table.Column<string>(type: "text", nullable: true),
                    ha_medical_condition = table.Column<string>(type: "text", nullable: true),
                    pregnancy_lactating = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    comment = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: true),
                    medication_available = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    sub_division = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: true),
                    health_area = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: true),
                    community = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: true),
                    community_volunteer = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client", x => new { x.tenant, x.code, x.branch });
                });

            migrationBuilder.CreateTable(
                name: "current_activity",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_current_activity", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "date_generation",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    branch = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    trans_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    trans_month = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    trans_year = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    trans_day = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: false),
                    prev_day = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    week_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    week_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    month_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    month_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_trans_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_date_generation", x => new { x.tenant, x.branch });
                });

            migrationBuilder.CreateTable(
                name: "date_generation_history",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    branch = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    trans_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    trans_month = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    trans_year = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    trans_day = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: false),
                    prev_day = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    week_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    week_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    month_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    month_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_trans_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_date_generation_history", x => new { x.tenant, x.branch, x.trans_date });
                });

            migrationBuilder.CreateTable(
                name: "dialog_message",
                schema: "common",
                columns: table => new
                {
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    lid = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    description = table.Column<string>(type: "character varying(125)", unicode: false, maxLength: 125, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dialog_message", x => new { x.code, x.lid });
                });

            migrationBuilder.CreateTable(
                name: "disability_type",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_disability_type", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "education_level",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_education_level", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "employer",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(75)", unicode: false, maxLength: 75, nullable: false),
                    address = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    town = table.Column<string>(type: "character varying(35)", unicode: false, maxLength: 35, nullable: false),
                    telephone = table.Column<string>(type: "character varying(35)", unicode: false, maxLength: 35, nullable: false),
                    region = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employer", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "marital_status",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_marital_status", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "medical_condition",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medical_condition", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "month_name",
                schema: "common",
                columns: table => new
                {
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    lid = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    description = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_month_name", x => new { x.code, x.lid });
                });

            migrationBuilder.CreateTable(
                name: "pregnancy_lactation",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pregnancy_lactation", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "privilege",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    men_code = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    usr_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    app = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_privilege", x => new { x.tenant, x.men_code });
                });

            migrationBuilder.CreateTable(
                name: "residency_status",
                schema: "client",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_residency_status", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "role",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "role_menu",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    menu_code = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: false),
                    role_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    app = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_menu", x => new { x.tenant, x.menu_code, x.role_code });
                });

            migrationBuilder.CreateTable(
                name: "server_status",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    branch = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    trans_year = table.Column<string>(type: "character varying(4)", unicode: false, maxLength: 4, nullable: false),
                    sys_trans = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    day_status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    cash_trans = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    back_office_only = table.Column<bool>(type: "boolean", nullable: false),
                    trans_ref = table.Column<int>(type: "integer", nullable: false),
                    year_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    year_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_server_status", x => new { x.tenant, x.branch, x.trans_year });
                });

            migrationBuilder.CreateTable(
                name: "server_status_history",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    branch = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    trans_year = table.Column<string>(type: "character varying(4)", unicode: false, maxLength: 4, nullable: false),
                    trans_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    year_status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    year_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    year_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_server_status_history", x => new { x.tenant, x.branch, x.trans_year });
                });

            migrationBuilder.CreateTable(
                name: "system_menu",
                schema: "common",
                columns: table => new
                {
                    code = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: false),
                    lid = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    app = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    description = table.Column<string>(type: "character varying(75)", unicode: false, maxLength: 75, nullable: false),
                    parent = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_system_menu", x => new { x.code, x.lid });
                });

            migrationBuilder.CreateTable(
                name: "tenant",
                schema: "common",
                columns: table => new
                {
                    code = table.Column<string>(type: "character varying(6)", unicode: false, maxLength: 6, nullable: false),
                    description = table.Column<string>(type: "character varying(75)", unicode: false, maxLength: 75, nullable: false),
                    telephone = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: false),
                    fax = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: false),
                    address = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    post_box = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: false),
                    city = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: false),
                    e_mail = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    website = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenant", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "town",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    description = table.Column<string>(type: "character varying(75)", unicode: false, maxLength: 75, nullable: false),
                    region = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_town", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    usr_name = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    connected = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    computer = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    log_time = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: false),
                    device_serial = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    usr_hash = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: true),
                    photo_url = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => new { x.tenant, x.code });
                });

            migrationBuilder.CreateTable(
                name: "user_branch",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    usr_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    branch_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_branch", x => new { x.tenant, x.usr_code, x.branch_code });
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                schema: "common",
                columns: table => new
                {
                    tenant = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    role_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    usr_code = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    status = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_role", x => new { x.tenant, x.role_code, x.usr_code });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "branch",
                schema: "common");

            migrationBuilder.DropTable(
                name: "branch_station",
                schema: "common");

            migrationBuilder.DropTable(
                name: "client",
                schema: "client");

            migrationBuilder.DropTable(
                name: "current_activity",
                schema: "client");

            migrationBuilder.DropTable(
                name: "date_generation",
                schema: "common");

            migrationBuilder.DropTable(
                name: "date_generation_history",
                schema: "common");

            migrationBuilder.DropTable(
                name: "dialog_message",
                schema: "common");

            migrationBuilder.DropTable(
                name: "disability_type",
                schema: "client");

            migrationBuilder.DropTable(
                name: "education_level",
                schema: "client");

            migrationBuilder.DropTable(
                name: "employer",
                schema: "common");

            migrationBuilder.DropTable(
                name: "marital_status",
                schema: "client");

            migrationBuilder.DropTable(
                name: "medical_condition",
                schema: "client");

            migrationBuilder.DropTable(
                name: "month_name",
                schema: "common");

            migrationBuilder.DropTable(
                name: "pregnancy_lactation",
                schema: "client");

            migrationBuilder.DropTable(
                name: "privilege",
                schema: "common");

            migrationBuilder.DropTable(
                name: "residency_status",
                schema: "client");

            migrationBuilder.DropTable(
                name: "role",
                schema: "common");

            migrationBuilder.DropTable(
                name: "role_menu",
                schema: "common");

            migrationBuilder.DropTable(
                name: "server_status",
                schema: "common");

            migrationBuilder.DropTable(
                name: "server_status_history",
                schema: "common");

            migrationBuilder.DropTable(
                name: "system_menu",
                schema: "common");

            migrationBuilder.DropTable(
                name: "tenant",
                schema: "common");

            migrationBuilder.DropTable(
                name: "town",
                schema: "common");

            migrationBuilder.DropTable(
                name: "user",
                schema: "common");

            migrationBuilder.DropTable(
                name: "user_branch",
                schema: "common");

            migrationBuilder.DropTable(
                name: "user_role",
                schema: "common");
        }
    }
}
