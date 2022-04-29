﻿// <auto-generated />
using System;
using Gartencenter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gartencenter.Migrations
{
    [DbContext(typeof(LibContext))]
    [Migration("20220422165304_FirstInit")]
    partial class FirstInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Gartencenter.Model.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "Test1234!",
                            Username = "test@test.at"
                        });
                });

            modelBuilder.Entity("Gartencenter.Model.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryID = 1,
                            Name = "Tulpe",
                            Price = 5.99m
                        },
                        new
                        {
                            Id = 2,
                            CategoryID = 2,
                            Name = "Buchs",
                            Price = 16.99m
                        },
                        new
                        {
                            Id = 3,
                            CategoryID = 3,
                            Name = "Ahornbaum",
                            Price = 55.98m
                        });
                });

            modelBuilder.Entity("Gartencenter.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Balkonpflanze"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Strauch"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Baum"
                        });
                });

            modelBuilder.Entity("Gartencenter.Model.Lieferant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Lieferanten");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "Innsbruck",
                            Name = "Obi"
                        },
                        new
                        {
                            Id = 2,
                            Country = "Neu Rum",
                            Name = "Hornbach"
                        },
                        new
                        {
                            Id = 3,
                            Country = "Völs",
                            Name = "Bauhaus"
                        });
                });

            modelBuilder.Entity("Gartencenter.Model.Lieferung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ArticleID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DayOfDelivery")
                        .HasColumnType("datetime2");

                    b.Property<int>("LieferantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticleID");

                    b.HasIndex("LieferantId");

                    b.ToTable("Lieferung");
                });

            modelBuilder.Entity("Gartencenter.Model.Article", b =>
                {
                    b.HasOne("Gartencenter.Model.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Gartencenter.Model.Lieferung", b =>
                {
                    b.HasOne("Gartencenter.Model.Article", "Article")
                        .WithMany("Lieferungen")
                        .HasForeignKey("ArticleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gartencenter.Model.Lieferant", "Lieferant")
                        .WithMany("Lieferungen")
                        .HasForeignKey("LieferantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Lieferant");
                });

            modelBuilder.Entity("Gartencenter.Model.Article", b =>
                {
                    b.Navigation("Lieferungen");
                });

            modelBuilder.Entity("Gartencenter.Model.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Gartencenter.Model.Lieferant", b =>
                {
                    b.Navigation("Lieferungen");
                });
#pragma warning restore 612, 618
        }
    }
}