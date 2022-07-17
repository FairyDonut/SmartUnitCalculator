﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartUnitCalculator.Database;

#nullable disable

namespace SmartUnitCalculator.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220717134259_UpdateUsersTable")]
    partial class UpdateUsersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SmartUnitCalculator.Database.Models.Calculation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BaseUnitId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Multiplier")
                        .HasPrecision(28, 14)
                        .HasColumnType("decimal(28,14)");

                    b.Property<int>("ResultUnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BaseUnitId");

                    b.HasIndex("ResultUnitId");

                    b.ToTable("Calculations");
                });

            modelBuilder.Entity("SmartUnitCalculator.Database.Models.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BaseUnitId")
                        .HasColumnType("int");

                    b.Property<decimal>("BaseValue")
                        .HasPrecision(28, 14)
                        .HasColumnType("decimal(28,14)");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ResultUnitId")
                        .HasColumnType("int");

                    b.Property<decimal>("ResultValue")
                        .HasPrecision(28, 14)
                        .HasColumnType("decimal(28,14)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BaseUnitId");

                    b.HasIndex("ResultUnitId");

                    b.HasIndex("UserId");

                    b.ToTable("History");
                });

            modelBuilder.Entity("SmartUnitCalculator.Database.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TypeName");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("SmartUnitCalculator.Database.Models.UnitType", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.HasIndex("Priority")
                        .IsUnique();

                    b.ToTable("UnitTypes");
                });

            modelBuilder.Entity("SmartUnitCalculator.Database.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SmartUnitCalculator.Database.Models.Calculation", b =>
                {
                    b.HasOne("SmartUnitCalculator.Database.Models.Unit", "BaseUnit")
                        .WithMany("Calculations")
                        .HasForeignKey("BaseUnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SmartUnitCalculator.Database.Models.Unit", "ResultUnit")
                        .WithMany()
                        .HasForeignKey("ResultUnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BaseUnit");

                    b.Navigation("ResultUnit");
                });

            modelBuilder.Entity("SmartUnitCalculator.Database.Models.History", b =>
                {
                    b.HasOne("SmartUnitCalculator.Database.Models.Unit", "BaseUnit")
                        .WithMany()
                        .HasForeignKey("BaseUnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SmartUnitCalculator.Database.Models.Unit", "ResultUnit")
                        .WithMany()
                        .HasForeignKey("ResultUnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SmartUnitCalculator.Database.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BaseUnit");

                    b.Navigation("ResultUnit");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartUnitCalculator.Database.Models.Unit", b =>
                {
                    b.HasOne("SmartUnitCalculator.Database.Models.UnitType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("SmartUnitCalculator.Database.Models.Unit", b =>
                {
                    b.Navigation("Calculations");
                });
#pragma warning restore 612, 618
        }
    }
}
