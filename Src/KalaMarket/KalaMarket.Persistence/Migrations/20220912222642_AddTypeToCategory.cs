using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalaMarket.Persistence.Migrations
{
    public partial class AddTypeToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "ParentType",
                table: "Categories",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdateTime",
                value: new DateTime(2022, 9, 13, 2, 56, 42, 619, DateTimeKind.Local).AddTicks(7223));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UpdateTime",
                value: new DateTime(2022, 9, 13, 2, 56, 42, 619, DateTimeKind.Local).AddTicks(7307));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "UpdateTime",
                value: new DateTime(2022, 9, 13, 2, 56, 42, 619, DateTimeKind.Local).AddTicks(7320));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentName",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ParentType",
                table: "Categories");

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
    }
}
