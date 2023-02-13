using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Items_ItemId",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_ItemId",
                table: "PurchaseOrders");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                columns: new[] { "Description", "Price", "Quantity" },
                values: new object[] { "Toyota AXE 3", 6500000, 1 });

            migrationBuilder.UpdateData(
                table: "PurchaseOrders",
                keyColumn: "Id",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                columns: new[] { "DeliverOn", "PlacedOn" },
                values: new object[] { new DateTime(2023, 8, 13, 15, 32, 17, 554, DateTimeKind.Local).AddTicks(516), new DateTime(2023, 2, 13, 15, 32, 17, 554, DateTimeKind.Local).AddTicks(501) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                columns: new[] { "Description", "Price", "Quantity" },
                values: new object[] { null, 0, 0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "LastModifiedBy", "LastModifiedDate", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Van", 0, 0 },
                    { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Bicycle", 0, 0 }
                });

            migrationBuilder.UpdateData(
                table: "PurchaseOrders",
                keyColumn: "Id",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                columns: new[] { "DeliverOn", "PlacedOn" },
                values: new object[] { new DateTime(2023, 8, 13, 8, 58, 42, 580, DateTimeKind.Local).AddTicks(1164), new DateTime(2023, 2, 13, 8, 58, 42, 580, DateTimeKind.Local).AddTicks(1153) });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_ItemId",
                table: "PurchaseOrders",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Items_ItemId",
                table: "PurchaseOrders",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
