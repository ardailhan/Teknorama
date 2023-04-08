using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeknoramaBackOffice.Persistance.Migrations
{
    public partial class updatedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedOrder_Orders_OrderId",
                table: "CompletedOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompletedOrder",
                table: "CompletedOrder");

            migrationBuilder.RenameTable(
                name: "CompletedOrder",
                newName: "CompletedOrders");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedOrder_OrderId",
                table: "CompletedOrders",
                newName: "IX_CompletedOrders_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompletedOrders",
                table: "CompletedOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedOrders_Orders_OrderId",
                table: "CompletedOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedOrders_Orders_OrderId",
                table: "CompletedOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompletedOrders",
                table: "CompletedOrders");

            migrationBuilder.RenameTable(
                name: "CompletedOrders",
                newName: "CompletedOrder");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedOrders_OrderId",
                table: "CompletedOrder",
                newName: "IX_CompletedOrder_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompletedOrder",
                table: "CompletedOrder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedOrder_Orders_OrderId",
                table: "CompletedOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
