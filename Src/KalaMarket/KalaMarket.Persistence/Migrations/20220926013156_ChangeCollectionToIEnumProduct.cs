using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalaMarket.Persistence.Migrations
{
    public partial class ChangeCollectionToIEnumProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 26, 5, 1, 56, 490, DateTimeKind.Local).AddTicks(2494), new DateTime(2022, 9, 26, 5, 1, 56, 490, DateTimeKind.Local).AddTicks(2443) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 26, 5, 1, 56, 490, DateTimeKind.Local).AddTicks(2559), new DateTime(2022, 9, 26, 5, 1, 56, 490, DateTimeKind.Local).AddTicks(2552) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 26, 5, 1, 56, 490, DateTimeKind.Local).AddTicks(2577), new DateTime(2022, 9, 26, 5, 1, 56, 490, DateTimeKind.Local).AddTicks(2570) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
