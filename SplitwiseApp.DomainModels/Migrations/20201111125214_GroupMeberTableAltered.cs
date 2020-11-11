using Microsoft.EntityFrameworkCore.Migrations;

namespace SplitwiseApp.DomainModels.Migrations
{
    public partial class GroupMeberTableAltered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Balance",
                table: "groupMember",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "groupMember");
        }
    }
}
