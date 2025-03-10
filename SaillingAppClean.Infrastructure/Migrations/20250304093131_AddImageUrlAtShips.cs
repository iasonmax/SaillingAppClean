using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaillingAppClean.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlAtShips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Ships",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 2, 2, 11, 31, 30, 664, DateTimeKind.Local).AddTicks(6168), null });

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 2, 17, 11, 31, 30, 664, DateTimeKind.Local).AddTicks(6213), null });

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 31, 30, 664, DateTimeKind.Local).AddTicks(6218), null });

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 4, 11, 31, 30, 664, DateTimeKind.Local).AddTicks(6221), null });

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 2, 27, 11, 31, 30, 664, DateTimeKind.Local).AddTicks(6226), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Ships");

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 20, 17, 12, 5, 253, DateTimeKind.Local).AddTicks(4503));

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 4, 17, 12, 5, 253, DateTimeKind.Local).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 21, 17, 12, 5, 253, DateTimeKind.Local).AddTicks(4554));

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 21, 17, 12, 5, 253, DateTimeKind.Local).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 14, 17, 12, 5, 253, DateTimeKind.Local).AddTicks(4560));
        }
    }
}
