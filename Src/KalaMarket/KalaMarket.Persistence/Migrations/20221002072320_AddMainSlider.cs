using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalaMarket.Persistence.Migrations
{
    public partial class AddMainSlider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainSliders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Src = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainSliders", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainSliders");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 2, 6, 3, 40, 538, DateTimeKind.Local).AddTicks(220), new DateTime(2022, 10, 2, 6, 3, 40, 538, DateTimeKind.Local).AddTicks(175) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 2, 6, 3, 40, 538, DateTimeKind.Local).AddTicks(272), new DateTime(2022, 10, 2, 6, 3, 40, 538, DateTimeKind.Local).AddTicks(265) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "InsertTime", "UpdateTime" },
                values: new object[] { new DateTime(2022, 10, 2, 6, 3, 40, 538, DateTimeKind.Local).AddTicks(341), new DateTime(2022, 10, 2, 6, 3, 40, 538, DateTimeKind.Local).AddTicks(334) });
        }
    }
}
