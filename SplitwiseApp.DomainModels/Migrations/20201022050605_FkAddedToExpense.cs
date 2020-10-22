using Microsoft.EntityFrameworkCore.Migrations;

namespace SplitwiseApp.DomainModels.Migrations
{
    public partial class FkAddedToExpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenses_group_groupsgroupId",
                table: "expenses");

            migrationBuilder.DropIndex(
                name: "IX_expenses_groupsgroupId",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "groupsgroupId",
                table: "expenses");

            migrationBuilder.AddColumn<int>(
                name: "Groups",
                table: "expenses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_expenses_Groups",
                table: "expenses",
                column: "Groups");

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_group_Groups",
                table: "expenses",
                column: "Groups",
                principalTable: "group",
                principalColumn: "groupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenses_group_Groups",
                table: "expenses");

            migrationBuilder.DropIndex(
                name: "IX_expenses_Groups",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "Groups",
                table: "expenses");

            migrationBuilder.AddColumn<int>(
                name: "groupsgroupId",
                table: "expenses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_expenses_groupsgroupId",
                table: "expenses",
                column: "groupsgroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_group_groupsgroupId",
                table: "expenses",
                column: "groupsgroupId",
                principalTable: "group",
                principalColumn: "groupId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
