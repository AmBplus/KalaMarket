using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalaMarket.Persistence.Migrations
{
    public partial class FixActivation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 25, 19, 53, 4, 375, DateTimeKind.Local).AddTicks(6304), new DateTime(2022, 9, 25, 19, 53, 4, 375, DateTimeKind.Local).AddTicks(6244) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 25, 19, 53, 4, 375, DateTimeKind.Local).AddTicks(6384), new DateTime(2022, 9, 25, 19, 53, 4, 375, DateTimeKind.Local).AddTicks(6355) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 25, 19, 53, 4, 375, DateTimeKind.Local).AddTicks(6403), new DateTime(2022, 9, 25, 19, 53, 4, 375, DateTimeKind.Local).AddTicks(6397) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Brands");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 25, 13, 30, 41, 129, DateTimeKind.Local).AddTicks(4110), new DateTime(2022, 9, 25, 13, 30, 41, 129, DateTimeKind.Local).AddTicks(4047) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 25, 13, 30, 41, 129, DateTimeKind.Local).AddTicks(4170), new DateTime(2022, 9, 25, 13, 30, 41, 129, DateTimeKind.Local).AddTicks(4162) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 25, 13, 30, 41, 129, DateTimeKind.Local).AddTicks(4196), new DateTime(2022, 9, 25, 13, 30, 41, 129, DateTimeKind.Local).AddTicks(4188) });
        }
    }
}
