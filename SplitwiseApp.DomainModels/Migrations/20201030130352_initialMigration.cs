using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SplitwiseApp.DomainModels.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Balance = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "friends",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<float>(nullable: false),
                    creatorId = table.Column<string>(nullable: true),
                    friendId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_friends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_friends_AspNetUsers_creatorId",
                        column: x => x.creatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_friends_AspNetUsers_friendId",
                        column: x => x.friendId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "group",
                columns: table => new
                {
                    groupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groupName = table.Column<string>(nullable: false),
                    groupType = table.Column<string>(nullable: false),
                    creatorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group", x => x.groupId);
                    table.ForeignKey(
                        name: "FK_group_AspNetUsers_creatorId",
                        column: x => x.creatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    groupId = table.Column<int>(nullable: true),
                    creatorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenses", x => x.expenseId);
                    table.ForeignKey(
                        name: "FK_expenses_AspNetUsers_creatorId",
                        column: x => x.creatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_expenses_group_groupId",
                        column: x => x.groupId,
                        principalTable: "group",
                        principalColumn: "groupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "groupMember",
                columns: table => new
                {
                    memberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groupId = table.Column<int>(nullable: true),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupMember", x => x.memberId);
                    table.ForeignKey(
                        name: "FK_groupMember_group_groupId",
                        column: x => x.groupId,
                        principalTable: "group",
                        principalColumn: "groupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_groupMember_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "payees_Expenses",
                columns: table => new
                {
                    pId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Share = table.Column<float>(nullable: false),
                    expenseId = table.Column<int>(nullable: true),
                    payerId = table.Column<string>(nullable: true),
                    receiverId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payees_Expenses", x => x.pId);
                    table.ForeignKey(
                        name: "FK_payees_Expenses_expenses_expenseId",
                        column: x => x.expenseId,
                        principalTable: "expenses",
                        principalColumn: "expenseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_payees_Expenses_AspNetUsers_payerId",
                        column: x => x.payerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_payees_Expenses_AspNetUsers_receiverId",
                        column: x => x.receiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "payers_Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paidAmount = table.Column<float>(nullable: false),
                    Share = table.Column<float>(nullable: false),
                    expenseId = table.Column<int>(nullable: true),
                    payerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payers_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payers_Expenses_expenses_expenseId",
                        column: x => x.expenseId,
                        principalTable: "expenses",
                        principalColumn: "expenseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_payers_Expenses_AspNetUsers_payerId",
                        column: x => x.payerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "settlement",
                columns: table => new
                {
                    settlemntId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<float>(nullable: false),
                    expenseId = table.Column<int>(nullable: false),
                    groupId = table.Column<int>(nullable: true),
                    payerId = table.Column<string>(nullable: true),
                    receiverId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settlement", x => x.settlemntId);
                    table.ForeignKey(
                        name: "FK_settlement_expenses_expenseId",
                        column: x => x.expenseId,
                        principalTable: "expenses",
                        principalColumn: "expenseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_settlement_group_groupId",
                        column: x => x.groupId,
                        principalTable: "group",
                        principalColumn: "groupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_settlement_AspNetUsers_payerId",
                        column: x => x.payerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_settlement_AspNetUsers_receiverId",
                        column: x => x.receiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_creatorId",
                table: "expenses",
                column: "creatorId");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_groupId",
                table: "expenses",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_friends_creatorId",
                table: "friends",
                column: "creatorId");

            migrationBuilder.CreateIndex(
                name: "IX_friends_friendId",
                table: "friends",
                column: "friendId");

            migrationBuilder.CreateIndex(
                name: "IX_group_creatorId",
                table: "group",
                column: "creatorId");

            migrationBuilder.CreateIndex(
                name: "IX_groupMember_groupId",
                table: "groupMember",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_groupMember_userId",
                table: "groupMember",
                column: "userId");

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
                name: "IX_payers_Expenses_expenseId",
                table: "payers_Expenses",
                column: "expenseId");

            migrationBuilder.CreateIndex(
                name: "IX_payers_Expenses_payerId",
                table: "payers_Expenses",
                column: "payerId");

            migrationBuilder.CreateIndex(
                name: "IX_settlement_expenseId",
                table: "settlement",
                column: "expenseId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "friends");

            migrationBuilder.DropTable(
                name: "groupMember");

            migrationBuilder.DropTable(
                name: "payees_Expenses");

            migrationBuilder.DropTable(
                name: "payers_Expenses");

            migrationBuilder.DropTable(
                name: "settlement");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "expenses");

            migrationBuilder.DropTable(
                name: "group");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
