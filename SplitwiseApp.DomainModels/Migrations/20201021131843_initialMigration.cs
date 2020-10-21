using Microsoft.EntityFrameworkCore.Migrations;

namespace SplitwiseApp.DomainModels.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "expenses",
                columns: table => new
                {
                    expenseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    Currency = table.Column<string>(nullable: false),
                    SplitBy = table.Column<string>(nullable: false),
                    groupId = table.Column<int>(nullable: false),
                    creatorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenses", x => x.expenseId);
                });

            migrationBuilder.CreateTable(
                name: "friends",
                columns: table => new
                {
                    friendId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    friendName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Balance = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_friends", x => x.friendId);
                });

            migrationBuilder.CreateTable(
                name: "group",
                columns: table => new
                {
                    groupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groupName = table.Column<string>(nullable: false),
                    groupType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group", x => x.groupId);
                });

            migrationBuilder.CreateTable(
                name: "groupMember",
                columns: table => new
                {
                    memberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupMember", x => x.memberId);
                });

            migrationBuilder.CreateTable(
                name: "payees_Expenses",
                columns: table => new
                {
                    pId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Share = table.Column<float>(nullable: false),
                    expenseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payees_Expenses", x => x.pId);
                });

            migrationBuilder.CreateTable(
                name: "payers_Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paidAmount = table.Column<float>(nullable: false),
                    Share = table.Column<float>(nullable: false),
                    expenseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payers_Expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "settlement",
                columns: table => new
                {
                    settlemntId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<float>(nullable: false),
                    expenseId = table.Column<int>(nullable: false),
                    groupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settlement", x => x.settlemntId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "expenses");

            migrationBuilder.DropTable(
                name: "friends");

            migrationBuilder.DropTable(
                name: "group");

            migrationBuilder.DropTable(
                name: "groupMember");

            migrationBuilder.DropTable(
                name: "payees_Expenses");

            migrationBuilder.DropTable(
                name: "payers_Expenses");

            migrationBuilder.DropTable(
                name: "settlement");
        }
    }
}
