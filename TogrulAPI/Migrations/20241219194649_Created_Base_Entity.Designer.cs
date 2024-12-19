﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TogrulAPI.DAL;

#nullable disable

namespace TogrulAPI.Migrations
{
    [DbContext(typeof(TogrulDB))]
    [Migration("20241219194649_Created_Base_Entity")]
    partial class Created_Base_Entity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TogrulAPI.Entities.Language", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(2)
                        .HasColumnType("nchar(2)")
                        .IsFixedLength();

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Code");

                    b.HasIndex("LanguageName")
                        .IsUnique();

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Code = "az",
                            DateTime = new DateTime(2024, 12, 19, 23, 46, 48, 694, DateTimeKind.Local).AddTicks(1181),
                            Icon = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Flag_of_Azerbaijan.svg/1200px-Flag_of_Azerbaijan.svg.png",
                            Id = 0,
                            IsDeleted = false,
                            LanguageName = "Azərbaycan"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
