using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartUnitCalculator.Migrations
{
    public partial class ChangeCalculationToUnitsInHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Calculations_CalculationId",
                table: "History");

            migrationBuilder.RenameColumn(
                name: "CalculationId",
                table: "History",
                newName: "ResultUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_History_CalculationId",
                table: "History",
                newName: "IX_History_ResultUnitId");

            migrationBuilder.AddColumn<int>(
                name: "BaseUnitId",
                table: "History",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ResultValue",
                table: "History",
                type: "decimal(38,19)",
                precision: 38,
                scale: 19,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_History_BaseUnitId",
                table: "History",
                column: "BaseUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Units_BaseUnitId",
                table: "History",
                column: "BaseUnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_History_Units_ResultUnitId",
                table: "History",
                column: "ResultUnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Units_BaseUnitId",
                table: "History");

            migrationBuilder.DropForeignKey(
                name: "FK_History_Units_ResultUnitId",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_History_BaseUnitId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "BaseUnitId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "ResultValue",
                table: "History");

            migrationBuilder.RenameColumn(
                name: "ResultUnitId",
                table: "History",
                newName: "CalculationId");

            migrationBuilder.RenameIndex(
                name: "IX_History_ResultUnitId",
                table: "History",
                newName: "IX_History_CalculationId");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Calculations_CalculationId",
                table: "History",
                column: "CalculationId",
                principalTable: "Calculations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
