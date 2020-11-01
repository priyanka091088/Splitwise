using Microsoft.EntityFrameworkCore.Migrations;

namespace SplitwiseApp.DomainModels.Migrations
{
    public partial class notnullpropertyaddedtotables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_groupMember_group_groupId",
                table: "groupMember");

            migrationBuilder.DropForeignKey(
                name: "FK_payees_Expenses_expenses_expenseId",
                table: "payees_Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_payers_Expenses_expenses_expenseId",
                table: "payers_Expenses");

            migrationBuilder.AlterColumn<int>(
                name: "expenseId",
                table: "payers_Expenses",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "expenseId",
                table: "payees_Expenses",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "groupId",
                table: "groupMember",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Balance",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddForeignKey(
                name: "FK_groupMember_group_groupId",
                table: "groupMember",
                column: "groupId",
                principalTable: "group",
                principalColumn: "groupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_payees_Expenses_expenses_expenseId",
                table: "payees_Expenses",
                column: "expenseId",
                principalTable: "expenses",
                principalColumn: "expenseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_payers_Expenses_expenses_expenseId",
                table: "payers_Expenses",
                column: "expenseId",
                principalTable: "expenses",
                principalColumn: "expenseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_groupMember_group_groupId",
                table: "groupMember");

            migrationBuilder.DropForeignKey(
                name: "FK_payees_Expenses_expenses_expenseId",
                table: "payees_Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_payers_Expenses_expenses_expenseId",
                table: "payers_Expenses");

            migrationBuilder.AlterColumn<int>(
                name: "expenseId",
                table: "payers_Expenses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "expenseId",
                table: "payees_Expenses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "groupId",
                table: "groupMember",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<float>(
                name: "Balance",
                table: "AspNetUsers",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_groupMember_group_groupId",
                table: "groupMember",
                column: "groupId",
                principalTable: "group",
                principalColumn: "groupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_payees_Expenses_expenses_expenseId",
                table: "payees_Expenses",
                column: "expenseId",
                principalTable: "expenses",
                principalColumn: "expenseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_payers_Expenses_expenses_expenseId",
                table: "payers_Expenses",
                column: "expenseId",
                principalTable: "expenses",
                principalColumn: "expenseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
