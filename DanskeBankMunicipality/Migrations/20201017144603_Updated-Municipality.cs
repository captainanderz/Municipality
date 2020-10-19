using Microsoft.EntityFrameworkCore.Migrations;

namespace DanskeBankMunicipality.Migrations
{
    public partial class UpdatedMunicipality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipalities",
                table: "Municipalities");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Municipalities");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Municipalities");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Municipalities",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Schedule",
                table: "Municipalities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TaxRate",
                table: "Municipalities",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipalities",
                table: "Municipalities",
                columns: new[] { "Name", "Schedule" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipalities",
                table: "Municipalities");

            migrationBuilder.DropColumn(
                name: "Schedule",
                table: "Municipalities");

            migrationBuilder.DropColumn(
                name: "TaxRate",
                table: "Municipalities");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Municipalities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Municipalities",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<double>(
                name: "Tax",
                table: "Municipalities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipalities",
                table: "Municipalities",
                column: "Id");
        }
    }
}
