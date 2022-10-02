using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalaMarket.Persistence.Migrations
{
    public partial class addViewCountToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ViewCount",
                table: "Products",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 2, 0, 10, 15, 734, DateTimeKind.Local).AddTicks(7224), new DateTime(2022, 10, 2, 0, 10, 15, 734, DateTimeKind.Local).AddTicks(7179) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 2, 0, 10, 15, 734, DateTimeKind.Local).AddTicks(7283), new DateTime(2022, 10, 2, 0, 10, 15, 734, DateTimeKind.Local).AddTicks(7276) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 2, 0, 10, 15, 734, DateTimeKind.Local).AddTicks(7358), new DateTime(2022, 10, 2, 0, 10, 15, 734, DateTimeKind.Local).AddTicks(7352) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 26, 6, 27, 31, 376, DateTimeKind.Local).AddTicks(3175), new DateTime(2022, 9, 26, 6, 27, 31, 376, DateTimeKind.Local).AddTicks(3083) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 26, 6, 27, 31, 376, DateTimeKind.Local).AddTicks(3280), new DateTime(2022, 9, 26, 6, 27, 31, 376, DateTimeKind.Local).AddTicks(3271) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 26, 6, 27, 31, 376, DateTimeKind.Local).AddTicks(3360), new DateTime(2022, 9, 26, 6, 27, 31, 376, DateTimeKind.Local).AddTicks(3292) });
        }
    }
}
