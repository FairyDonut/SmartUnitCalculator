using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartUnitCalculator.Migrations
{
    public partial class AddUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ResultValue",
                table: "History",
                type: "decimal(28,14)",
                precision: 28,
                scale: 14,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,19)",
                oldPrecision: 38,
                oldScale: 19);

            migrationBuilder.AlterColumn<decimal>(
                name: "BaseValue",
                table: "History",
                type: "decimal(28,14)",
                precision: 28,
                scale: 14,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,19)",
                oldPrecision: 38,
                oldScale: 19);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "History",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Multiplier",
                table: "Calculations",
                type: "decimal(28,14)",
                precision: 28,
                scale: 14,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,19)",
                oldPrecision: 38,
                oldScale: 19,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_UserId",
                table: "History",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_History_Users_UserId",
                table: "History",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Users_UserId",
                table: "History");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_History_UserId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "History");

            migrationBuilder.AlterColumn<decimal>(
                name: "ResultValue",
                table: "History",
                type: "decimal(38,19)",
                precision: 38,
                scale: 19,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,14)",
                oldPrecision: 28,
                oldScale: 14);

            migrationBuilder.AlterColumn<decimal>(
                name: "BaseValue",
                table: "History",
                type: "decimal(38,19)",
                precision: 38,
                scale: 19,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,14)",
                oldPrecision: 28,
                oldScale: 14);

            migrationBuilder.AlterColumn<decimal>(
                name: "Multiplier",
                table: "Calculations",
                type: "decimal(38,19)",
                precision: 38,
                scale: 19,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,14)",
                oldPrecision: 28,
                oldScale: 14,
                oldNullable: true);
        }
    }
}
