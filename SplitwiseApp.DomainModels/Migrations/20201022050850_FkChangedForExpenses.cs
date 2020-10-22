using Microsoft.EntityFrameworkCore.Migrations;

namespace SplitwiseApp.DomainModels.Migrations
{
    public partial class FkChangedForExpenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_expenses_groupId",
                table: "expenses",
                column: "groupId");

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_group_groupId",
                table: "expenses",
                column: "groupId",
                principalTable: "group",
                principalColumn: "groupId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenses_group_groupId",
                table: "expenses");

            migrationBuilder.DropIndex(
                name: "IX_expenses_groupId",
                table: "expenses");

            migrationBuilder.AddColumn<int>(
                name: "Groups",
                table: "expenses",
                type: "int",
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
    }
}
