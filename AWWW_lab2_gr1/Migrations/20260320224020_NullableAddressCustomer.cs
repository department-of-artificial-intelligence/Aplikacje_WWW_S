using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab2_gr1.Migrations
{
    /// <inheritdoc />
    public partial class NullableAddressCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customer_CustomerId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "Streest",
                table: "Addresses",
                newName: "Street");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Addresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Customer_CustomerId",
                table: "Addresses",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customer_CustomerId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Addresses",
                newName: "Streest");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Customer_CustomerId",
                table: "Addresses",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
