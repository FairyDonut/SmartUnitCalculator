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
    [Migration("20220712220928_ExtendUnitTypeTable")]
    partial class ExtendUnitTypeTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SmartUnitCalculator.Database.Models.Calculation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BaseUnitId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Multiplier")
                        .HasPrecision(38, 19)
                        .HasColumnType("decimal(38,19)");

                    b.Property<int?>("ResultUnitId")
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

                    b.Property<decimal>("BaseValue")
                        .HasPrecision(38, 19)
                        .HasColumnType("decimal(38,19)");

                    b.Property<int?>("CalculationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("CalculationId");

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

                    b.Property<string>("Symbol")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TypeName")
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

            modelBuilder.Entity("SmartUnitCalculator.Database.Models.Calculation", b =>
                {
                    b.HasOne("SmartUnitCalculator.Database.Models.Unit", "BaseUnit")
                        .WithMany("Calculations")
                        .HasForeignKey("BaseUnitId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartUnitCalculator.Database.Models.Unit", "ResultUnit")
                        .WithMany()
                        .HasForeignKey("ResultUnitId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("BaseUnit");

                    b.Navigation("ResultUnit");
                });

            modelBuilder.Entity("SmartUnitCalculator.Database.Models.History", b =>
                {
                    b.HasOne("SmartUnitCalculator.Database.Models.Calculation", "Calculation")
                        .WithMany()
                        .HasForeignKey("CalculationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Calculation");
                });

            modelBuilder.Entity("SmartUnitCalculator.Database.Models.Unit", b =>
                {
                    b.HasOne("SmartUnitCalculator.Database.Models.UnitType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeName");

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
