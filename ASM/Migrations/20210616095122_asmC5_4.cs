using Microsoft.EntityFrameworkCore.Migrations;

namespace ASM.Migrations
{
    public partial class asmC5_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Foods_FoodID1",
                table: "OrderDetails",
                column: "FoodID",
                principalTable: "Foods",
                principalColumn: "FoodID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderID1",
                table: "OrderDetails",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Foods_FoodID1",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderID1",
                table: "OrderDetails");
        }
    }
}
