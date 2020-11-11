﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SplitwiseApp.DomainModels.Models;

namespace SplitwiseApp.DomainModels.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SplitwiseApp.DomainModels.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<float?>("Balance")
                        .HasColumnType("real");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SplitwiseApp.DomainModels.Models.Expenses", b =>
                {
                    b.Property<int>("expenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SplitBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("creatorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("groupId")
                        .HasColumnType("int");

                    b.HasKey("expenseId");

                    b.HasIndex("creatorId");

                    b.HasIndex("groupId");

                    b.ToTable("expenses");
                });

            modelBuilder.Entity("SplitwiseApp.DomainModels.Models.Friends", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Balance")
                        .HasColumnType("real");

                    b.Property<string>("creatorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("friendId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("creatorId");

                    b.HasIndex("friendId");

                    b.ToTable("friends");
                });

            modelBuilder.Entity("SplitwiseApp.DomainModels.Models.GroupMembers", b =>
                {
                    b.Property<int>("memberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float?>("Balance")
                        .HasColumnType("real");

                    b.Property<int>("groupId")
                        .HasColumnType("int");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("memberId");

                    b.HasIndex("groupId");

                    b.HasIndex("userId");

                    b.ToTable("groupMember");
                });

            modelBuilder.Entity("SplitwiseApp.DomainModels.Models.Groups", b =>
                {
                    b.Property<int>("groupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("creatorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("groupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("groupType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("groupId");

                    b.HasIndex("creatorId");

                    b.ToTable("group");
                });

            modelBuilder.Entity("SplitwiseApp.DomainModels.Models.Payees_Expenses", b =>
                {
                    b.Property<int>("pId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Share")
                        .HasColumnType("real");

                    b.Property<int>("expenseId")
                        .HasColumnType("int");

                    b.Property<string>("payerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("receiverId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("pId");

                    b.HasIndex("expenseId");

                    b.HasIndex("payerId");

                    b.HasIndex("receiverId");

                    b.ToTable("payees_Expenses");
                });

            modelBuilder.Entity("SplitwiseApp.DomainModels.Models.Payers_Expenses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Share")
                        .HasColumnType("real");

                    b.Property<int>("expenseId")
                        .HasColumnType("int");

                    b.Property<float>("paidAmount")
                        .HasColumnType("real");

                    b.Property<string>("payerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("expenseId");

                    b.HasIndex("payerId");

                    b.ToTable("payers_Expenses");
                });

            modelBuilder.Entity("SplitwiseApp.DomainModels.Models.Settlement", b =>
                {
                    b.Property<int>("settlemntId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int?>("expenseId")
                        .HasColumnType("int");

                    b.Property<int?>("groupId")
                        .HasColumnType("int");

                    b.Property<string>("payerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("receiverId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("settlemntId");

                    b.HasIndex("expenseId");

                    b.HasIndex("groupId");

                    b.HasIndex("payerId");

                    b.HasIndex("receiverId");

                    b.ToTable("settlement");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SplitwiseApp.DomainModels.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SplitwiseApp.DomainModels.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SplitwiseApp.DomainModels.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SplitwiseApp.DomainModels.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SplitwiseApp.DomainModels.Models.Expenses", b =>
                {
                    b.HasOne("SplitwiseApp.DomainModels.Models.ApplicationUser", "users")
                        .WithMany()
                        .HasForeignKey("creatorId");

                    b.HasOne("SplitwiseApp.DomainModels.Models.Groups", "groups")
                        .WithMany()
                        .HasForeignKey("groupId");
                });

            modelBuilder.Entity("SplitwiseApp.DomainModels.Models.Friends", b =>
                {
                    b.HasOne("SplitwiseApp.DomainModels.Models.ApplicationUser", "creator")
                        .WithMany()
                        .HasForeignKey("creatorId");

                    b.HasOne("SplitwiseApp.DomainModels.Models.ApplicationUser", "users")
                        .WithMany()
                        .HasForeignKey("friendId");
                });

            modelBuilder.Entity("SplitwiseApp.DomainModels.Models.GroupMembers", b =>
                {
                    b.HasOne("SplitwiseApp.DomainModels.Models.Groups", "groups")
                        .WithMany()
                        .HasForeignKey("groupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SplitwiseApp.DomainModels.Models.ApplicationUser", "users")
                        .WithMany()
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("SplitwiseApp.DomainModels.Models.Groups", b =>
                {
                    b.HasOne("SplitwiseApp.DomainModels.Models.ApplicationUser", "creator")
                        .WithMany()
                        .HasForeignKey("creatorId");
                });

            modelBuilder.Entity("SplitwiseApp.DomainModels.Models.Payees_Expenses", b =>
                {
                    b.HasOne("SplitwiseApp.DomainModels.Models.Expenses", "expenses")
                        .WithMany()
                        .HasForeignKey("expenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SplitwiseApp.DomainModels.Models.ApplicationUser", "payer")
                        .WithMany()
                        .HasForeignKey("payerId");

                    b.HasOne("SplitwiseApp.DomainModels.Models.ApplicationUser", "receiever")
                        .WithMany()
                        .HasForeignKey("receiverId");
                });

            modelBuilder.Entity("SplitwiseApp.DomainModels.Models.Payers_Expenses", b =>
                {
                    b.HasOne("SplitwiseApp.DomainModels.Models.Expenses", "expenses")
                        .WithMany()
                        .HasForeignKey("expenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SplitwiseApp.DomainModels.Models.ApplicationUser", "payer")
                        .WithMany()
                        .HasForeignKey("payerId");
                });

            modelBuilder.Entity("SplitwiseApp.DomainModels.Models.Settlement", b =>
                {
                    b.HasOne("SplitwiseApp.DomainModels.Models.Expenses", "expenses")
                        .WithMany()
                        .HasForeignKey("expenseId");

                    b.HasOne("SplitwiseApp.DomainModels.Models.Groups", "groups")
                        .WithMany()
                        .HasForeignKey("groupId");

                    b.HasOne("SplitwiseApp.DomainModels.Models.ApplicationUser", "payer")
                        .WithMany()
                        .HasForeignKey("payerId");

                    b.HasOne("SplitwiseApp.DomainModels.Models.ApplicationUser", "receiver")
                        .WithMany()
                        .HasForeignKey("receiverId");
                });
#pragma warning restore 612, 618
        }
    }
}
