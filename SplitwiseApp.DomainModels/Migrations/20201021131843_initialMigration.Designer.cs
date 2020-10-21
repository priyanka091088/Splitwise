﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SplitwiseApp.DomainModels.Models;

namespace SplitwiseApp.DomainModels.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201021131843_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("groupId")
                        .HasColumnType("int");

                    b.HasKey("expenseId");

                    b.ToTable("expenses");
                });

            modelBuilder.Entity("SplitwiseApp.DomainModels.Models.Friends", b =>
                {
                    b.Property<int>("friendId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Balance")
                        .HasColumnType("real");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("friendName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("friendId");

                    b.ToTable("friends");
                });

            modelBuilder.Entity("SplitwiseApp.DomainModels.Models.GroupMembers", b =>
                {
                    b.Property<int>("memberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("groupId")
                        .HasColumnType("int");

                    b.HasKey("memberId");

                    b.ToTable("groupMember");
                });

            modelBuilder.Entity("SplitwiseApp.DomainModels.Models.Groups", b =>
                {
                    b.Property<int>("groupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("groupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("groupType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("groupId");

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

                    b.HasKey("pId");

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

                    b.HasKey("Id");

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

                    b.Property<int>("expenseId")
                        .HasColumnType("int");

                    b.Property<int>("groupId")
                        .HasColumnType("int");

                    b.HasKey("settlemntId");

                    b.ToTable("settlement");
                });
#pragma warning restore 612, 618
        }
    }
}
