using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalaMarket.Persistence.Migrations
{
    public partial class AddIsActiveToBrands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "ProductImages");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 15, 15, 48, 49, 889, DateTimeKind.Local).AddTicks(680), new DateTime(2022, 9, 15, 15, 48, 49, 889, DateTimeKind.Local).AddTicks(621) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 15, 15, 48, 49, 889, DateTimeKind.Local).AddTicks(787), new DateTime(2022, 9, 15, 15, 48, 49, 889, DateTimeKind.Local).AddTicks(732) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 9, 15, 15, 48, 49, 889, DateTimeKind.Local).AddTicks(808), new DateTime(2022, 9, 15, 15, 48, 49, 889, DateTimeKind.Local).AddTicks(801) });
        }
    }
}
