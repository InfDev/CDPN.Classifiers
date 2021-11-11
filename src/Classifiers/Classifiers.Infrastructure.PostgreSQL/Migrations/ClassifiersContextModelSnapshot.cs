﻿// <auto-generated />
using System;
using CDPN.Classifiers.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Classifiers.Infrastructure.PostgreSQL.Migrations
{
    [DbContext(typeof(ClassifiersContext))]
    partial class ClassifiersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CDPN.Classifiers.Entities.AtdCategory", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("StdAtdCategory", (string)null);
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.AtdLevel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("InUnitIdEndIndex")
                        .HasColumnType("integer");

                    b.Property<int>("InUnitIdStartIndex")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("StdAtdLevel", (string)null);
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.AtdUnit", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("AtdCategoryId")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)");

                    b.Property<int>("AtdLevelId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("ParentId")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("AtdCategoryId");

                    b.HasIndex("AtdLevelId");

                    b.HasIndex("ParentId");

                    b.ToTable("StdAtdUnit", (string)null);
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(2)
                        .HasColumnType("character(2)")
                        .IsFixedLength();

                    b.Property<string>("Alpha3")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character(3)")
                        .IsFixedLength();

                    b.Property<string>("CurrencyId")
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<int>("Group")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("NumericCode")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Alpha3")
                        .IsUnique();

                    b.HasIndex("NumericCode")
                        .IsUnique();

                    b.ToTable("StdCountry", (string)null);
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.Currency", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("Group")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int?>("MinorUnit")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("NumericCode")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("NumericCode")
                        .IsUnique();

                    b.ToTable("StdCurrency", (string)null);
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.PaperSize", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("Use")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("StdPaperSize", (string)null);
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.Region", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Center")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("CountryClassifierId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("RegionLevelId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RegionLevelId");

                    b.ToTable("StdRegion", (string)null);
                });

            modelBuilder.Entity("CDPN.Classifiers.Entities.RegionLevel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

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
