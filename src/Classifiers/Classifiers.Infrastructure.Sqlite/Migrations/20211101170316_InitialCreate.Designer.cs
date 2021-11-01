﻿// <auto-generated />
using System;
using CDPN.Classifiers.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CDPN.Classifiers.Infrastructure.Sqlite.Migrations
{
    [DbContext(typeof(ClassifiersContext))]
    [Migration("20211101170316_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0-rc.2.21480.5");

            modelBuilder.Entity("CDPN.Classifiers.Entities.AtdCategory", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(1)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StdAtdCategory", (string)null);
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.AtdLevel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InUnitIdStartIndex")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InUnitIdStoptIndex")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StdAtdLevel", (string)null);
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.AtdUnit", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("AtdCategoryId")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("TEXT");

                    b.Property<int>("AtdLevelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentId")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AtdCategoryId");

                    b.HasIndex("AtdLevelId");

                    b.HasIndex("ParentId");

                    b.ToTable("StdAtdUnit", (string)null);
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Alpha2")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("TEXT")
                        .IsFixedLength();

                    b.Property<string>("Alpha3")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("TEXT")
                        .IsFixedLength();

                    b.Property<string>("CurrencyId")
                        .HasMaxLength(3)
                        .HasColumnType("TEXT");

                    b.Property<int>("Group")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Alpha2")
                        .IsUnique();

                    b.HasIndex("Alpha3")
                        .IsUnique();

                    b.ToTable("StdCountry", (string)null);
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.Currency", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("Group")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0);

                    b.Property<int?>("MinorUnit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("NumericCode")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("NumericCode")
                        .IsUnique();

                    b.ToTable("StdCurrency", (string)null);
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.PaperSize", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Use")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("StdPaperSize", (string)null);
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.Region", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Center")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("CountryClassifierId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("RegionLevelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RegionLevelId");

                    b.ToTable("StdRegion", (string)null);
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.RegionLevel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StdRegionLevel", (string)null);
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.AtdUnit", b =>
                {
                    b.HasOne("CDPN.Classifiers.Entities.AtdCategory", "AtdCategory")
                        .WithMany("AtdUnits")
                        .HasForeignKey("AtdCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CDPN.Classifiers.Entities.AtdLevel", "AtdLevel")
                        .WithMany("AtdUnits")
                        .HasForeignKey("AtdLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CDPN.Classifiers.Entities.AtdUnit", "Parent")
                        .WithMany("Childrens")
                        .HasForeignKey("ParentId");

                    b.Navigation("AtdCategory");

                    b.Navigation("AtdLevel");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.Region", b =>
                {
                    b.HasOne("CDPN.Classifiers.Entities.RegionLevel", "RegionLevel")
                        .WithMany("Regions")
                        .HasForeignKey("RegionLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RegionLevel");
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.AtdCategory", b =>
                {
                    b.Navigation("AtdUnits");
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.AtdLevel", b =>
                {
                    b.Navigation("AtdUnits");
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.AtdUnit", b =>
                {
                    b.Navigation("Childrens");
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.RegionLevel", b =>
                {
                    b.Navigation("Regions");
                });
#pragma warning restore 612, 618
        }
    }
}
