using Microsoft.EntityFrameworkCore.Migrations;

namespace SplitwiseApp.DomainModels.Migrations
{
    public partial class madeExpenseIdAnullValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_settlement_expenses_expenseId",
                table: "settlement");

            migrationBuilder.AlterColumn<int>(
                name: "expenseId",
                table: "settlement",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_settlement_expenses_expenseId",
                table: "settlement",
                column: "expenseId",
                principalTable: "expenses",
                principalColumn: "expenseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_settlement_expenses_expenseId",
                table: "settlement");

            migrationBuilder.AlterColumn<int>(
                name: "expenseId",
                table: "settlement",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_settlement_expenses_expenseId",
                table: "settlement",
                column: "expenseId",
                principalTable: "expenses",
                principalColumn: "expenseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
