using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalaMarket.Persistence.Migrations
{
    public partial class update_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId1",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "ProductId1",
                table: "CartItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_ProductId1",
                table: "CartItems",
                newName: "IX_CartItems_ProductId");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdateTime",
                value: new DateTime(2022, 12, 6, 22, 6, 55, 283, DateTimeKind.Local).AddTicks(3079));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UpdateTime",
                value: new DateTime(2022, 12, 6, 22, 6, 55, 283, DateTimeKind.Local).AddTicks(3175));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "UpdateTime",
                value: new DateTime(2022, 12, 6, 22, 6, 55, 283, DateTimeKind.Local).AddTicks(3192));

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

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CartItems",
                newName: "ProductId1");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                newName: "IX_CartItems_ProductId1");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdateTime",
                value: new DateTime(2022, 12, 5, 22, 52, 6, 128, DateTimeKind.Local).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UpdateTime",
                value: new DateTime(2022, 12, 5, 22, 52, 6, 128, DateTimeKind.Local).AddTicks(491));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "UpdateTime",
                value: new DateTime(2022, 12, 5, 22, 52, 6, 128, DateTimeKind.Local).AddTicks(527));

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId1",
                table: "CartItems",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
