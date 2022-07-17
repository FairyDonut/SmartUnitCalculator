using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartUnitCalculator.Migrations
{
    public partial class UpdatePrecisionOnMultiplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "BaseValue",
                table: "History",
                type: "decimal(38,19)",
                precision: 38,
                scale: 19,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,38)",
                oldPrecision: 38,
                oldScale: 38);

            migrationBuilder.AlterColumn<decimal>(
                name: "Multiplier",
                table: "Calculations",
                type: "decimal(38,19)",
                precision: 38,
                scale: 19,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,38)",
                oldPrecision: 38,
                oldScale: 38,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "BaseValue",
                table: "History",
                type: "decimal(38,38)",
                precision: 38,
                scale: 38,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,19)",
                oldPrecision: 38,
                oldScale: 19);

            migrationBuilder.AlterColumn<decimal>(
                name: "Multiplier",
                table: "Calculations",
                type: "decimal(38,38)",
                precision: 38,
                scale: 38,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,19)",
                oldPrecision: 38,
                oldScale: 19,
                oldNullable: true);
        }
    }
}
