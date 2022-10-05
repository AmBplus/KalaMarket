using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalaMarket.Persistence.Migrations
{
    public partial class AddCart_CartItem1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "UserDeviceId",
                table: "Carts",
                newName: "DeviceId");

            migrationBuilder.AddColumn<bool>(
                name: "Finished",
                table: "Carts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "CartItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 5, 16, 43, 46, 274, DateTimeKind.Local).AddTicks(8998), new DateTime(2022, 10, 5, 16, 43, 46, 274, DateTimeKind.Local).AddTicks(8902) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 5, 16, 43, 46, 274, DateTimeKind.Local).AddTicks(9154), new DateTime(2022, 10, 5, 16, 43, 46, 274, DateTimeKind.Local).AddTicks(9117) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 5, 16, 43, 46, 274, DateTimeKind.Local).AddTicks(9241), new DateTime(2022, 10, 5, 16, 43, 46, 274, DateTimeKind.Local).AddTicks(9206) });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Finished",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "DeviceId",
                table: "Carts",
                newName: "UserDeviceId");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "CartItems",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 5, 9, 24, 1, 123, DateTimeKind.Local).AddTicks(5663), new DateTime(2022, 10, 5, 9, 24, 1, 123, DateTimeKind.Local).AddTicks(5612) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 5, 9, 24, 1, 123, DateTimeKind.Local).AddTicks(5719), new DateTime(2022, 10, 5, 9, 24, 1, 123, DateTimeKind.Local).AddTicks(5712) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 5, 9, 24, 1, 123, DateTimeKind.Local).AddTicks(5736), new DateTime(2022, 10, 5, 9, 24, 1, 123, DateTimeKind.Local).AddTicks(5730) });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
