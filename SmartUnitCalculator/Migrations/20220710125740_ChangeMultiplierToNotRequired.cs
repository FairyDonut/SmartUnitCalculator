using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartUnitCalculator.Migrations
{
    public partial class ChangeMultiplierToNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Multiplier",
                table: "Calculations",
                type: "decimal(38,38)",
                precision: 38,
                scale: 38,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,38)",
                oldPrecision: 38,
                oldScale: 38);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Multiplier",
                table: "Calculations",
                type: "decimal(38,38)",
                precision: 38,
                scale: 38,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,38)",
                oldPrecision: 38,
                oldScale: 38,
                oldNullable: true);
        }
    }
}
