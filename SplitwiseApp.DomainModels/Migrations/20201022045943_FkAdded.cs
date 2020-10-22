using Microsoft.EntityFrameworkCore.Migrations;

namespace SplitwiseApp.DomainModels.Migrations
{
    public partial class FkAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "creatorId",
                table: "expenses");

            migrationBuilder.AddColumn<int>(
                name: "groupsgroupId",
                table: "expenses",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "creatorId",
                table: "expenses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
