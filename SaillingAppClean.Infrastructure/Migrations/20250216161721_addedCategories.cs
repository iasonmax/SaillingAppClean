using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaillingAppClean.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Ships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Monohull" },
                    { 2, 2, "Catamaran" },
                    { 3, 3, "Monohull with deep keel" },
                    { 4, 4, "Trimaran" }
                });

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "CreatedDate" },
                values: new object[] { 3, new DateTime(2025, 1, 17, 18, 17, 21, 360, DateTimeKind.Local).AddTicks(8998) });

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "CreatedDate" },
                values: new object[] { 4, new DateTime(2025, 2, 1, 18, 17, 21, 360, DateTimeKind.Local).AddTicks(9043) });

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "CreatedDate" },
                values: new object[] { 1, new DateTime(2024, 12, 18, 18, 17, 21, 360, DateTimeKind.Local).AddTicks(9047) });

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "CreatedDate" },
                values: new object[] { 1, new DateTime(2024, 11, 18, 18, 17, 21, 360, DateTimeKind.Local).AddTicks(9050) });

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "CreatedDate" },
                values: new object[] { 2, new DateTime(2025, 2, 11, 18, 17, 21, 360, DateTimeKind.Local).AddTicks(9053) });

            migrationBuilder.CreateIndex(
                name: "IX_Ships_CategoryId",
                table: "Ships",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_Categories_CategoryId",
                table: "Ships",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ships_Categories_CategoryId",
                table: "Ships");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Ships_CategoryId",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Ships");

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 14, 12, 55, 50, 150, DateTimeKind.Local).AddTicks(3030));

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 12, 55, 50, 150, DateTimeKind.Local).AddTicks(3070));

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 15, 12, 55, 50, 150, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 15, 12, 55, 50, 150, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 12, 55, 50, 150, DateTimeKind.Local).AddTicks(3080));
        }
    }
}
