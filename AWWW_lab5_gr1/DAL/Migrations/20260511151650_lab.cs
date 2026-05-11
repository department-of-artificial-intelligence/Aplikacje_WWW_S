using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class lab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RoomsEquipment_RoomId",
                table: "RoomsEquipment");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsEquipment_RoomId_EquipmentId",
                table: "RoomsEquipment",
                columns: new[] { "RoomId", "EquipmentId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RoomsEquipment_RoomId_EquipmentId",
                table: "RoomsEquipment");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsEquipment_RoomId",
                table: "RoomsEquipment",
                column: "RoomId");
        }
    }
}
