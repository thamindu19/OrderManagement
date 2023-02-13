using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "PurchaseOrders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "PurchaseOrders",
                keyColumn: "Id",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                columns: new[] { "DeliverOn", "ItemId", "PlacedOn" },
                values: new object[] { new DateTime(2023, 8, 13, 15, 40, 59, 198, DateTimeKind.Local).AddTicks(8132), "abcd", new DateTime(2023, 2, 13, 15, 40, 59, 198, DateTimeKind.Local).AddTicks(8119) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "PurchaseOrders",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "PurchaseOrders",
                keyColumn: "Id",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                columns: new[] { "DeliverOn", "ItemId", "PlacedOn" },
                values: new object[] { new DateTime(2023, 8, 13, 15, 32, 17, 554, DateTimeKind.Local).AddTicks(516), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), new DateTime(2023, 2, 13, 15, 32, 17, 554, DateTimeKind.Local).AddTicks(501) });
        }
    }
}
