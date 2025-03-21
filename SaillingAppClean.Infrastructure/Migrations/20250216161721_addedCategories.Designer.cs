﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaillingAppClean.Infrastructure.Data;

#nullable disable

namespace SaillingAppClean.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250216161721_addedCategories")]
    partial class addedCategories
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SailingAppClean.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Monohull"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Catamaran"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Monohull with deep keel"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 4,
                            Name = "Trimaran"
                        });
                });

            modelBuilder.Entity("SailingAppClean.Domain.Entities.Ship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("BaseDailyRate")
                        .HasColumnType("float");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Damages")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomePort")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastMaintenanceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PurchasedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Ships");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BaseDailyRate = 250.0,
                            Capacity = 6,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2025, 1, 17, 18, 17, 21, 360, DateTimeKind.Local).AddTicks(8998),
                            Description = "A classic sailing yacht, perfect for coastal cruises.",
                            HomePort = "Miami, FL",
                            LastMaintenanceDate = new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sea Serpent",
                            PurchasedDate = new DateTime(2018, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            BaseDailyRate = 400.0,
                            Capacity = 10,
                            CategoryId = 4,
                            CreatedDate = new DateTime(2025, 2, 1, 18, 17, 21, 360, DateTimeKind.Local).AddTicks(9043),
                            Damages = "Minor scratch on hull (repaired)",
                            Description = "A modern catamaran, offering stability and spaciousness.",
                            HomePort = "Tortola, BVI",
                            LastMaintenanceDate = new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ocean Breeze",
                            PurchasedDate = new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            BaseDailyRate = 600.0,
                            Capacity = 8,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2024, 12, 18, 18, 17, 21, 360, DateTimeKind.Local).AddTicks(9047),
                            Description = "A sturdy motor yacht, ideal for long-distance voyages.",
                            HomePort = "San Diego, CA",
                            LastMaintenanceDate = new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "The Wanderer",
                            PurchasedDate = new DateTime(2015, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            BaseDailyRate = 180.0,
                            Capacity = 4,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2024, 11, 18, 18, 17, 21, 360, DateTimeKind.Local).AddTicks(9050),
                            Description = "A nimble sailboat, great for exploring secluded coves and bays.",
                            HomePort = "Annapolis, MD",
                            LastMaintenanceDate = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Island Hopper",
                            PurchasedDate = new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            BaseDailyRate = 1200.0,
                            Capacity = 12,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2025, 2, 11, 18, 17, 21, 360, DateTimeKind.Local).AddTicks(9053),
                            Damages = "Slight interior damage (being repaired)",
                            Description = "A luxurious superyacht, offering unparalleled comfort and style.",
                            HomePort = "Monaco",
                            LastMaintenanceDate = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sunset Dream",
                            PurchasedDate = new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SailingAppClean.Domain.Entities.Ship", b =>
                {
                    b.HasOne("SailingAppClean.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
