using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalaMarket.Persistence.Migrations
{
    public partial class AddLinkToSlider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "MainSliders",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 2, 14, 2, 19, 851, DateTimeKind.Local).AddTicks(2004), new DateTime(2022, 10, 2, 14, 2, 19, 851, DateTimeKind.Local).AddTicks(1944) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 2, 14, 2, 19, 851, DateTimeKind.Local).AddTicks(2145), new DateTime(2022, 10, 2, 14, 2, 19, 851, DateTimeKind.Local).AddTicks(2136) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 2, 14, 2, 19, 851, DateTimeKind.Local).AddTicks(2165), new DateTime(2022, 10, 2, 14, 2, 19, 851, DateTimeKind.Local).AddTicks(2158) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "MainSliders");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 2, 10, 53, 19, 814, DateTimeKind.Local).AddTicks(362), new DateTime(2022, 10, 2, 10, 53, 19, 814, DateTimeKind.Local).AddTicks(251) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 2, 10, 53, 19, 814, DateTimeKind.Local).AddTicks(653), new DateTime(2022, 10, 2, 10, 53, 19, 814, DateTimeKind.Local).AddTicks(620) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 2, 10, 53, 19, 814, DateTimeKind.Local).AddTicks(728), new DateTime(2022, 10, 2, 10, 53, 19, 814, DateTimeKind.Local).AddTicks(703) });
        }
    }
}
