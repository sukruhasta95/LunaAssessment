using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeterMicroservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MeterSerialNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasurementTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastIndex = table.Column<int>(type: "int", nullable: false),
                    VoltageValue = table.Column<double>(type: "float", nullable: false),
                    CurrentValue = table.Column<double>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Meters",
                columns: new[] { "Id", "CreatedOn", "CurrentValue", "IsDeleted", "LastIndex", "MeasurementTime", "MeterSerialNo", "VoltageValue" },
                values: new object[] { "da119dc7-9083-4b53-95c8-0f1ab2ea9f16", new DateTime(2024, 6, 21, 0, 35, 0, 288, DateTimeKind.Local).AddTicks(4815), 10.0, false, 2, new DateTime(2024, 6, 21, 0, 35, 0, 288, DateTimeKind.Local).AddTicks(4829), "aaAa11aa", 10.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meters");
        }
    }
}
