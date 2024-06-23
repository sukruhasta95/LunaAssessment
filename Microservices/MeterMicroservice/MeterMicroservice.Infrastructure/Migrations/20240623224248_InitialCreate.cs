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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meters");
        }
    }
}
