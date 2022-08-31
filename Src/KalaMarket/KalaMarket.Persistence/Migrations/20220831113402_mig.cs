using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalaMarket.Persistence.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdateTime",
                value: new DateTime(2022, 8, 31, 16, 4, 2, 55, DateTimeKind.Local).AddTicks(1460));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UpdateTime",
                value: new DateTime(2022, 8, 31, 16, 4, 2, 55, DateTimeKind.Local).AddTicks(1542));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "UpdateTime",
                value: new DateTime(2022, 8, 31, 16, 4, 2, 55, DateTimeKind.Local).AddTicks(1556));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdateTime",
                value: new DateTime(2022, 8, 30, 17, 3, 38, 135, DateTimeKind.Local).AddTicks(6099));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UpdateTime",
                value: new DateTime(2022, 8, 30, 17, 3, 38, 135, DateTimeKind.Local).AddTicks(6184));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "UpdateTime",
                value: new DateTime(2022, 8, 30, 17, 3, 38, 135, DateTimeKind.Local).AddTicks(6203));
        }
    }
}
