using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immunization.Campaign.Infrastructure.Persistence.Migrations
{
    public partial class PrimaryKeySetClientConfigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_client_vaccination_at_ten_weeks",
                schema: "client",
                table: "client_vaccination_at_ten_weeks");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client_vaccination_at_six_weeks",
                schema: "client",
                table: "client_vaccination_at_six_weeks");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client_vaccination_at_six_to_eleven_months",
                schema: "client",
                table: "client_vaccination_at_six_to_eleven_months");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client_vaccination_at_nine_months",
                schema: "client",
                table: "client_vaccination_at_nine_months");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client_vaccination_at_fourteen_weeks",
                schema: "client",
                table: "client_vaccination_at_fourteen_weeks");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client_vaccination_at_birth",
                schema: "client",
                table: "client_vaccination_at_birth");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client_medical_condition",
                schema: "client",
                table: "client_medical_condition");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client_ha_medical_condition",
                schema: "client",
                table: "client_ha_medical_condition");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client_ha_disability_type",
                schema: "client",
                table: "client_ha_disability_type");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client_disability_type",
                schema: "client",
                table: "client_disability_type");

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_ten_weeks",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_ten_weeks",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_six_weeks",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_six_weeks",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_six_to_eleven_months",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_six_to_eleven_months",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_nine_months",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_nine_months",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_fourteen_weeks",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_fourteen_weeks",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_birth",
                type: "character varying(40)",
                unicode: false,
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldUnicode: false,
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_birth",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_medical_condition",
                type: "character varying(40)",
                unicode: false,
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldUnicode: false,
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_medical_condition",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_ha_medical_condition",
                type: "character varying(40)",
                unicode: false,
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldUnicode: false,
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_ha_medical_condition",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_ha_disability_type",
                type: "character varying(40)",
                unicode: false,
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldUnicode: false,
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_ha_disability_type",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_disability_type",
                type: "character varying(40)",
                unicode: false,
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldUnicode: false,
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_disability_type",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_vaccination_at_ten_weeks",
                schema: "client",
                table: "client_vaccination_at_ten_weeks",
                columns: new[] { "tenant", "code", "branch", "client" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_vaccination_at_six_weeks",
                schema: "client",
                table: "client_vaccination_at_six_weeks",
                columns: new[] { "tenant", "code", "branch", "client" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_vaccination_at_six_to_eleven_months",
                schema: "client",
                table: "client_vaccination_at_six_to_eleven_months",
                columns: new[] { "tenant", "code", "branch", "client" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_vaccination_at_nine_months",
                schema: "client",
                table: "client_vaccination_at_nine_months",
                columns: new[] { "tenant", "code", "branch", "client" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_vaccination_at_fourteen_weeks",
                schema: "client",
                table: "client_vaccination_at_fourteen_weeks",
                columns: new[] { "tenant", "code", "branch", "client" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_vaccination_at_birth",
                schema: "client",
                table: "client_vaccination_at_birth",
                columns: new[] { "tenant", "code", "branch", "client" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_medical_condition",
                schema: "client",
                table: "client_medical_condition",
                columns: new[] { "tenant", "code", "branch", "client" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_ha_medical_condition",
                schema: "client",
                table: "client_ha_medical_condition",
                columns: new[] { "tenant", "code", "branch", "client" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_ha_disability_type",
                schema: "client",
                table: "client_ha_disability_type",
                columns: new[] { "tenant", "code", "branch", "client" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_disability_type",
                schema: "client",
                table: "client_disability_type",
                columns: new[] { "tenant", "code", "branch", "client" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_client_vaccination_at_ten_weeks",
                schema: "client",
                table: "client_vaccination_at_ten_weeks");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client_vaccination_at_six_weeks",
                schema: "client",
                table: "client_vaccination_at_six_weeks");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client_vaccination_at_six_to_eleven_months",
                schema: "client",
                table: "client_vaccination_at_six_to_eleven_months");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client_vaccination_at_nine_months",
                schema: "client",
                table: "client_vaccination_at_nine_months");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client_vaccination_at_fourteen_weeks",
                schema: "client",
                table: "client_vaccination_at_fourteen_weeks");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client_vaccination_at_birth",
                schema: "client",
                table: "client_vaccination_at_birth");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client_medical_condition",
                schema: "client",
                table: "client_medical_condition");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client_ha_medical_condition",
                schema: "client",
                table: "client_ha_medical_condition");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client_ha_disability_type",
                schema: "client",
                table: "client_ha_disability_type");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client_disability_type",
                schema: "client",
                table: "client_disability_type");

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_ten_weeks",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_ten_weeks",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_six_weeks",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_six_weeks",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_six_to_eleven_months",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_six_to_eleven_months",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_nine_months",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_nine_months",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_fourteen_weeks",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_fourteen_weeks",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_vaccination_at_birth",
                type: "character varying(40)",
                unicode: false,
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldUnicode: false,
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_vaccination_at_birth",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_medical_condition",
                type: "character varying(40)",
                unicode: false,
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldUnicode: false,
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_medical_condition",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_ha_medical_condition",
                type: "character varying(40)",
                unicode: false,
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldUnicode: false,
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_ha_medical_condition",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_ha_disability_type",
                type: "character varying(40)",
                unicode: false,
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldUnicode: false,
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_ha_disability_type",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "client",
                schema: "client",
                table: "client_disability_type",
                type: "character varying(40)",
                unicode: false,
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldUnicode: false,
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "branch",
                schema: "client",
                table: "client_disability_type",
                type: "character varying(5)",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldUnicode: false,
                oldMaxLength: 5);

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_vaccination_at_ten_weeks",
                schema: "client",
                table: "client_vaccination_at_ten_weeks",
                columns: new[] { "tenant", "code" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_vaccination_at_six_weeks",
                schema: "client",
                table: "client_vaccination_at_six_weeks",
                columns: new[] { "tenant", "code" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_vaccination_at_six_to_eleven_months",
                schema: "client",
                table: "client_vaccination_at_six_to_eleven_months",
                columns: new[] { "tenant", "code" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_vaccination_at_nine_months",
                schema: "client",
                table: "client_vaccination_at_nine_months",
                columns: new[] { "tenant", "code" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_vaccination_at_fourteen_weeks",
                schema: "client",
                table: "client_vaccination_at_fourteen_weeks",
                columns: new[] { "tenant", "code" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_vaccination_at_birth",
                schema: "client",
                table: "client_vaccination_at_birth",
                columns: new[] { "tenant", "code" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_medical_condition",
                schema: "client",
                table: "client_medical_condition",
                columns: new[] { "tenant", "code" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_ha_medical_condition",
                schema: "client",
                table: "client_ha_medical_condition",
                columns: new[] { "tenant", "code" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_ha_disability_type",
                schema: "client",
                table: "client_ha_disability_type",
                columns: new[] { "tenant", "code" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_client_disability_type",
                schema: "client",
                table: "client_disability_type",
                columns: new[] { "tenant", "code" });
        }
    }
}
