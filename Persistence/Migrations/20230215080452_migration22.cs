using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class migration22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "PurchaseOrders",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "PurchaseOrderId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "PurchaseOrders",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeliverOn", "DeliveryLocation", "LastModifiedBy", "LastModifiedDate", "Notes", "PaymentTerms", "PlacedOn", "Status", "Total", "Vendor", "VendorEmail" },
                values: new object[] { new Guid("92a36f8b-3f8c-4638-a02f-959fcc3435a8"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 15, 13, 34, 52, 205, DateTimeKind.Local).AddTicks(7361), "", null, null, "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.", null, new DateTime(2023, 2, 15, 13, 34, 52, 205, DateTimeKind.Local).AddTicks(7347), 0, 6500000, "John & Sons Toyota Dealers", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PurchaseOrders",
                keyColumn: "Id",
                keyValue: new Guid("92a36f8b-3f8c-4638-a02f-959fcc3435a8"));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PurchaseOrders",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseOrderId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
