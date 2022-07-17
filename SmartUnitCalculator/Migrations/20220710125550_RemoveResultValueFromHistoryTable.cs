using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartUnitCalculator.Migrations
{
    public partial class RemoveResultValueFromHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResultValue",
                table: "History");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ResultValue",
                table: "History",
                type: "decimal(38,38)",
                precision: 38,
                scale: 38,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
