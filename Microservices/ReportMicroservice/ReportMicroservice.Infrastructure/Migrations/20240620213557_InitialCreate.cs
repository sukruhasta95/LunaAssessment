using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportMicroservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LunaReports",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MeterSerialNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunaReports", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LunaReports",
                columns: new[] { "Id", "CreatedOn", "IsDeleted", "MeterSerialNo", "RequestedDate", "Status" },
                values: new object[] { "45d8f116-4517-4cf5-980c-bb18518e6921", new DateTime(2024, 6, 21, 0, 35, 57, 328, DateTimeKind.Local).AddTicks(8102), false, "aaAa11aa", new DateTime(2024, 6, 21, 0, 35, 57, 328, DateTimeKind.Local).AddTicks(8113), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LunaReports");
        }
    }
}
