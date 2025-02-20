﻿// <auto-generated />
using System;
using Dama.Fin.Infrastructure.Persistence;
using Immunization.Campaign.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(MonitoringContext))]
    [Migration("20220909103439_DropClientSchema")]
    partial class DropClientSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Dama.Monitoring.Domain.Entity.Common.Branch", b =>
                {
                    b.Property<string>("Tenant")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("tenant");

                    b.Property<string>("Code")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("code");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("address");

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("character varying(75)")
                        .HasColumnName("branch_name");

                    b.Property<string>("BranchShortName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .IsUnicode(false)
                        .HasColumnType("character varying(35)")
                        .HasColumnName("branch_short_name");

                    b.Property<string>("BranchTown")
                        .IsRequired()
                        .HasMaxLength(35)
                        .IsUnicode(false)
                        .HasColumnType("character varying(35)")
                        .HasColumnName("branch_town");

                    b.Property<string>("BranchType")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("branch_type");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("character varying(75)")
                        .HasColumnName("description");

                    b.Property<string>("Employer")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("employer");

                    b.Property<string>("HeadOffice")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("head_office");

                    b.Property<string>("Motto")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("motto");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("region");

                    b.Property<string>("StationCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("station_code");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(35)
                        .IsUnicode(false)
                        .HasColumnType("character varying(35)")
                        .HasColumnName("telephone");

                    b.HasKey("Tenant", "Code")
                        .HasName("pk_branch");

                    b.ToTable("branch", "common");
                });

            modelBuilder.Entity("Dama.Monitoring.Domain.Entity.Common.BranchStation", b =>
                {
                    b.Property<string>("Tenant")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("tenant");

                    b.Property<string>("Branch")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("branch");

                    b.Property<string>("Station")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("station");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("status");

                    b.HasKey("Tenant", "Branch", "Station")
                        .HasName("pk_branch_station");

                    b.ToTable("branch_station", "common");
                });

            modelBuilder.Entity("Dama.Monitoring.Domain.Entity.Common.DateGeneration", b =>
                {
                    b.Property<string>("Tenant")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("tenant");

                    b.Property<string>("Branch")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("branch");

                    b.Property<DateTime>("LastTransDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_trans_date");

                    b.Property<DateTime>("MonthEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("month_end");

                    b.Property<DateTime>("MonthStart")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("month_start");

                    b.Property<DateTime>("PrevDay")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("prev_day");

                    b.Property<DateTime>("TransDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("trans_date");

                    b.Property<string>("TransDay")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("character varying(3)")
                        .HasColumnName("trans_day");

                    b.Property<string>("TransMonth")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("trans_month");

                    b.Property<string>("TransYear")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("trans_year");

                    b.Property<DateTime>("WeekEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("week_end");

                    b.Property<DateTime>("WeekStart")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("week_start");

                    b.HasKey("Tenant", "Branch")
                        .HasName("pk_date_generation");

                    b.ToTable("date_generation", "common");
                });

            modelBuilder.Entity("Dama.Monitoring.Domain.Entity.Common.DateGenerationHistory", b =>
                {
                    b.Property<string>("Tenant")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("tenant");

                    b.Property<string>("Branch")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("branch");

                    b.Property<DateTime>("TransDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("trans_date");

                    b.Property<DateTime>("LastTransDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_trans_date");

                    b.Property<DateTime>("MonthEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("month_end");

                    b.Property<DateTime>("MonthStart")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("month_start");

                    b.Property<DateTime>("PrevDay")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("prev_day");

                    b.Property<string>("TransDay")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("character varying(3)")
                        .HasColumnName("trans_day");

                    b.Property<string>("TransMonth")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("trans_month");

                    b.Property<string>("TransYear")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("trans_year");

                    b.Property<DateTime>("WeekEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("week_end");

                    b.Property<DateTime>("WeekStart")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("week_start");

                    b.HasKey("Tenant", "Branch", "TransDate")
                        .HasName("pk_date_generation_history");

                    b.ToTable("date_generation_history", "common");
                });

            modelBuilder.Entity("Dama.Monitoring.Domain.Entity.Common.DialogMessage", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("code");

                    b.Property<string>("Lid")
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("lid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(125)
                        .IsUnicode(false)
                        .HasColumnType("character varying(125)")
                        .HasColumnName("description");

                    b.HasKey("Code", "Lid")
                        .HasName("pk_dialog_message");

                    b.ToTable("dialog_message", "common");
                });

            modelBuilder.Entity("Dama.Monitoring.Domain.Entity.Common.Employer", b =>
                {
                    b.Property<string>("Tenant")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("tenant");

                    b.Property<string>("Code")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("code");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("address");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("character varying(75)")
                        .HasColumnName("description");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("region");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("status");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(35)
                        .IsUnicode(false)
                        .HasColumnType("character varying(35)")
                        .HasColumnName("telephone");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(35)
                        .IsUnicode(false)
                        .HasColumnType("character varying(35)")
                        .HasColumnName("town");

                    b.HasKey("Tenant", "Code")
                        .HasName("pk_employer");

                    b.ToTable("employer", "common");
                });

            modelBuilder.Entity("Dama.Monitoring.Domain.Entity.Common.MonthName", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("code");

                    b.Property<string>("Lid")
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("lid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("description");

                    b.HasKey("Code", "Lid")
                        .HasName("pk_month_name");

                    b.ToTable("month_name", "common");
                });

            modelBuilder.Entity("Dama.Monitoring.Domain.Entity.Common.Privilege", b =>
                {
                    b.Property<string>("Tenant")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("tenant");

                    b.Property<string>("MenCode")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("men_code");

                    b.Property<string>("App")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("app");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("status");

                    b.Property<string>("UsrCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("usr_code");

                    b.HasKey("Tenant", "MenCode")
                        .HasName("pk_privilege");

                    b.ToTable("privilege", "common");
                });

            modelBuilder.Entity("Dama.Monitoring.Domain.Entity.Common.Role", b =>
                {
                    b.Property<string>("Tenant")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("tenant");

                    b.Property<string>("Code")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("code");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("description");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("status");

                    b.HasKey("Tenant", "Code")
                        .HasName("pk_role");

                    b.ToTable("role", "common");
                });

            modelBuilder.Entity("Dama.Monitoring.Domain.Entity.Common.RoleMenu", b =>
                {
                    b.Property<string>("Tenant")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("tenant");

                    b.Property<string>("MenuCode")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("menu_code");

                    b.Property<string>("RoleCode")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("role_code");

                    b.Property<string>("App")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("app");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("status");

                    b.HasKey("Tenant", "MenuCode", "RoleCode")
                        .HasName("pk_role_menu");

                    b.ToTable("role_menu", "common");
                });

            modelBuilder.Entity("Dama.Monitoring.Domain.Entity.Common.ServerStatus", b =>
                {
                    b.Property<string>("Tenant")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("tenant");

                    b.Property<string>("Branch")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("branch");

                    b.Property<string>("TransYear")
                        .HasMaxLength(4)
                        .IsUnicode(false)
                        .HasColumnType("character varying(4)")
                        .HasColumnName("trans_year");

                    b.Property<bool>("BackOfficeOnly")
                        .HasColumnType("boolean")
                        .HasColumnName("back_office_only");

                    b.Property<string>("CashTrans")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("cash_trans");

                    b.Property<string>("DayStatus")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("day_status");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("status");

                    b.Property<string>("SysTrans")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("sys_trans");

                    b.Property<int>("TransRef")
                        .HasColumnType("integer")
                        .HasColumnName("trans_ref");

                    b.Property<DateTime?>("YearEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("year_end");

                    b.Property<DateTime?>("YearStart")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("year_start");

                    b.HasKey("Tenant", "Branch", "TransYear")
                        .HasName("pk_server_status");

                    b.ToTable("server_status", "common");
                });

            modelBuilder.Entity("Dama.Monitoring.Domain.Entity.Common.ServerStatusHistory", b =>
                {
                    b.Property<string>("Tenant")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("tenant");

                    b.Property<string>("Branch")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("branch");

                    b.Property<string>("TransYear")
                        .HasMaxLength(4)
                        .IsUnicode(false)
                        .HasColumnType("character varying(4)")
                        .HasColumnName("trans_year");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("status");

                    b.Property<DateTime?>("TransDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("trans_date");

                    b.Property<DateTime?>("YearEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("year_end");

                    b.Property<DateTime?>("YearStart")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("year_start");

                    b.Property<string>("YearStatus")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("year_status");

                    b.HasKey("Tenant", "Branch", "TransYear")
                        .HasName("pk_server_status_history");

                    b.ToTable("server_status_history", "common");
                });

            modelBuilder.Entity("Dama.Monitoring.Domain.Entity.Common.SystemMenu", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("code");

                    b.Property<string>("Lid")
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("lid");

                    b.Property<string>("App")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("app");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("character varying(75)")
                        .HasColumnName("description");

                    b.Property<string>("Parent")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("parent");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("status");

                    b.HasKey("Code", "Lid")
                        .HasName("pk_system_menu");

                    b.ToTable("system_menu", "common");
                });

            modelBuilder.Entity("Dama.Monitoring.Domain.Entity.Common.Tenant", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("character varying(6)")
                        .HasColumnName("code");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("city");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("character varying(75)")
                        .HasColumnName("description");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("e_mail");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("fax");

                    b.Property<string>("PostBox")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("post_box");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("telephone");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("website");

                    b.HasKey("Code")
                        .HasName("pk_tenant");

                    b.ToTable("tenant", "common");
                });

            modelBuilder.Entity("Dama.Monitoring.Domain.Entity.Common.Town", b =>
                {
                    b.Property<string>("Tenant")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("tenant");

                    b.Property<string>("Code")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("character varying(75)")
                        .HasColumnName("description");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("region");

                    b.HasKey("Tenant", "Code")
                        .HasName("pk_town");

                    b.ToTable("town", "common");
                });

            modelBuilder.Entity("Dama.Monitoring.Domain.Entity.Common.User", b =>
                {
                    b.Property<string>("Tenant")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("tenant");

                    b.Property<string>("Code")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("code");

                    b.Property<string>("Computer")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("computer");

                    b.Property<string>("Connected")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("connected");

                    b.Property<string>("DeviceSerial")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("device_serial");

                    b.Property<string>("LogTime")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("log_time");

                    b.Property<string>("PhotoUrl")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("photo_url");

                    b.Property<string>("UsrHash")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("usr_hash");

                    b.Property<string>("UsrName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("usr_name");

                    b.HasKey("Tenant", "Code")
                        .HasName("pk_user");

                    b.ToTable("user", "common");
                });

            modelBuilder.Entity("Dama.Monitoring.Domain.Entity.Common.UserBranch", b =>
                {
                    b.Property<string>("Tenant")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("tenant");

                    b.Property<string>("UsrCode")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("usr_code");

                    b.Property<string>("BranchCode")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("branch_code");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.HasKey("Tenant", "UsrCode", "BranchCode")
                        .HasName("pk_user_branch");

                    b.ToTable("user_branch", "common");
                });

            modelBuilder.Entity("Dama.Monitoring.Domain.Entity.Common.UserRole", b =>
                {
                    b.Property<string>("Tenant")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("tenant");

                    b.Property<string>("RoleCode")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("role_code");

                    b.Property<string>("UsrCode")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("usr_code");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("status");

                    b.HasKey("Tenant", "RoleCode", "UsrCode")
                        .HasName("pk_user_role");

                    b.ToTable("user_role", "common");
                });
#pragma warning restore 612, 618
        }
    }
}
