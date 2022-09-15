using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalaMarket.Persistence.Migrations
{
    public partial class init_mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 15, 0, 48, 21, 471, DateTimeKind.Local).AddTicks(3062), new DateTime(2022, 9, 15, 0, 48, 21, 471, DateTimeKind.Local).AddTicks(2979) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 15, 0, 48, 21, 471, DateTimeKind.Local).AddTicks(3172), new DateTime(2022, 9, 15, 0, 48, 21, 471, DateTimeKind.Local).AddTicks(3156) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 15, 0, 48, 21, 471, DateTimeKind.Local).AddTicks(3210), new DateTime(2022, 9, 15, 0, 48, 21, 471, DateTimeKind.Local).AddTicks(3195) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 15, 0, 42, 18, 396, DateTimeKind.Local).AddTicks(5564), new DateTime(2022, 9, 15, 0, 42, 18, 396, DateTimeKind.Local).AddTicks(5489) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 15, 0, 42, 18, 396, DateTimeKind.Local).AddTicks(5777), new DateTime(2022, 9, 15, 0, 42, 18, 396, DateTimeKind.Local).AddTicks(5653) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 15, 0, 42, 18, 396, DateTimeKind.Local).AddTicks(5822), new DateTime(2022, 9, 15, 0, 42, 18, 396, DateTimeKind.Local).AddTicks(5807) });
        }
    }
}
