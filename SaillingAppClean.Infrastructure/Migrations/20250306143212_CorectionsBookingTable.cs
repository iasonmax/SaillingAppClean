using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaillingAppClean.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorectionsBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChaeckOutDate",
                table: "Bookings",
                newName: "CheckOutDate");

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 4, 16, 32, 12, 581, DateTimeKind.Local).AddTicks(6222));

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 16, 32, 12, 581, DateTimeKind.Local).AddTicks(6276));

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 5, 16, 32, 12, 581, DateTimeKind.Local).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 6, 16, 32, 12, 581, DateTimeKind.Local).AddTicks(6284));

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 1, 16, 32, 12, 581, DateTimeKind.Local).AddTicks(6287));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckOutDate",
                table: "Bookings",
                newName: "ChaeckOutDate");

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 4, 15, 49, 16, 145, DateTimeKind.Local).AddTicks(3453));

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 15, 49, 16, 145, DateTimeKind.Local).AddTicks(3520));

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 5, 15, 49, 16, 145, DateTimeKind.Local).AddTicks(3525));

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 6, 15, 49, 16, 145, DateTimeKind.Local).AddTicks(3528));

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 1, 15, 49, 16, 145, DateTimeKind.Local).AddTicks(3531));
        }
    }
}
