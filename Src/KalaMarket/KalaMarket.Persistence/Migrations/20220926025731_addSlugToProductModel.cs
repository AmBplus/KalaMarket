using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalaMarket.Persistence.Migrations
{
    public partial class addSlugToProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Products");

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
    }
}
