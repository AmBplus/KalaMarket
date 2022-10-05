using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalaMarket.Persistence.Migrations
{
    public partial class AddSliderType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "SliderType",
                table: "Sliders",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 4, 12, 43, 5, 316, DateTimeKind.Local).AddTicks(4588), new DateTime(2022, 10, 4, 12, 43, 5, 316, DateTimeKind.Local).AddTicks(4427) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 4, 12, 43, 5, 316, DateTimeKind.Local).AddTicks(4709), new DateTime(2022, 10, 4, 12, 43, 5, 316, DateTimeKind.Local).AddTicks(4695) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 4, 12, 43, 5, 316, DateTimeKind.Local).AddTicks(4730), new DateTime(2022, 10, 4, 12, 43, 5, 316, DateTimeKind.Local).AddTicks(4722) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SliderType",
                table: "Sliders");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 2, 14, 56, 42, 305, DateTimeKind.Local).AddTicks(2194), new DateTime(2022, 10, 2, 14, 56, 42, 305, DateTimeKind.Local).AddTicks(2144) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 2, 14, 56, 42, 305, DateTimeKind.Local).AddTicks(2251), new DateTime(2022, 10, 2, 14, 56, 42, 305, DateTimeKind.Local).AddTicks(2244) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 2, 14, 56, 42, 305, DateTimeKind.Local).AddTicks(2269), new DateTime(2022, 10, 2, 14, 56, 42, 305, DateTimeKind.Local).AddTicks(2262) });
        }
    }
}
