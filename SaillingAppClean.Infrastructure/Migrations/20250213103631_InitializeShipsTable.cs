using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaillingAppClean.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitializeShipsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseDailyRate = table.Column<double>(type: "float", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    HomePort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Damages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchasedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastMaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ships");
        }
    }
}
