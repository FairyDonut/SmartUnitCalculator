using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartUnitCalculator.Migrations
{
    public partial class ChangeKeyForUnitTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitTypes",
                table: "UnitTypes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UnitTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UnitTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "Units",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitTypes",
                table: "UnitTypes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Units_TypeName",
                table: "Units",
                column: "TypeName");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_UnitTypes_TypeName",
                table: "Units",
                column: "TypeName",
                principalTable: "UnitTypes",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_UnitTypes_TypeName",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitTypes",
                table: "UnitTypes");

            migrationBuilder.DropIndex(
                name: "IX_Units_TypeName",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "Units");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UnitTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UnitTypes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitTypes",
                table: "UnitTypes",
                column: "Id");
        }
    }
}
