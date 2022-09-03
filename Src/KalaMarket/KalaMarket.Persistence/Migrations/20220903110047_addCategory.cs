using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalaMarket.Persistence.Migrations
{
    public partial class addCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdateTime",
                value: new DateTime(2022, 9, 3, 15, 30, 46, 916, DateTimeKind.Local).AddTicks(5895));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UpdateTime",
                value: new DateTime(2022, 9, 3, 15, 30, 46, 916, DateTimeKind.Local).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "UpdateTime",
                value: new DateTime(2022, 9, 3, 15, 30, 46, 916, DateTimeKind.Local).AddTicks(6046));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdateTime",
                value: new DateTime(2022, 8, 31, 16, 4, 2, 55, DateTimeKind.Local).AddTicks(1460));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UpdateTime",
                value: new DateTime(2022, 8, 31, 16, 4, 2, 55, DateTimeKind.Local).AddTicks(1542));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "UpdateTime",
                value: new DateTime(2022, 8, 31, 16, 4, 2, 55, DateTimeKind.Local).AddTicks(1556));
        }
    }
}
