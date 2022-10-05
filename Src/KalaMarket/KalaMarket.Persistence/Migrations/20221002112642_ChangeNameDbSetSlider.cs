using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalaMarket.Persistence.Migrations
{
    public partial class ChangeNameDbSetSlider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MainSliders",
                table: "MainSliders");

            migrationBuilder.RenameTable(
                name: "MainSliders",
                newName: "Sliders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sliders",
                table: "Sliders",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sliders",
                table: "Sliders");

            migrationBuilder.RenameTable(
                name: "Sliders",
                newName: "MainSliders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainSliders",
                table: "MainSliders",
                column: "Id");

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
    }
}
