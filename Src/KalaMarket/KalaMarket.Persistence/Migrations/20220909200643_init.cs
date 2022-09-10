using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalaMarket.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdateTime",
                value: new DateTime(2022, 9, 10, 0, 36, 42, 898, DateTimeKind.Local).AddTicks(3193));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UpdateTime",
                value: new DateTime(2022, 9, 10, 0, 36, 42, 898, DateTimeKind.Local).AddTicks(3302));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "UpdateTime",
                value: new DateTime(2022, 9, 10, 0, 36, 42, 898, DateTimeKind.Local).AddTicks(3317));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdateTime",
                value: new DateTime(2022, 9, 3, 15, 30, 46, 916, DateTimeKind.Local).AddTicks(5895));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UpdateTime",
                value: new DateTime(2022, 9, 3, 15, 30, 46, 916, DateTimeKind.Local).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "UpdateTime",
                value: new DateTime(2022, 9, 3, 15, 30, 46, 916, DateTimeKind.Local).AddTicks(6046));
        }
    }
}
