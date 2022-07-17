using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartUnitCalculator.Migrations
{
    public partial class ChangeRequiredForCalculation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Calculations_CalculationId",
                table: "History");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Calculations_CalculationId",
                table: "History",
                column: "CalculationId",
                principalTable: "Calculations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Calculations_CalculationId",
                table: "History");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Calculations_CalculationId",
                table: "History",
                column: "CalculationId",
                principalTable: "Calculations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
