using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaillingAppClean.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedShipsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "BaseDailyRate", "Capacity", "CreatedDate", "Damages", "Description", "HomePort", "LastMaintenanceDate", "Name", "PurchasedDate" },
                values: new object[,]
                {
                    { 1, 250.0, 6, new DateTime(2025, 1, 14, 12, 55, 50, 150, DateTimeKind.Local).AddTicks(3030), null, "A classic sailing yacht, perfect for coastal cruises.", "Miami, FL", new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sea Serpent", new DateTime(2018, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 400.0, 10, new DateTime(2025, 1, 29, 12, 55, 50, 150, DateTimeKind.Local).AddTicks(3070), "Minor scratch on hull (repaired)", "A modern catamaran, offering stability and spaciousness.", "Tortola, BVI", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ocean Breeze", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 600.0, 8, new DateTime(2024, 12, 15, 12, 55, 50, 150, DateTimeKind.Local).AddTicks(3074), null, "A sturdy motor yacht, ideal for long-distance voyages.", "San Diego, CA", new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Wanderer", new DateTime(2015, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 180.0, 4, new DateTime(2024, 11, 15, 12, 55, 50, 150, DateTimeKind.Local).AddTicks(3077), null, "A nimble sailboat, great for exploring secluded coves and bays.", "Annapolis, MD", new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Island Hopper", new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1200.0, 12, new DateTime(2025, 2, 8, 12, 55, 50, 150, DateTimeKind.Local).AddTicks(3080), "Slight interior damage (being repaired)", "A luxurious superyacht, offering unparalleled comfort and style.", "Monaco", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sunset Dream", new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
