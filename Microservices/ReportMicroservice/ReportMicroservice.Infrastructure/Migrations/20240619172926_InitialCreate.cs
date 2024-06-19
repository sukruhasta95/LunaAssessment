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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                values: new object[] { new Guid("b896c024-e0d6-49dc-a1f4-dd3e34d58a34"), new DateTime(2024, 6, 19, 20, 29, 26, 132, DateTimeKind.Local).AddTicks(6719), false, "aaAa11aa", new DateTime(2024, 6, 19, 20, 29, 26, 132, DateTimeKind.Local).AddTicks(6731), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LunaReports");
        }
    }
}
