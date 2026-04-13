using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab4_gr1.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderStatusId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderStatusId1",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderStatusId1",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId1",
                table: "Orders",
                column: "OrderStatusId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusId1",
                table: "Orders",
                column: "OrderStatusId1",
                principalTable: "OrderStatuses",
                principalColumn: "Id");
        }
    }
}
