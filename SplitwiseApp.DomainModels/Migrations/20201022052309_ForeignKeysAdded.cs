using Microsoft.EntityFrameworkCore.Migrations;

namespace SplitwiseApp.DomainModels.Migrations
{
    public partial class ForeignKeysAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenses_group_groupId",
                table: "expenses");

            migrationBuilder.AlterColumn<int>(
                name: "groupId",
                table: "settlement",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Expenses",
                table: "settlement",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "payerId",
                table: "settlement",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "receiverId",
                table: "settlement",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "expenseId",
                table: "payers_Expenses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "payerId",
                table: "payers_Expenses",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "expenseId",
                table: "payees_Expenses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "payerId",
                table: "payees_Expenses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "receiverId",
                table: "payees_Expenses",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "groupId",
                table: "groupMember",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "groupMember",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "creatorId",
                table: "group",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "creatorId",
                table: "friends",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "friends",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "groupId",
                table: "expenses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "creatorId",
                table: "expenses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_settlement_Expenses",
                table: "settlement",
                column: "Expenses");

            migrationBuilder.CreateIndex(
                name: "IX_settlement_groupId",
                table: "settlement",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_settlement_payerId",
                table: "settlement",
                column: "payerId");

            migrationBuilder.CreateIndex(
                name: "IX_settlement_receiverId",
                table: "settlement",
                column: "receiverId");

            migrationBuilder.CreateIndex(
                name: "IX_payers_Expenses_expenseId",
                table: "payers_Expenses",
                column: "expenseId");

            migrationBuilder.CreateIndex(
                name: "IX_payers_Expenses_payerId",
                table: "payers_Expenses",
                column: "payerId");

            migrationBuilder.CreateIndex(
                name: "IX_payees_Expenses_expenseId",
                table: "payees_Expenses",
                column: "expenseId");

            migrationBuilder.CreateIndex(
                name: "IX_payees_Expenses_payerId",
                table: "payees_Expenses",
                column: "payerId");

            migrationBuilder.CreateIndex(
                name: "IX_payees_Expenses_receiverId",
                table: "payees_Expenses",
                column: "receiverId");

            migrationBuilder.CreateIndex(
                name: "IX_groupMember_groupId",
                table: "groupMember",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_groupMember_userId",
                table: "groupMember",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_group_creatorId",
                table: "group",
                column: "creatorId");

            migrationBuilder.CreateIndex(
                name: "IX_friends_creatorId",
                table: "friends",
                column: "creatorId");

            migrationBuilder.CreateIndex(
                name: "IX_friends_userId",
                table: "friends",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_creatorId",
                table: "expenses",
                column: "creatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_AspNetUsers_creatorId",
                table: "expenses",
                column: "creatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_group_groupId",
                table: "expenses",
                column: "groupId",
                principalTable: "group",
                principalColumn: "groupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_friends_AspNetUsers_creatorId",
                table: "friends",
                column: "creatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_friends_AspNetUsers_userId",
                table: "friends",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_group_AspNetUsers_creatorId",
                table: "group",
                column: "creatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_groupMember_group_groupId",
                table: "groupMember",
                column: "groupId",
                principalTable: "group",
                principalColumn: "groupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_groupMember_AspNetUsers_userId",
                table: "groupMember",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_payees_Expenses_expenses_expenseId",
                table: "payees_Expenses",
                column: "expenseId",
                principalTable: "expenses",
                principalColumn: "expenseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_payees_Expenses_AspNetUsers_payerId",
                table: "payees_Expenses",
                column: "payerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_payees_Expenses_AspNetUsers_receiverId",
                table: "payees_Expenses",
                column: "receiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_payers_Expenses_expenses_expenseId",
                table: "payers_Expenses",
                column: "expenseId",
                principalTable: "expenses",
                principalColumn: "expenseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_payers_Expenses_AspNetUsers_payerId",
                table: "payers_Expenses",
                column: "payerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_settlement_expenses_Expenses",
                table: "settlement",
                column: "Expenses",
                principalTable: "expenses",
                principalColumn: "expenseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_settlement_group_groupId",
                table: "settlement",
                column: "groupId",
                principalTable: "group",
                principalColumn: "groupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_settlement_AspNetUsers_payerId",
                table: "settlement",
                column: "payerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_settlement_AspNetUsers_receiverId",
                table: "settlement",
                column: "receiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenses_AspNetUsers_creatorId",
                table: "expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_expenses_group_groupId",
                table: "expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_friends_AspNetUsers_creatorId",
                table: "friends");

            migrationBuilder.DropForeignKey(
                name: "FK_friends_AspNetUsers_userId",
                table: "friends");

            migrationBuilder.DropForeignKey(
                name: "FK_group_AspNetUsers_creatorId",
                table: "group");

            migrationBuilder.DropForeignKey(
                name: "FK_groupMember_group_groupId",
                table: "groupMember");

            migrationBuilder.DropForeignKey(
                name: "FK_groupMember_AspNetUsers_userId",
                table: "groupMember");

            migrationBuilder.DropForeignKey(
                name: "FK_payees_Expenses_expenses_expenseId",
                table: "payees_Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_payees_Expenses_AspNetUsers_payerId",
                table: "payees_Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_payees_Expenses_AspNetUsers_receiverId",
                table: "payees_Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_payers_Expenses_expenses_expenseId",
                table: "payers_Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_payers_Expenses_AspNetUsers_payerId",
                table: "payers_Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_settlement_expenses_Expenses",
                table: "settlement");

            migrationBuilder.DropForeignKey(
                name: "FK_settlement_group_groupId",
                table: "settlement");

            migrationBuilder.DropForeignKey(
                name: "FK_settlement_AspNetUsers_payerId",
                table: "settlement");

            migrationBuilder.DropForeignKey(
                name: "FK_settlement_AspNetUsers_receiverId",
                table: "settlement");

            migrationBuilder.DropIndex(
                name: "IX_settlement_Expenses",
                table: "settlement");

            migrationBuilder.DropIndex(
                name: "IX_settlement_groupId",
                table: "settlement");

            migrationBuilder.DropIndex(
                name: "IX_settlement_payerId",
                table: "settlement");

            migrationBuilder.DropIndex(
                name: "IX_settlement_receiverId",
                table: "settlement");

            migrationBuilder.DropIndex(
                name: "IX_payers_Expenses_expenseId",
                table: "payers_Expenses");

            migrationBuilder.DropIndex(
                name: "IX_payers_Expenses_payerId",
                table: "payers_Expenses");

            migrationBuilder.DropIndex(
                name: "IX_payees_Expenses_expenseId",
                table: "payees_Expenses");

            migrationBuilder.DropIndex(
                name: "IX_payees_Expenses_payerId",
                table: "payees_Expenses");

            migrationBuilder.DropIndex(
                name: "IX_payees_Expenses_receiverId",
                table: "payees_Expenses");

            migrationBuilder.DropIndex(
                name: "IX_groupMember_groupId",
                table: "groupMember");

            migrationBuilder.DropIndex(
                name: "IX_groupMember_userId",
                table: "groupMember");

            migrationBuilder.DropIndex(
                name: "IX_group_creatorId",
                table: "group");

            migrationBuilder.DropIndex(
                name: "IX_friends_creatorId",
                table: "friends");

            migrationBuilder.DropIndex(
                name: "IX_friends_userId",
                table: "friends");

            migrationBuilder.DropIndex(
                name: "IX_expenses_creatorId",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "Expenses",
                table: "settlement");

            migrationBuilder.DropColumn(
                name: "payerId",
                table: "settlement");

            migrationBuilder.DropColumn(
                name: "receiverId",
                table: "settlement");

            migrationBuilder.DropColumn(
                name: "payerId",
                table: "payers_Expenses");

            migrationBuilder.DropColumn(
                name: "payerId",
                table: "payees_Expenses");

            migrationBuilder.DropColumn(
                name: "receiverId",
                table: "payees_Expenses");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "groupMember");

            migrationBuilder.DropColumn(
                name: "creatorId",
                table: "group");

            migrationBuilder.DropColumn(
                name: "creatorId",
                table: "friends");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "friends");

            migrationBuilder.DropColumn(
                name: "creatorId",
                table: "expenses");

            migrationBuilder.AlterColumn<int>(
                name: "groupId",
                table: "settlement",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "expenseId",
                table: "payers_Expenses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "expenseId",
                table: "payees_Expenses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "groupId",
                table: "groupMember",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "groupId",
                table: "expenses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_group_groupId",
                table: "expenses",
                column: "groupId",
                principalTable: "group",
                principalColumn: "groupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
